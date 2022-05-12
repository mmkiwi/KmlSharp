using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

using MMKiwi.KMLZipper.GUI.Activation;
using MMKiwi.KMLZipper.GUI.Contracts.Services;
using MMKiwi.KMLZipper.Core.Contracts.Services;
using MMKiwi.KMLZipper.Core.Services;
using MMKiwi.KMLZipper.GUI.Helpers;
using MMKiwi.KMLZipper.GUI.Services;
using MMKiwi.KMLZipper.GUI.ViewModels;
using MMKiwi.KMLZipper.GUI.Views;
using UnhandledExceptionEventArgs = Microsoft.UI.Xaml.UnhandledExceptionEventArgs;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace MMKiwi.KMLZipper.GUI;

public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            _ = services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            _ = services.AddSingleton<IActivationService, ActivationService>();
            _ = services.AddSingleton<IPageService, PageService>();
            _ = services.AddSingleton<INavigationService, NavigationService>();

            // File Picker
            _ = services.AddSingleton<IFilePicker, UwpFilePicker>(p => new UwpFilePicker(MainWindow!));

            // Core Services
            _ = services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            _ = services.AddTransient<ProgressViewModel>();
            _ = services.AddTransient<ProgressPage>();
            _ = services.AddTransient<MainViewModel>();
            _ = services.AddTransient<MainPage>();

            // Configuration
        })
        .Build();

    public static T? GetService<T>()
        where T : class
        => _host.Services.GetService(typeof(T)) as T;

    public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized()};

    public App()
    {
        InitializeComponent();
        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        var Exception = e.Exception;
        new Window().Activate();
    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);
        var activationService = GetService<IActivationService>();
        if(activationService != null)
            await activationService.ActivateAsync(args);
    }
}
