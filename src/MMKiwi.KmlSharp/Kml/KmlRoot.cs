// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;
public sealed class KmlRoot
{
    public string? Hint { get; set; }

    public string? Version { get; set; } = "2.3";

    public KmlAbstractFeature? RootFeature { get; set; }

    public KmlNetworkLinkControl? NetworkLinkControl { get; set; }
}
