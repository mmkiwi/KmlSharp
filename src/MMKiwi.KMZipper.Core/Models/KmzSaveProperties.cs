using System;
using System.Collections.Generic;
using System.Text;

namespace MMKiwi.KMZipper.GUI.Core.Models;

public sealed record KmzSaveProperties(string Title, IEnumerable<KmzPhotoInfo> Items, bool RotateIcons = true, string IconPath = "http://maps.google.com/mapfiles/kml/shapes/track.png", double Range=5000)
{ }