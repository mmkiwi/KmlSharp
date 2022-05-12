using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MMKiwi.KMZipper.GUI.Core.Models;

public sealed record KmzSaveProperties(string Title, ImmutableArray<KmzPhotoInfo> Items, bool RotateIcons = true, string IconPath = "http://maps.google.com/mapfiles/kml/shapes/track.png", double Range=5000)
{ }