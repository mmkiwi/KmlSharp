// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlLod : KmlAbstractObject
{
    public double MinLodPixels { get; set; } = 0;
    public double MaxLodPixels { get; set; } = -1;
    public double MinFadeExtent { get; set; } = 0;
    public double MaxFadeExtent { get; set; } = 0;
}