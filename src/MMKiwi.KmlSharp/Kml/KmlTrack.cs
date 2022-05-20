// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlTrack : KmlAbstractGeometry
{
    public bool Extrude { get; set; } = false;
    public bool Tessellate { get; set; } = false;
    public KmlAltitudeMode AltitudeMode { get; set; }
    public KmlSeaFloorAltitudeMode SeaFloorAltitudeMode { get; set; }

    public List<Stop> Stops { get; } = new();

    public record class Stop(DateTime When, KmlCoordinates Coordinates, Angles? Angles, KmlModel? Model) { }

    public record class Angles(double Heading, double Tilt, double Roll) { }
}
