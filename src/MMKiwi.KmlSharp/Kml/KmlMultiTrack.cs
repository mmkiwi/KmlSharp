// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlMultiTrack : KmlAbstractGeometry
{
    public KmlAltitudeMode AltitudeMode { get; set; }
    public KmlSeaFloorAltitudeMode SeaFloorAltitudeMode { get; set; }

    public bool Interpolate { get; set; } = false;

    public List<KmlTrack> Tracks { get; } = new();
}