// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public abstract class KmlAbstractLatLonBox : KmlAbstractExtent
{
    public double North { get; set; } = 90;
    public double South { get; set; } = -90;
    public double East { get; set; } = 180;
    public double West { get; set; } = -180;
}

