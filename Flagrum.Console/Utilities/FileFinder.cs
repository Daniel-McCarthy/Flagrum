﻿using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Flagrum.Core.Archive;
using Newtonsoft.Json;

namespace Flagrum.Console.Utilities;

public class FileData
{
    public string Location { get; set; }
    public string ArchiveLocation { get; set; }
    public string Uri { get; set; }
    public string FileName { get; set; }
}

public class FileFinder
{
    private const string DataDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\FINAL FANTASY XV\datas";

    private readonly string _startDirectory;
    private string _fileName;
    private ConcurrentBag<FileData> _map;

    public FileFinder(string startDirectory)
    {
        _startDirectory = startDirectory;
    }

    public void GenerateMap()
    {
        System.Console.WriteLine("Started mapping...");
        var watch = Stopwatch.StartNew();

        _map = new ConcurrentBag<FileData>();
        MapDirectory(DataDirectory);
        Parallel.ForEach(Directory.EnumerateDirectories(DataDirectory), GenerateMapRecursively);

        watch.Stop();
        System.Console.WriteLine($"Mapping finished after {watch.ElapsedMilliseconds} milliseconds.");
        
        File.WriteAllText(@"C:\Modding\map.json", JsonConvert.SerializeObject(_map));
    }

    private void GenerateMapRecursively(string directory)
    {
        MapDirectory(directory);

        foreach (var subdirectory in Directory.EnumerateDirectories(directory))
        {
            GenerateMapRecursively(subdirectory);
        }
    }

    private void MapDirectory(string directory)
    {
        foreach (var file in Directory.EnumerateFiles(directory))
        {
            _map.Add(new FileData
            {
                FileName = file.Split('\\').Last(),
                Location = file
            });
            
            if (file.EndsWith(".earc"))
            {
                using var unpacker = new Unpacker(file);
                foreach (var archiveFile in unpacker.Files.Where(f => !f.Flags.HasFlag(ArchiveFileFlag.Reference)))
                {
                    _map.Add(new FileData
                    {
                        ArchiveLocation = file,
                        FileName = archiveFile.RelativePath.Split('\\', '/').Last(),
                        Location = file + "\\" + archiveFile.RelativePath,
                        Uri = archiveFile.Uri
                    });
                }
            }
        }
    }

    public void FindByFileName(string fileName)
    {
        System.Console.WriteLine("Starting search...");
        var watch = Stopwatch.StartNew();

        _fileName = fileName;
        var startDirectory = $"{DataDirectory}\\{_startDirectory}";
        foreach (var directory in Directory.EnumerateDirectories(startDirectory))
        {
            FindRecursively(directory);
        }

        watch.Stop();
        System.Console.WriteLine($"Search finished after {watch.ElapsedMilliseconds} milliseconds.");
    }

    private bool FindRecursively(string directory)
    {
        foreach (var file in Directory.EnumerateFiles(directory, "*.earc"))
        {
            using var unpacker = new Unpacker(file);
            var result = unpacker.GetUriByQuery(_fileName);
            if (result != null)
            {
                System.Console.WriteLine(result + " - " + file);
                return true;
            }
        }

        foreach (var subdirectory in Directory.EnumerateDirectories(directory))
        {
            if (FindRecursively(subdirectory))
            {
                return true;
            }
        }

        return false;
    }
}