﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using DirectXTexNet;
using Flagrum.Core.Gfxbin.Btex;

namespace Flagrum.Web.Services;

public class TextureConverter
{
    public byte[] ProcessEarcModThumbnail(byte[] data)
    {
        try
        {
            var pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned);
            var pointer = pinnedData.AddrOfPinnedObject();

            var image = TexHelper.Instance.LoadFromWICMemory(pointer, data.Length, WIC_FLAGS.NONE);
            var metadata = image.GetMetadata();

            if (metadata.Format != DXGI_FORMAT.R8G8B8A8_UNORM)
            {
                var filter = TexHelper.Instance.IsSRGB(metadata.Format)
                    ? TEX_FILTER_FLAGS.SRGB
                    : TEX_FILTER_FLAGS.DEFAULT;
                image = image.Convert(DXGI_FORMAT.R8G8B8A8_UNORM, filter, 0.5f);
            }

            // Resize to 326x170 without stretching
            const int desiredWidth = 326;
            const int desiredHeight = 170;

            if (metadata.Width != desiredWidth || metadata.Height != desiredHeight)
            {
                var aspectRatioHeight = metadata.Height / (double)metadata.Width;
                var aspectRatioWidth = metadata.Width / (double)metadata.Height;

                var ratioedWidth = (int)(desiredHeight * aspectRatioWidth);
                var ratioedHeight = (int)(desiredWidth * aspectRatioHeight);

                var differenceWidth = Math.Abs(metadata.Width - ratioedWidth);
                var differenceHeight = Math.Abs(metadata.Height - ratioedHeight);

                int newWidth;
                int newHeight;

                if (differenceWidth < differenceHeight && ratioedWidth >= desiredWidth)
                {
                    newWidth = ratioedWidth;
                    newHeight = desiredHeight;
                }
                else
                {
                    newHeight = ratioedHeight;
                    newWidth = desiredWidth;
                }

                // Resize the image to the new size
                image = image.Resize(newWidth, newHeight, TEX_FILTER_FLAGS.CUBIC);

                // Truncate the resized image to the desired frame
                metadata = image.GetMetadata();
                var destinationImage =
                    TexHelper.Instance.Initialize2D(DXGI_FORMAT.R8G8B8A8_UNORM, desiredWidth, desiredHeight, 1, 1,
                        CP_FLAGS.NONE);
                var xOffset = Math.Abs((desiredWidth - metadata.Width) / 2);
                var yOffset = Math.Abs((desiredHeight - metadata.Height) / 2);
                TexHelper.Instance.CopyRectangle(image.GetImage(0), xOffset, yOffset, desiredWidth, desiredHeight,
                    destinationImage.GetImage(0), TEX_FILTER_FLAGS.DEFAULT, 0, 0);
                image = destinationImage;
            }

            using var jpgStream = image.SaveToJPGMemory(0, 1.0f);
            using var stream = new MemoryStream();
            jpgStream.CopyTo(stream);
            return stream.ToArray();
        }
        catch
        {
            return data;
        }
    }

    public byte[] ConvertPreview(string name, byte[] data, out byte[] jpeg)
    {
        var pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned);
        var pointer = pinnedData.AddrOfPinnedObject();

        var image = TexHelper.Instance.LoadFromWICMemory(pointer, data.Length, WIC_FLAGS.NONE);
        var metadata = image.GetMetadata();

        if (metadata.Format != DXGI_FORMAT.R8G8B8A8_UNORM)
        {
            var filter = TexHelper.Instance.IsSRGB(metadata.Format) ? TEX_FILTER_FLAGS.SRGB : TEX_FILTER_FLAGS.DEFAULT;
            image = image.Convert(DXGI_FORMAT.R8G8B8A8_UNORM, filter, 0.5f);
        }

        if (!(metadata.Width == 600 && metadata.Height == 600))
        {
            // Resize to the mandatory 600x600 without stretching
            if (metadata.Width > metadata.Height)
            {
                var aspectRatio = metadata.Height / (double)metadata.Width;
                var height = (int)(600 * aspectRatio);
                image = image.Resize(600, height, TEX_FILTER_FLAGS.CUBIC);
            }
            else if (metadata.Height > metadata.Width)
            {
                var aspectRatio = metadata.Width / (double)metadata.Height;
                var width = (int)(600 * aspectRatio);
                image = image.Resize(width, 600, TEX_FILTER_FLAGS.CUBIC);
            }
            else
            {
                image = image.Resize(600, 600, TEX_FILTER_FLAGS.CUBIC);
            }

            metadata = image.GetMetadata();

            // Add black bars if image isn't square
            if (metadata.Width != metadata.Height)
            {
                var destinationImage =
                    TexHelper.Instance.Initialize2D(DXGI_FORMAT.R8G8B8A8_UNORM, 600, 600, 1, 1, CP_FLAGS.NONE);
                var xOffset = (600 - metadata.Width) / 2;
                var yOffset = (600 - metadata.Height) / 2;
                TexHelper.Instance.CopyRectangle(image.GetImage(0), 0, 0, metadata.Width, metadata.Height,
                    destinationImage.GetImage(0), TEX_FILTER_FLAGS.DEFAULT, xOffset, yOffset);
                image = destinationImage;
            }
        }

        // Ensure image is within the size limit for the Steam upload
        var quality = 1.0f;

        while (true)
        {
            using var jpgStream = image.SaveToJPGMemory(0, quality);
            if (jpgStream.Length <= 953673)
            {
                using var stream = new MemoryStream();
                jpgStream.CopyTo(stream);
                jpeg = stream.ToArray();
                break;
            }

            quality -= 0.05f;
        }

        image = image.Compress(DXGI_FORMAT.BC1_UNORM, TEX_COMPRESS_FLAGS.SRGB_OUT | TEX_COMPRESS_FLAGS.PARALLEL, 0.5f);

        pinnedData.Free();

        return BuildBtex(TextureType.Preview, name, image);
    }

    public byte[] ConvertThumbnail(string name, byte[] data)
    {
        var pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned);
        var pointer = pinnedData.AddrOfPinnedObject();

        var image = TexHelper.Instance.LoadFromWICMemory(pointer, data.Length, WIC_FLAGS.NONE);

        var metadata = image.GetMetadata();
        if (!(metadata.Width == 168 && metadata.Height == 242))
        {
            image = image.Resize(168, 242, TEX_FILTER_FLAGS.CUBIC);
        }

        image = image.GenerateMipMaps(TEX_FILTER_FLAGS.CUBIC, 0);

        // Have to do some kind of conversion to force the janky SRGB out conversion
        // Which bleaches the image to compensate for SE's jank
        // DirectXTex throws a fit if converting to the same format, so arbitrarily picked R16G16B16A16_UNORM
        image = image.Convert(DXGI_FORMAT.R16G16B16A16_UNORM, TEX_FILTER_FLAGS.SRGB_OUT, 0.5f);

        // Then need to convert back to the desired format
        image = image.Convert(DXGI_FORMAT.R8G8B8A8_UNORM, TEX_FILTER_FLAGS.DEFAULT, 0.5f);

        pinnedData.Free();

        var result = BuildBtex(TextureType.Thumbnail, name, image);
        return result;
    }

    public byte[] ToBtex(string name, string extension, TextureType type, byte[] data)
    {
        return extension.ToLower() switch
        {
            "tga" => ConvertTarga(type, name, data),
            "dds" => ConvertDds(type, name, data),
            "btex" => data,
            _ => ConvertWic(type, name, data)
        };
    }

    public byte[] BtexToDds(byte[] btex)
    {
        var dds = BtexConverter.BtexToDds(btex);

        var pinnedData = GCHandle.Alloc(dds, GCHandleType.Pinned);
        var pointer = pinnedData.AddrOfPinnedObject();

        var image = TexHelper.Instance.LoadFromDDSMemory(pointer, dds.Length, DDS_FLAGS.NONE);

        pinnedData.Free();

        using var stream = new MemoryStream();
        using var ddsStream = image.SaveToDDSMemory(DDS_FLAGS.NONE);
        ddsStream.CopyTo(stream);
        return stream.ToArray();
    }

    public byte[] BtexToJpg(byte[] btex)
    {
        var image = BtexToScratchImage(btex);
        using var stream = new MemoryStream();
        using var jpgStream = image.SaveToJPGMemory(0, 1.0f);
        jpgStream.CopyTo(stream);
        return stream.ToArray();
    }

    public byte[] BtexToPng(byte[] btex)
    {
        var image = BtexToScratchImage(btex);
        using var stream = new MemoryStream();
        using var pngStream =
            image.SaveToWICMemory(0, WIC_FLAGS.FORCE_SRGB, TexHelper.Instance.GetWICCodec(WICCodecs.PNG));
        pngStream.CopyTo(stream);
        return stream.ToArray();
    }

    public byte[] BtexToTga(byte[] btex)
    {
        var image = BtexToScratchImage(btex);
        using var stream = new MemoryStream();
        using var tgaStream = image.SaveToTGAMemory(0);
        tgaStream.CopyTo(stream);
        return stream.ToArray();
    }

    private ScratchImage BtexToScratchImage(byte[] btex)
    {
        var dds = BtexConverter.BtexToDds(btex);

        var pinnedData = GCHandle.Alloc(dds, GCHandleType.Pinned);
        var pointer = pinnedData.AddrOfPinnedObject();

        var image = TexHelper.Instance.LoadFromDDSMemory(pointer, dds.Length, DDS_FLAGS.NONE);

        pinnedData.Free();

        // This is required to prevent an access violation exception from DirectXTexNet
        // When converting a large number of textures at once
        GC.Collect();

        var metadata = image.GetMetadata();
        // if (metadata.Format != DXGI_FORMAT.R8G8B8A8_UNORM)
        // {
        //     image = image.Decompress(DXGI_FORMAT.R8G8B8A8_UNORM);
        // }
        if (TexHelper.Instance.IsCompressed(metadata.Format))
        {
            image = image.Decompress(DXGI_FORMAT.R8G8B8A8_UNORM);
        }

        return image;
    }

    public byte[] TargaToDds(byte[] wicData, int mips, DXGI_FORMAT format)
    {
        var pinnedData = GCHandle.Alloc(wicData, GCHandleType.Pinned);
        var pointer = pinnedData.AddrOfPinnedObject();

        var image = TexHelper.Instance.LoadFromTGAMemory(pointer, wicData.Length);

        if (mips != 1)
        {
            image = image.GenerateMipMaps(TEX_FILTER_FLAGS.CUBIC, mips);
        }

        //image = image.Convert(format, TEX_FILTER_FLAGS.SRGB, 0.5f);
        //image = image.Compress(format, TEX_COMPRESS_FLAGS.SRGB | TEX_COMPRESS_FLAGS.PARALLEL,
        //    0.5f);

        pinnedData.Free();

        using var stream = new MemoryStream();
        using var ddsStream = image.SaveToDDSMemory(0, DDS_FLAGS.NONE);
        ddsStream.CopyTo(stream);
        return stream.ToArray();
    }

    private byte[] ConvertWic(TextureType type, string name, byte[] data)
    {
        var pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned);
        var pointer = pinnedData.AddrOfPinnedObject();

        var image = TexHelper.Instance.LoadFromWICMemory(pointer, data.Length, WIC_FLAGS.NONE);
        image = BuildDds(type, image);

        pinnedData.Free();
        return BuildBtex(type, name, image);
    }

    private byte[] ConvertTarga(TextureType type, string name, byte[] data)
    {
        var pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned);
        var pointer = pinnedData.AddrOfPinnedObject();

        var image = TexHelper.Instance.LoadFromTGAMemory(pointer, data.Length);
        image = BuildDds(type, image);

        pinnedData.Free();
        return BuildBtex(type, name, image);
    }

    private byte[] ConvertDds(TextureType type, string name, byte[] data)
    {
        var pinnedData = GCHandle.Alloc(data, GCHandleType.Pinned);
        var pointer = pinnedData.AddrOfPinnedObject();

        var image = TexHelper.Instance.LoadFromDDSMemory(pointer, data.Length, DDS_FLAGS.NONE);

        pinnedData.Free();
        return BuildBtex(type, name, image);
    }

    private ScratchImage BuildDds(TextureType type, ScratchImage image)
    {
        switch (type)
        {
            case TextureType.Normal:
                image = image.GenerateMipMaps(TEX_FILTER_FLAGS.CUBIC, 0);
                image = image.Compress(DXGI_FORMAT.BC5_UNORM, TEX_COMPRESS_FLAGS.SRGB | TEX_COMPRESS_FLAGS.PARALLEL,
                    0.5f);
                break;
            case TextureType.AmbientOcclusion or TextureType.Opacity:
                image = image.GenerateMipMaps(TEX_FILTER_FLAGS.CUBIC, 0);
                image = image.Compress(DXGI_FORMAT.BC4_UNORM, TEX_COMPRESS_FLAGS.SRGB | TEX_COMPRESS_FLAGS.PARALLEL,
                    0.5f);
                break;
            case TextureType.MenuSprites:
                var metadata = image.GetMetadata();
                if (metadata.Format != DXGI_FORMAT.B8G8R8A8_UNORM)
                {
                    image = image.Convert(DXGI_FORMAT.B8G8R8A8_UNORM, TEX_FILTER_FLAGS.SRGB, 0.5f);
                }

                break;
            default:
                image = image.GenerateMipMaps(TEX_FILTER_FLAGS.CUBIC, 0);
                image = image.Compress(DXGI_FORMAT.BC1_UNORM, TEX_COMPRESS_FLAGS.SRGB | TEX_COMPRESS_FLAGS.PARALLEL,
                    0.5f);
                break;
        }

        return image;
    }

    private byte[] BuildBtex(TextureType type, string name, ScratchImage image)
    {
        using var stream = new MemoryStream();
        using var ddsStream = image.SaveToDDSMemory(DDS_FLAGS.FORCE_DX10_EXT | DDS_FLAGS.FORCE_DX10_EXT_MISC2);
        ddsStream.CopyTo(stream);

        return BtexConverter.DdsToBtex(type, name, stream.ToArray());
    }
}