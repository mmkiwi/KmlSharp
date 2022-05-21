// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlPolyStyle : KmlAbstractColorStyle
{
    public bool Fill { get; set; } = true;
    public bool Outline { get; set; } = true;
}
