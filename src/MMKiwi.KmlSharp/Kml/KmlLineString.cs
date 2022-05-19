// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlLineString : KmlAbstractGeometry
{
    public bool Extrude { get; set; } = false;
    public bool Tessellate { get; set; } = false;
    public KmlAltitudeMode AltitudeMode { get; set; }
    public KmlSeaFloorAltitudeMode SeaFloorAltitudeMode { get; set; }
    public List<KmlCoordinates>? Coordinates { get; } = new();
    public double AltitudeOffset { get; set; } = 0;
}