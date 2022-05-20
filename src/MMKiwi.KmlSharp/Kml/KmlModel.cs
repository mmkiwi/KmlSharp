// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlModel : KmlAbstractGeometry
{
    public KmlAltitudeMode AltitudeMode { get; set; }
    public KmlSeaFloorAltitudeMode SeaFloorAltitudeMode { get; set; }
    public KmlLocation? Location { get; set; }
    public KmlOrientation? Orientation { get; set; }
    public KmlScale? Scale { get; set; }
    public KmlLink? Link { get; set; }

    public KmlResourceMap? ResourceMap { get; set; }
}
