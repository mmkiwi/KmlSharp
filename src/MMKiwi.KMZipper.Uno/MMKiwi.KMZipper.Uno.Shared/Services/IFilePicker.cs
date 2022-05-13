using Windows.Storage;

namespace MMKiwi.KMZipper.Uno.Services;

public interface IFilePicker
{
    public Task<StorageFile?> OpenFileAsync(params ExtensionInfo[] extensions);
    public Task<StorageFile?> SaveFileAsync(params ExtensionInfo[] extensions);
    public Task<StorageFile?> OpenFolderAsync();
    public Task<IEnumerable<StorageFile>?> OpenFilesAsync(params ExtensionInfo[] extensions);
}

public sealed record ExtensionInfo
{
    public ExtensionInfo(string description, params string[] extensions)
    {
        Description = description;
        Extensions = extensions.Select(ext => ext.TrimStart('*'));
    }

    public string Description { get; }
    public IEnumerable<string> Extensions { get; }
}