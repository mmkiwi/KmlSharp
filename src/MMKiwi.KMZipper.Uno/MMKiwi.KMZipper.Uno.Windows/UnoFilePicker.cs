// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Microsoft.UI.Xaml;

using MMKiwi.KMZipper.Uno.Services;

using Windows.Storage;
using Windows.Storage.Pickers;

namespace MMKiwi.KMZipper.Uno;

internal class UwpFilePicker : IFilePicker
{
    public UwpFilePicker(Window mainWindow)
    {
        MainWindow = mainWindow;
    }

    public Window MainWindow { get; }

    public async Task<StorageFile?> OpenFileAsync(params ExtensionInfo[] extensions)
    {
        FileOpenPicker? filePicker = new();

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
        FileOpenPicker? filePicker = new();

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
    public Task<StorageFile?> OpenFolderAsync()
    {
        throw new NotImplementedException();
    }

    //BUGGY DO NOT USE
    public async Task<StorageFile?> SaveFileAsync(params ExtensionInfo[] extensions)
    {
        FileSavePicker? filePicker = new();

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
