// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlStyle : KmlAbstractStyleSelector
{
    public KmlIconStyle? IconStyle { get; set; }
    public KmlLabelStyle? LabelStyle { get; set; }
    public KmlLineStyle? LineStyle { get; set; }
    public KmlPolyStyle? PolyStyle { get; set; }
    public KmlBalloonStyle? BalloonStyle { get; set; }
    public KmlListStyle? ListStyle { get; set; }
}
