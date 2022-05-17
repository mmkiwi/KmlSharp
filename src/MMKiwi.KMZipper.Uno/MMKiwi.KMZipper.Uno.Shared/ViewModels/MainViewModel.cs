// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MMKiwi.KMZipper.Core.Models;
using MMKiwi.KMZipper.Core.Services;
using MMKiwi.KMZipper.Uno.Extensions;
using MMKiwi.KMZipper.Uno.Services;
using MMKiwi.KMZipper.Uno.ViewModels.Icons;

using NodaTime;
using NodaTime.Text;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using SixLabors.ImageSharp.Processing;

using Windows.Storage;
using Windows.Storage.Streams;

namespace MMKiwi.KMZipper.Uno.ViewModels;

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
    private string _name = "";

    [ObservableProperty]
    private bool _rotateIcons = true;

    public ObservableCollection<StorageFile> PhotoList { get; } = new();
    public ObservableCollection<IIconInfo> IconList { get; } = new();

    [ObservableProperty]
    [AlsoNotifyCanExecuteFor(nameof(RemoveImageCommand))]
    private StorageFile? _selectedPhoto;

    [ObservableProperty]
    private IIconInfo? _selectedIcon;

    [ICommand(AllowConcurrentExecutions = false)]
    public async Task CustomIcon()
    {
        IFilePicker picker = App.GetService<IFilePicker>() ?? throw new InvalidOperationException($"Could not get {nameof(IFilePicker)}");
        StorageFile? file = await picker.OpenFileAsync(new ExtensionInfo("Icon Files", ".png"));
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
        IFilePicker picker = App.GetService<IFilePicker>() ?? throw new InvalidOperationException($"Could not get {nameof(IFilePicker)}");
        IEnumerable<StorageFile>? files = await picker.OpenFilesAsync(new ExtensionInfo("Image Files", ".png", ".jpg", ".jpeg", ".tiff", ".tif"));
        if (files != null)
        {
            foreach (StorageFile? file in files)
            {
                if (file != null)
                {
                    PhotoList.Add(file);
                }
            }
        }
    }
#if WINDOWS10_0_17763_0_OR_GREATER
    [MemberNotNullWhen(true, nameof(SelectedIcon))]
    [MemberNotNullWhen(true, nameof(Name))]
#endif
    public bool IsValid => !string.IsNullOrWhiteSpace(Name) && PhotoList.Any();

    private async Task DownloadIcon(StorageFolder tempFolder, CancellationToken ct = default)
    {
        StorageFile? iconFile = await tempFolder.CreateFileAsync("icon.png");
        if (SelectedIcon is ImageIconInfo imageIcon && imageIcon.File != null)
        {
            await imageIcon.File.CopyAndReplaceAsync(iconFile).AsTask(cancellationToken: ct);
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
        IFilePicker picker = App.GetService<IFilePicker>() ?? throw new InvalidOperationException($"Could not get {nameof(IFilePicker)}");
        StorageFile? kmzFile = await picker.SaveFileAsync(new ExtensionInfo("KMZ Files", ".kmz"));
        if (kmzFile == null)
        {
            return;
        }

        //List<TranformationItem> photoInfo = new();
        ConcurrentBag<KmzPhotoInfo> photoInfo = new();
        StorageFolder userTemp = await StorageFolder.GetFolderFromPathAsync(Path.GetTempPath());
        StorageFolder tempFolder = await userTemp.CreateFolderAsync(Path.GetRandomFileName());
        StorageFolder tempImgFolder = await tempFolder.CreateFolderAsync("images");
        try
        {
            Task? downloadTask = DownloadIcon(tempFolder, ct);

            await Parallel.ForEachAsync(PhotoList, new ParallelOptions
            {
                CancellationToken = ct,
                MaxDegreeOfParallelism = 4
            }, async (photo, ct) => photoInfo.Add(await ProcessPhoto(tempImgFolder, photo, ct)));


            StorageFile kmlFile = await tempFolder.CreateFileAsync("document.kml");

            KmzSaveProperties properties = new(Name, photoInfo.ToImmutableArray(), RotateIcons, "icon.png");
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

    private static async Task<KmzPhotoInfo> ProcessPhoto(StorageFolder tempImgFolder, StorageFile photo, CancellationToken ct)
    {
        try
        {
            Stream photoStream = await photo.OpenStreamForReadAsync();


            (Image Image, IImageFormat Format) resTuple = await Image.LoadWithFormatAsync(photoStream, ct);
            using Image? image = resTuple.Image;
            IExifValue<ushort>? orientation = image.Metadata.ExifProfile?.GetValue(ExifTag.Orientation);
            IExifValue<Rational[]>? latitudeRat = image.Metadata.ExifProfile?.GetValue(ExifTag.GPSLatitude);
            IExifValue<string>? latitudeRef = image.Metadata.ExifProfile?.GetValue(ExifTag.GPSLatitudeRef);
            IExifValue<Rational[]>? longitudeRat = image.Metadata.ExifProfile?.GetValue(ExifTag.GPSLongitude);
            IExifValue<string>? longitudeRef = image.Metadata.ExifProfile?.GetValue(ExifTag.GPSLongitudeRef);
            IExifValue<Rational>? bearing = image.Metadata.ExifProfile?.GetValue(ExifTag.GPSDestBearing);
            IExifValue<string>? dateTakenTxt = image.Metadata.ExifProfile?.GetValue(ExifTag.DateTimeOriginal);
            IExifValue<string>? dateTakenOffsetTxt = image.Metadata.ExifProfile?.GetValue(ExifTag.OffsetTimeOriginal);

            double? longitude = longitudeRat?.Value.ToDouble() * (longitudeRef?.Value == "W" ? -1 : 1);
            double? latitude = latitudeRat?.Value.ToDouble() * (latitudeRef?.Value == "S" ? -1 : 1);

#warning todo error handling
            LocalDateTime? localDateTaken = dateTakenTxt != null ? LocalDateTimePattern.CreateWithInvariantCulture("yyyy:MM:dd HH:mm:ss").Parse(dateTakenTxt.Value).Value : null;
            Offset? dateTakenOffset = dateTakenOffsetTxt != null ? OffsetPattern.GeneralInvariant.Parse(dateTakenOffsetTxt.Value).Value : null;

            OffsetDateTime? dateTaken = dateTakenOffset != null && localDateTaken != null ? new(localDateTaken.Value, dateTakenOffset.Value) : null;

            image.Mutate(x => x
                 .Resize(480, 640, KnownResamplers.Lanczos8)
                 .Flip(orientation?.Value switch
                 {
                     2 or 4 or 5 or 7 => FlipMode.Horizontal,
                     _ => FlipMode.None
                 })
                 .Rotate(orientation?.Value switch
                 {
                     8 or 7 => RotateMode.Rotate270,
                     3 or 4 => RotateMode.Rotate180,
                     6 or 5 => RotateMode.Rotate90,
                     _ => RotateMode.None,
                 })); ;

            StorageFile? outPhoto = await tempImgFolder.CreateFileAsync(photo.Name, CreationCollisionOption.GenerateUniqueName);
            using Stream? outStream = await outPhoto.OpenStreamForWriteAsync();
            await image.SaveAsync(outStream, resTuple.Format, cancellationToken: ct);

            return new KmzPhotoInfo(photo.Name, photo.Path, longitude ?? 0, latitude ?? 0, bearing?.Value.ToDouble() ?? 0,
                new Dictionary<string, string>
                {
                    { "Date Taken", dateTaken.ToString() ?? "Unknown"},
                    { "Longitude", longitude?.ToString() ?? "Unknown"},
                    { "Latitude", latitude?.ToString() ?? "Unknown"},
                    { "Direction", bearing?.ToString() ?? "Unknown"}
                });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public bool CanRemoveImage => SelectedPhoto != null;

    [ICommand(CanExecute = nameof(CanRemoveImage))]
    public void RemoveImage()
    {
        if (SelectedPhoto != null)
        {
            _ = PhotoList.Remove(SelectedPhoto);
        }
    }
}
