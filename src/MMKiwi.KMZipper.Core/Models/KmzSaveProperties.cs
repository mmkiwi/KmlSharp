// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KMZipper.Core.Models;

public record KmzSaveProperties(string Title, IEnumerable<KmzPhotoInfo> Items, bool RotateIcons = true, string IconPath = "http://maps.google.com/mapfiles/kml/shapes/track.png", double Range = 5000)
{ }