using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MMKiwi.KMLZipper.GUI.Core.Models;

public sealed record TranformationProperties(string Title, ImmutableArray<TranformationItem> Items, bool RotateIcons = true, string IconPath = "http://maps.google.com/mapfiles/kml/shapes/track.png", double Range=5000)
{ }