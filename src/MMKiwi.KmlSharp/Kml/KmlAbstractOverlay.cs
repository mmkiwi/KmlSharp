// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;

namespace MMKiwi.KmlSharp.Kml;

public abstract class KmlAbstractOverlay : KmlAbstractFeature
{
    public Color Color { get; set; } = Color.White;
    public int DrawOrder { get; set; } = 0;
    public KmlIcon? Icon { get; set; }
}

public class KmlScreenOverlay : KmlAbstractOverlay
{
    public KmlVect2? OverlayXY { get; set; }
    public KmlVect2? ScreenXY { get; set; }
    public KmlVect2? RotationXY { get; set; }
    public KmlVect2? Size { get; set; }
    public double Rotation { get; set; } = 0;
}

public record class KmlVect2(double X = 1, double Y = 1) { }