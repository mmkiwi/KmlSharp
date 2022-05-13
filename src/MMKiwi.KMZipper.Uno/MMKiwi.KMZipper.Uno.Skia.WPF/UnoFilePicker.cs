using Microsoft.UI.Xaml;

using System;
using System.Collections.Generic;
using System.Text;

using Windows.Storage;
using Windows.Storage.Pickers;

namespace MMKiwi.KMZipper.Uno.Services;

internal class WpfFilePicker : IFilePicker
{
    public async Task<StorageFile?> OpenFileAsync(params ExtensionInfo[] extensions)
    {
        var filePicker = new FileOpenPicker();

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

        // Use file picker like normal!
        foreach (ExtensionInfo? extInfo in extensions)
            filePicker.FileTypeChoices.Add(extInfo.Description, extInfo.Extensions.ToList());
        StorageFile file = await filePicker.PickSaveFileAsync();
        return file;
    }
}
