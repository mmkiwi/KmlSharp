// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;

namespace MMKiwi.KmlSharp.Kml;

public class KmlAbstractColorStyle : KmlAbstractSubStyle
{
    public Color Color { get; set; } = Color.White;
    public KmlColorMode ColorMode { get; set; } = KmlColorMode.Normal;
}
