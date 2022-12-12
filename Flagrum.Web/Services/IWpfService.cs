﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flagrum.Web.Features.AssetExplorer.Data;
using Flagrum.Web.Persistence;

namespace Flagrum.Web.Services;

public interface IWpfService
{
    Task OpenFileDialogAsync(string filter, Action<string> onFileSelected);
    Task OpenFolderDialogAsync(string initialDirectory, Action<string> onFolderSelected);
    Task OpenSaveFileDialogAsync(string defaultName, string filter, Action<string> onFileSelected);
    Version GetVersion();
    void ShowWindowsNotification(string message);
    void Restart();
    void Resize3DViewport(int left, int top, int width, int height);
    void Set3DViewportVisibility(bool isVisible);
    Task ChangeModel(byte[] gmdl, byte[] gpubin, AssetExplorerView view, string? inputPath);

    void Update3DViewportBindings(string rotateModifierKey, string rotateMouseAction, string panModifierKey,
        string panMouseAction);

    IEnumerable<string> GetModifierKeys();
    IEnumerable<string> GetMouseActions();
    string GetFmodPath();
    void ClearFmodPath();
}