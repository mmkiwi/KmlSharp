using Microsoft.UI.Xaml;

using Windows.Storage;
using Windows.Storage.Pickers;
using Microsoft.Win32;
using MMKiwi.KMLZipper.Core.Contracts.Services;
using MMKiwi.KMLZipper.GUI.Contracts.Services;

namespace MMKiwi.KMLZipper.GUI.Services;

internal class UwpFilePicker : IFilePicker
{
    public UwpFilePicker(Window mainWindow) => MainWindow = mainWindow;

    public Window MainWindow { get; }

    public async Task<StorageFile?> OpenFileAsync(params ExtensionInfo[] extensions)
    {
        var filePicker = new FileOpenPicker();

        // Get the current window's HWND by passing in the Window object
        IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(MainWindow);

        // Associate the HWND with the file picker
        WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

        // Use file picker like normal!
        foreach (ExtensionInfo extInfo in extensions)
            foreach (string extension in extInfo.Extensions)
                filePicker.FileTypeFilter.Add(extension);
        StorageFile? file = await filePicker.PickSingleFileAsync();
        return file;
    }

    public async Task<IEnumerable<StorageFile>?> OpenFilesAsync(params ExtensionInfo[] extensions)
    {
        var filePicker = new FileOpenPicker();

        // Get the current window's HWND by passing in the Window object
        IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(MainWindow);

        // Associate the HWND with the file picker
        WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

        // Use file picker like normal!
        foreach (ExtensionInfo extInfo in extensions)
            foreach (string extension in extInfo.Extensions)
                filePicker.FileTypeFilter.Add(extension);
        IReadOnlyList<StorageFile> files = await filePicker.PickMultipleFilesAsync();
        return files;
    }
    public Task<StorageFile?> OpenFolderAsync() => throw new NotImplementedException();

    //BUGGY DO NOT USE
    public async Task<StorageFile?> SaveFileAsync(params ExtensionInfo[] extensions)
    {
        var filePicker = new FileSavePicker();

        // Get the current window's HWND by passing in the Window object
        IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(MainWindow);

        // Associate the HWND with the file picker
        WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

        // Use file picker like normal!
        foreach (ExtensionInfo? extInfo in extensions)
            filePicker.FileTypeChoices.Add(extInfo.Description, extInfo.Extensions.ToList());
        StorageFile file = await filePicker.PickSaveFileAsync();
        return file;
    }
}