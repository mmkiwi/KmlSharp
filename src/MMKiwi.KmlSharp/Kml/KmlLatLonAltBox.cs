// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlLatLonAltBox : KmlAbstractLatLonBox
{
    public double MinAltitude { get; set; } = 0;
    public double MaxAltitude { get; set; } = 0;
    public KmlAltitudeMode AltitudeMode { get; set; } = KmlAltitudeMode.ClampToGround;
    public KmlSeaFloorAltitudeMode? SeaFloorAltitudeMode { get; set; }
}
