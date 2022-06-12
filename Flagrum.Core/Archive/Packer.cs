﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Flagrum.Core.Services.Logging;
using Flagrum.Core.Utilities;

namespace Flagrum.Core.Archive;

public class Packer
{
    private const uint PointerSize = 8;
    private const uint BlockSize = 512;

    private readonly Logger _logger;
    private List<ArchiveFile> _files;

    public Packer()
    {
        _logger = new DeadConsoleLogger();
        Header = new ArchiveHeader();
        _files = new List<ArchiveFile>();
    }

    private Packer(ArchiveHeader header, List<ArchiveFile> files) : this()
    {
        Header = header;
        _files = files;
    }

    public ArchiveHeader Header { get; }

    public static Packer FromUnpacker(ArchiveHeader header, List<ArchiveFile> files)
    {
        return new Packer(header, files);
    }

    public bool HasFile(string uri)
    {
        return _files.Any(f => f.Uri == uri);
    }

    public void AddCompressedFile(string uri, byte[] data, bool autoload = false)
    {
        var file = new ArchiveFile(uri)
        {
            Flags = ArchiveFileFlag.Compressed
        };

        if (autoload)
        {
            file.Flags |= ArchiveFileFlag.Autoload;
        }

        file.SetRawData(data);
        _files.Add(file);
    }

    public void AddFile(byte[] data, string uri)
    {
        var file = new ArchiveFile(uri);
        file.SetRawData(data);

        _files.Add(file);
    }

    public void AddAutoloadFile(string uri, byte[] data)
    {
        var file = new ArchiveFile(uri);
        file.SetRawData(data);
        file.Flags = ArchiveFileFlag.Autoload;
        _files.Add(file);
    }

    public void AddReference(string uri, bool autoload)
    {
        var file = new ArchiveFile(uri);
        file.Flags = ArchiveFileFlag.Reference;

        if (autoload)
        {
            file.Flags |= ArchiveFileFlag.Autoload;
        }

        _files.Add(file);
    }

    public void UpdateFile(string query, byte[] data)
    {
        var match = _files.FirstOrDefault(f => f.Uri.EndsWith(query));
        if (match != null)
        {
            match.SetRawData(data);
        }
        else
        {
            throw new ArgumentException($"Could not find file ending with \"{query}\" in the archive.",
                nameof(query));
        }
    }

    public void RemoveFile(string uri)
    {
        var match = _files.FirstOrDefault(f => f.Uri.Equals(uri, StringComparison.OrdinalIgnoreCase));
        if (match != null)
        {
            _files.Remove(match);
        }
        else
        {
            throw new ArgumentException("Could not find file in the archive", nameof(uri));
        }
    }

    public void UpdateFileWithProcessedData(string uri, uint originalSize, byte[] data)
    {
        var match = _files.FirstOrDefault(f => f.Uri.Equals(uri, StringComparison.OrdinalIgnoreCase));
        if (match != null)
        {
            match.SetProcessedData(originalSize, data);
        }
        else
        {
            throw new FileNotFoundException("File was not found in the archive", uri);
        }
    }

    public void AddFileFromBackup(string uri, string relativePath, uint size, ArchiveFileFlag flags,
        byte localizationType, byte locale, ushort key, byte[] data)
    {
        var file = new ArchiveFile(uri, relativePath, size, flags, localizationType, locale, key);
        file.SetDataByFlags(data);
        _files.Add(file);
    }

    public void WriteToFile(string path)
    {
        var archiveStream = new MemoryStream();

        _logger.LogInformation("Packing archive...");

        if (Header.Flags.HasFlag(ArchiveHeaderFlags.Copyguard))
        {
            Header.Version |= ArchiveHeader.ProtectVersionHash;
        }

        _files = _files
            .OrderBy(f => f.Flags.HasFlag(ArchiveFileFlag.Autoload))
            .ThenBy(f => f.Uri.EndsWith(".autoext"))
            .ThenBy(f => f.Flags.HasFlag(ArchiveFileFlag.Reference))
            .ThenBy(f => f.TypeHash)
            .ThenBy(f => f.UriHash)
            .ToList();

        Header.UriListOffset = ArchiveHeader.Size +
                               Serialization.GetAlignment((uint)_files.Count * ArchiveFile.HeaderSize,
                                   PointerSize);

        var endOfUriList = SerializeUriList(out var uriListStream);
        archiveStream.Seek(Header.UriListOffset, SeekOrigin.Begin);
        uriListStream.CopyTo(archiveStream);

        Header.PathListOffset =
            Serialization.GetAlignment((uint)(Header.UriListOffset + endOfUriList), PointerSize);

        var endOfPathList = SerializePathList(out var pathListStream);
        archiveStream.Seek(Header.PathListOffset, SeekOrigin.Begin);
        pathListStream.CopyTo(archiveStream);

        Header.DataOffset = Serialization.GetAlignment(Header.PathListOffset + (uint)endOfPathList, BlockSize);

        var dataStream = SerializeFileData();
        archiveStream.Seek(Header.DataOffset, SeekOrigin.Begin);
        dataStream.CopyTo(archiveStream);

        var headerStream = SerializeHeader();
        archiveStream.Seek(0, SeekOrigin.Begin);
        headerStream.CopyTo(archiveStream);

        var fileHeaderStream = SerializeFileHeaders();
        archiveStream.Seek(ArchiveHeader.Size, SeekOrigin.Begin);
        fileHeaderStream.CopyTo(archiveStream);

        File.WriteAllBytes(path, archiveStream.ToArray());
    }

    private Stream SerializeHeader()
    {
        _logger.LogInformation("Serializing Archive Header");

        var stream = new MemoryStream();

        stream.Write(ArchiveHeader.DefaultTag);
        stream.Write(BitConverter.GetBytes(Header.Version));
        stream.Write(BitConverter.GetBytes((uint)_files.Count));
        stream.Write(BitConverter.GetBytes(BlockSize));
        stream.Write(BitConverter.GetBytes(ArchiveHeader.Size));
        stream.Write(BitConverter.GetBytes(Header.UriListOffset));
        stream.Write(BitConverter.GetBytes(Header.PathListOffset));
        stream.Write(BitConverter.GetBytes(Header.DataOffset));
        stream.Write(BitConverter.GetBytes((uint)Header.Flags));
        stream.Write(BitConverter.GetBytes(ArchiveHeader.DefaultChunkSize));

        // Archive hash must be zero before the whole header is hashed
        stream.Write(BitConverter.GetBytes((ulong)0));

        // Constant padding
        stream.Write(new byte[16]);

        Header.Hash = Cryptography.Base64Hash(stream.ToArray());

        stream = new MemoryStream();

        stream.Write(ArchiveHeader.DefaultTag);
        stream.Write(BitConverter.GetBytes(Header.Version));
        stream.Write(BitConverter.GetBytes((uint)_files.Count));
        stream.Write(BitConverter.GetBytes(BlockSize));
        stream.Write(BitConverter.GetBytes(ArchiveHeader.Size));
        stream.Write(BitConverter.GetBytes(Header.UriListOffset));
        stream.Write(BitConverter.GetBytes(Header.PathListOffset));
        stream.Write(BitConverter.GetBytes(Header.DataOffset));
        stream.Write(BitConverter.GetBytes((uint)Header.Flags));
        stream.Write(BitConverter.GetBytes(ArchiveHeader.DefaultChunkSize));
        stream.Write(BitConverter.GetBytes(Header.Hash));

        // Constant padding
        stream.Write(new byte[16]);

        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }

    private Stream SerializeFileHeaders()
    {
        _logger.LogInformation("Serializing File Headers");

        var stream = new MemoryStream();
        var hash = ArchiveFile.HeaderHash ^ Header.Hash;

        foreach (var file in _files)
        {
            var size = file.Size;
            var processedSize = file.ProcessedSize;
            var dataOffset = file.DataOffset;

            if (!file.Flags.HasFlag(ArchiveFileFlag.MaskProtected))
            {
                hash = Cryptography.MergeHashes(hash, file.UriAndTypeHash);
                size ^= (uint)(hash >> 32);
                processedSize ^= (uint)hash;
                hash = Cryptography.MergeHashes(hash, ~file.UriAndTypeHash);
                dataOffset ^= hash;
            }

            stream.Write(BitConverter.GetBytes(file.UriAndTypeHash));
            stream.Write(BitConverter.GetBytes(size));
            stream.Write(BitConverter.GetBytes(processedSize));
            stream.Write(BitConverter.GetBytes((uint)file.Flags));
            stream.Write(BitConverter.GetBytes(file.UriOffset));
            stream.Write(BitConverter.GetBytes(dataOffset));
            stream.Write(BitConverter.GetBytes(file.RelativePathOffset));
            stream.WriteByte(file.LocalizationType);
            stream.WriteByte(file.Locale);
            stream.Write(BitConverter.GetBytes(file.Key));
        }

        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }

    private int SerializeUriList(out Stream uriListStream)
    {
        _logger.LogInformation("Serializing File URIs");

        uriListStream = new MemoryStream();
        var currentUriOffset = 0;

        foreach (var file in _files)
        {
            var size = EncodeString(file.Uri, out var bytes);
            file.UriOffset = Header.UriListOffset + (uint)currentUriOffset;
            uriListStream.Seek(currentUriOffset, SeekOrigin.Begin);
            uriListStream.Write(bytes, 0, size);
            currentUriOffset += (int)Serialization.GetAlignment((uint)size, PointerSize);
        }

        uriListStream.Seek(0, SeekOrigin.Begin);
        return currentUriOffset;
    }

    private int SerializePathList(out Stream pathListStream)
    {
        _logger.LogInformation("Serializing File Paths");

        pathListStream = new MemoryStream();
        var currentPathOffset = 0;

        foreach (var file in _files)
        {
            var size = EncodeString(file.RelativePath, out var bytes);
            file.RelativePathOffset = Header.PathListOffset + (uint)currentPathOffset;
            pathListStream.Seek(currentPathOffset, SeekOrigin.Begin);
            pathListStream.Write(bytes, 0, size);
            currentPathOffset += (int)Serialization.GetAlignment((uint)size, PointerSize);
        }

        pathListStream.Seek(0, SeekOrigin.Begin);
        return currentPathOffset;
    }

    private Stream SerializeFileData()
    {
        _logger.LogInformation("Serializing File Data");

        var stream = new MemoryStream();
        var rng = new Random((int)Header.Hash);
        var currentDataOffset = 0L;

        foreach (var file in _files)
        {
            if (file.Key == 0 && Header.IsProtectedArchive)
            {
                var hashCode = file.Uri.GetHashCode();
                file.Key = (ushort)((hashCode >> 16) ^ hashCode);
                if (file.Key == 0)
                {
                    file.Key = 57005;
                }
            }

            if (!file.Flags.HasFlag(ArchiveFileFlag.Compressed) && !file.Flags.HasFlag(ArchiveFileFlag.Encrypted))
            {
                file.Key = 0;
            }

            file.DataOffset = Header.DataOffset + (uint)currentDataOffset;

            var fileData = file.GetDataForExport();
            stream.Write(fileData, 0, fileData.Length);

            var finalSize = Serialization.GetAlignment(file.ProcessedSize, BlockSize);
            var paddingSize = finalSize - file.ProcessedSize;
            var padding = new byte[paddingSize];
            rng.NextBytes(padding);
            stream.Write(padding, 0, (int)paddingSize);

            currentDataOffset += finalSize;
        }

        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }

    private int EncodeString(string value, out byte[] bytes)
    {
        var stringBufferSize = value.Length + 1 > 256 ? value.Length + 1 : 256;

        var stringBuffer = new char[stringBufferSize];
        bytes = new byte[stringBufferSize * 4];

        uint i;
        for (i = 0; i < value.Length; ++i)
        {
            stringBuffer[i] = value[(int)i];
        }

        stringBuffer[i] = char.MinValue;

        return Encoding.UTF8.GetEncoder().GetBytes(stringBuffer, 0, value.Length, bytes, 0, true);
    }
}