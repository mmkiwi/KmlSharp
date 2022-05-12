using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;

namespace MMKiwi.KMZipper.GUI.ViewModels.Icons;

public interface IIconInfo
{
    BitmapImage? Image { get; }
}
public sealed class ImageIconInfo : IIconInfo
{
    private StorageFile? file;

    public ImageIconInfo() { }
    public ImageIconInfo(StorageFile file) => File = file;

    BitmapImage? _image;
    public BitmapImage? Image => _image;
    public StorageFile? File
    {
        get => file;
        set
        {
            file = value;
            var streamTask = value?.OpenAsync(FileAccessMode.Read);
            var stream = streamTask?.GetResults();
            
            try
            {
                if (stream != null)
                {
                    _image = new BitmapImage();
                    _image.SetSource(stream);
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
    private Uri? uri;

    public UriIconInfo()
    {

    }

    public UriIconInfo(Uri uri) => Uri = uri;

    public Uri? Uri
    {
        get => uri;
        set
        {
            uri = value;
            Image = new BitmapImage(uri);
        }
    }

    public BitmapImage? Image { get; private set; }
}