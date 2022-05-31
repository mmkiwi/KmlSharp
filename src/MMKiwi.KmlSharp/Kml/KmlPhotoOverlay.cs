// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlPhotoOverlay : KmlAbstractOverlay
{
    public double Rotation { get; set; } = 0;
    public KmlViewVolume? ViewVolume { get; set; }
    public KmlImagePyramid? ImagePyramid { get; set; }
    public KmlPoint? Point { get; set; }
    public KmlShape Shape { get; set; } = KmlShape.Rectangle;
}
