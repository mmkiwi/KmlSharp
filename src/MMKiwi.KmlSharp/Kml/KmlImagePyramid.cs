// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlImagePyramid
{
    public int TileSize { get; set; } = 256;
    public int MaxWidth { get; set; } = 0;
    public int MaxHeight { get; set; } = 0;
    public KmlGridOrigin GridOrigin { get; set; } = KmlGridOrigin.LowerLeft;
}

public enum KmlGridOrigin
{
    LowerLeft, UpperLeft
}