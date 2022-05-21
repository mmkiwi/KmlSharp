// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlScreenOverlay : KmlAbstractOverlay
{
    public KmlVect2? OverlayXY { get; set; }
    public KmlVect2? ScreenXY { get; set; }
    public KmlVect2? RotationXY { get; set; }
    public KmlVect2? Size { get; set; }
    public double Rotation { get; set; } = 0;
}
