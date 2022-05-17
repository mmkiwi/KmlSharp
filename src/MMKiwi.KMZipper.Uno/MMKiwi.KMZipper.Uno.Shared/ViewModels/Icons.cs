// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Microsoft.UI.Xaml.Media.Imaging;

using Windows.Storage;

namespace MMKiwi.KMZipper.Uno.ViewModels.Icons;

public interface IIconInfo
{
    BitmapImage? Image { get; }
}
public sealed class ImageIconInfo : IIconInfo
{
    private StorageFile? _file;

    public ImageIconInfo() { }
    public ImageIconInfo(StorageFile file)
    {
        File = file;
    }

    public BitmapImage? Image { get; private set; }
    public StorageFile? File
    {
        get => _file;
        set
        {
            _file = value;
            Windows.Foundation.IAsyncOperation<Windows.Storage.Streams.IRandomAccessStream>? streamTask = value?.OpenAsync(FileAccessMode.Read);
            Windows.Storage.Streams.IRandomAccessStream? stream = streamTask?.GetResults();

            try
            {
                if (stream != null)
                {
                    Image = new BitmapImage();
                    Image.SetSource(stream);
                }
            }
            finally
            {
                stream?.Dispose();
            }
        }
    }
}

public sealed class UriIconInfo : IIconInfo
{
    private Uri? _uri;

    public UriIconInfo()
    {

    }

    public UriIconInfo(Uri uri)
    {
        Uri = uri;
    }

    public Uri? Uri
    {
        get => _uri;
        set
        {
            _uri = value;
            Image = new BitmapImage(_uri);
        }
    }

    public BitmapImage? Image { get; private set; }
}