﻿namespace Flagrum.Web.Features.AssetExplorer.Data;

public enum ExplorerItemType
{
    Unspecified,
    Unsupported,
    Directory,
    Material,
    Texture,
    Model,
    Xml,
    Text
}

public class ExplorerItem
{
    public string Name { get; set; }
    public string Path { get; set; }
    public ExplorerItemType Type { get; set; }
    public bool IsExpandable { get; set; }
    public bool IsExpanded { get; set; }
    public bool IsSelected { get; set; }
}