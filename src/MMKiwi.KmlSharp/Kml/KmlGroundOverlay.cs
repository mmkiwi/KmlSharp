// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlGroundOverlay : KmlAbstractOverlay
{
    public double Altitude { get; set; } = 0;
    public KmlAltitudeMode AltitudeMode { get; set; }
    public KmlSeaFloorAltitudeMode SeaFloorAltitudeMode { get; set; }
    public KmlAbstractExtent? Extend { get; set; }
}
