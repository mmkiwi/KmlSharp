// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;

namespace MMKiwi.KmlSharp.Kml;

public class KmlBalloonStyle : KmlAbstractSubStyle
{
    public Color BackgroundColor { get; } = Color.Transparent;
    public Color TextColor { get; } = Color.White;
    public string? Text { get; set; }
    public KmlDisplayMode DisplayMode { get; set; } = KmlDisplayMode.Default;
}
