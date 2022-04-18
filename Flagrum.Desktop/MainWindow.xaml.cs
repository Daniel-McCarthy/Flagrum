﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using Flagrum.Desktop.Services;
using Flagrum.Web.Persistence;
using Flagrum.Web.Services;
using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Web.WebView2.Core;
using Squirrel;

namespace Flagrum.Desktop;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private readonly string flagrumDirectory;
    private readonly string logFile;
    
    public string HostPageUri { get; } = "wwwroot/index.html";

    private bool _hasWebView2Runtime;

    public bool HasWebView2Runtime
    {
        get => _hasWebView2Runtime;
        set
        {
            _hasWebView2Runtime = value;
            OnPropertyChanged(nameof(HasWebView2Runtime));
        }
    }

    public string SpinnerPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\loading.gif");

    public MainWindow()
    {
        var screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
        var bounds = screen.Bounds;
        var width = 1680;
        var height = 1024;

        if (width > (bounds.Width * 0.95) || height > (bounds.Height * 0.9))
        {
            width = (int)(bounds.Width * 0.95);
            height = (int)(bounds.Height * 0.9);

            var dpiXProperty =
                typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
            var dpiYProperty =
                typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static);

            var dpiX = (int)dpiXProperty.GetValue(null, null);
            var dpiY = (int)dpiYProperty.GetValue(null, null);

            Width = width / (dpiX / 96.0);
            Height = height / (dpiY / 96.0);
        }
        else
        {
            Width = width;
            Height = height;
        }

        flagrumDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Flagrum";
        if (!Directory.Exists(flagrumDirectory))
        {
            Directory.CreateDirectory(flagrumDirectory);
        }

        logFile = $"{flagrumDirectory}\\Log.txt";

        if (File.Exists(logFile))
        {
            File.Delete(logFile);
        }

        File.Create(logFile);

        try
        {
            CoreWebView2Environment.GetAvailableBrowserVersionString();
            HasWebView2Runtime = true;
        }
        catch (WebView2RuntimeNotFoundException e)
        {
            InstallWebView2Runtime();
        }
        
        // Migrate the database
        using var context = new FlagrumDbContext();
        context.Database.MigrateAsync().Wait();

        var services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            builder.AddConfiguration();
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, ConsoleLoggerProvider>());
            LoggerProviderOptions.RegisterProviderOptions<ConsoleLoggerConfiguration, ConsoleLoggerProvider>(
                builder.Services);
            Action<ConsoleLoggerConfiguration> configure = c => { };
            builder.Services.Configure(configure);
        });

        services.AddScoped<IWpfService, WpfService>(services => new WpfService(this));
        services.AddBlazorWebView();
        services.AddFlagrum();
        Resources.Add("services", services.BuildServiceProvider());

        InitializeComponent();
    }

    private async void InstallWebView2Runtime()
    {
        var start = new ProcessStartInfo
        {
            FileName = "MicrosoftEdgeWebview2Setup.exe",
            Arguments = "/silent /install",
            WindowStyle = ProcessWindowStyle.Hidden
        };

        var process = new Process {StartInfo = start};
        process.Start();
        await process.WaitForExitAsync();
        await Dispatcher.InvokeAsync(() => HasWebView2Runtime = true);
    }

    private void Minimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void Maximize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MainBlazorWebView_OnInitialized(object? sender, EventArgs e)
    {
        if (sender == null)
        {
            return;
        }

        var webView = (BlazorWebView)sender;
        webView.WebView.DefaultBackgroundColor = ColorTranslator.FromHtml("#181512");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        Task.Run(async () =>
        {
            try
            {
                using (var manager = UpdateManager.GitHubUpdateManager("https://github.com/Kizari/Flagrum").Result)
                {
                    await manager.UpdateApp();
                }
            }
            catch
            {
                
            }
        });
    }
}