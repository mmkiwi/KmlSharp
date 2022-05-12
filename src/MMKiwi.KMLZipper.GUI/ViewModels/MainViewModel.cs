using System;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

using MMKiwi.KMLZipper.Core.Services;
using MMKiwi.KMLZipper.GUI.Contracts.Services;
using MMKiwi.KMLZipper.GUI.Core.Models;
using MMKiwi.KMLZipper.GUI.ViewModels.Icons;

using Windows.Graphics.Imaging;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

namespace MMKiwi.KMLZipper.GUI.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    public MainViewModel()
    {
        PhotoList.CollectionChanged += (c, i) =>
        {
            OnPropertyChanged(nameof(IsValid));
            ProcessCommand.NotifyCanExecuteChanged();
        };
    }

    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsValid))]
    [AlsoNotifyCanExecuteFor(nameof(ProcessCommand))]
    private string name = "";

    [ObservableProperty]
    private bool rotateIcons = true;

    public ObservableCollection<StorageFile> PhotoList { get; } = new();
    public ObservableCollection<IIconInfo> IconList { get; } = new();

    [ObservableProperty]
    [AlsoNotifyCanExecuteFor(nameof(RemoveImageCommand))]
    public StorageFile? _selectedPhoto;

    [ObservableProperty]
    private IIconInfo? selectedIcon;

    [ICommand(AllowConcurrentExecutions = false)]
    public async Task CustomIcon()
    {
        IFilePicker Picker = App.GetService<IFilePicker>() ?? throw new InvalidOperationException($"Could not get {nameof(IFilePicker)}");
        StorageFile? file = await Picker.OpenFileAsync(new ExtensionInfo("Icon Files", ".png"));
        if (file != null)
        {
            IconList.Add(new ImageIconInfo
            {
                File = file
            });
        }
    }

    [ICommand(AllowConcurrentExecutions = false)]
    public async Task AddImage()
    {
        IFilePicker Picker = App.GetService<IFilePicker>() ?? throw new InvalidOperationException($"Could not get {nameof(IFilePicker)}");
        IEnumerable<StorageFile>? files = await Picker.OpenFilesAsync(new ExtensionInfo("Image Files", ".png", ".jpg", ".jpeg", ".tiff", ".tif"));
        if (files != null)
        {
            foreach (StorageFile? file in files)
                if (file != null)
                {
                    PhotoList.Add(file);
                }
        }
    }

    [MemberNotNullWhen(true, nameof(SelectedIcon))]
    [MemberNotNullWhen(true, nameof(Name))]
    public bool IsValid => !string.IsNullOrWhiteSpace(Name) && PhotoList.Any();

    private async Task DownloadIcon(StorageFolder tempFolder, CancellationToken ct = default)
    {
        var iconFile = await tempFolder.CreateFileAsync("icon.png");
        if (SelectedIcon is ImageIconInfo imageIcon && imageIcon.File != null)
        {
            await imageIcon.File.CopyAndReplaceAsync(iconFile).AsTask();
        }
        else if (SelectedIcon is UriIconInfo uriIcon && uriIcon.Uri != null)
        {

            HttpClient client = new();

            HttpResponseMessage response = await client.GetAsync(uriIcon.Uri.ToString(), ct);

            _ = response.EnsureSuccessStatusCode();
            using Stream iconStream = await iconFile.OpenStreamForWriteAsync();
            await response.Content.CopyToAsync(iconStream, ct);

            // Attach progress and completion handlers.
        }
        else
        {
            throw new NotImplementedException("Unknown icon type");
        }
    }

    [ICommand(AllowConcurrentExecutions = false, CanExecute = nameof(IsValid), IncludeCancelCommand = true)]
    public async Task Process(CancellationToken ct = default)
    {
        if (IsValid == false) return;
        IFilePicker Picker = App.GetService<IFilePicker>() ?? throw new InvalidOperationException($"Could not get {nameof(IFilePicker)}");
        StorageFile? kmzFile = await Picker.SaveFileAsync(new ExtensionInfo("KMZ Files", ".kmz"));
        if (kmzFile == null)
        {
            return;
        }

        List<Task<TranformationItem>> photoTasks = new();
        StorageFolder userTemp = await StorageFolder.GetFolderFromPathAsync(Path.GetTempPath());
        StorageFolder tempFolder = await userTemp.CreateFolderAsync(Path.GetRandomFileName());
        StorageFolder tempImgFolder = await tempFolder.CreateFolderAsync("images");
        try
        {
            var downloadTask = DownloadIcon(tempFolder, ct);

            foreach (StorageFile photo in PhotoList)
            {
                photoTasks.Add(ProcessPhoto(tempImgFolder, photo));
            }

            StorageFile kmlFile = await tempFolder.CreateFileAsync("document.kml");

            TranformationItem[] photoInfo = await Task.WhenAll(photoTasks);
            TranformationProperties properties = new(Name, photoInfo.ToImmutableArray(), RotateIcons, "icon.png");
            TransformService svc = new(properties);

            await FileIO.WriteTextAsync(kmlFile, svc.Tranform(), UnicodeEncoding.Utf8);

            await downloadTask;

            string tempKmzPath = Path.Combine(userTemp.Path, Path.GetRandomFileName() + ".kmz");
            try
            {
                await Task.Run(() => ZipFile.CreateFromDirectory(tempFolder.Path, tempKmzPath), ct);
                StorageFile tempKmzFile = await StorageFile.GetFileFromPathAsync(tempKmzPath);
                await tempKmzFile.CopyAndReplaceAsync(kmzFile);

            }
            finally
            {
                if (File.Exists(tempKmzPath))
                    await (await StorageFile.GetFileFromPathAsync(tempKmzPath)).DeleteAsync();
            }
        }
        finally
        {
            await tempFolder.DeleteAsync();
        }
    }

    private static async Task<TranformationItem> ProcessPhoto(StorageFolder tempImgFolder, StorageFile photo)
    {
        IRandomAccessStream photoStream = await photo.OpenAsync(FileAccessMode.Read);

        const string bearingKey = "System.GPS.DestBearing";

        ImageProperties props = await photo.Properties.GetImagePropertiesAsync();
        var extraProps = await props.RetrievePropertiesAsync(new List<string> { bearingKey });
        double? bearing = extraProps.ContainsKey(bearingKey) ? (double)extraProps[bearingKey] : null;

        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(photoStream);

        if (decoder.PixelWidth > 480)
        {
            var outPhoto = await tempImgFolder.CreateFileAsync(photo.Name, CreationCollisionOption.GenerateUniqueName);

            using var outStream = await outPhoto.OpenAsync(FileAccessMode.ReadWrite);
            BitmapEncoder encoder = await BitmapEncoder.CreateForTranscodingAsync(outStream, decoder);

            double scaleRatio = (double)480 / decoder.PixelWidth;


            uint aspectHeight = (uint)Math.Floor(decoder.PixelHeight * scaleRatio);
            uint aspectWidth = (uint)Math.Floor(decoder.PixelWidth * scaleRatio);

            encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Cubic;

            encoder.BitmapTransform.ScaledHeight = aspectHeight;
            encoder.BitmapTransform.ScaledWidth = aspectWidth;
            encoder.BitmapTransform.Rotation = props.Orientation switch
            {
                PhotoOrientation.Rotate180 => BitmapRotation.Clockwise180Degrees,
                PhotoOrientation.Rotate270 => BitmapRotation.Clockwise270Degrees,
                PhotoOrientation.Rotate90 => BitmapRotation.Clockwise90Degrees,
                _ => BitmapRotation.None
            };

            await encoder.FlushAsync();
        }
        else
        {
            await photo.CopyAsync(tempImgFolder);
        }

        return new TranformationItem(photo.Name, photo.Path, props.Longitude ?? 0, props.Latitude ?? 0, bearing ?? 0, new Dictionary<string, string>
                {
                    { "Date Taken", props.DateTaken.ToString("mmm d, yyyy h:mm tt") ?? "Unknown"},
                    { "Longitude", props.Longitude?.ToString() ?? "Unknown"},
                    { "Latitude", props.Latitude?.ToString() ?? "Unknown"},
                    { "Direction", bearing?.ToString() ?? "Unknown"}
                });
    }

    public bool CanRemoveImage => SelectedPhoto != null;

    [ICommand(CanExecute = nameof(CanRemoveImage))]
    public void RemoveImage()
    {
        if (SelectedPhoto != null)
        {
            PhotoList.Remove(SelectedPhoto);
        }
    }
}
