// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlNetworkLinkControl : KmlAbstractObject
{
    public double? MinRefreshPeriod { get; set; } = 0;
    public double? MaxSessionLength { get; set; } = -1;
    public string? Cookie { get; set; }
    public string? Message { get; set; }
    public string? LinkName { get; set; }
    public string? LinkDescription { get; set; }
    public string? LinkSnippet { get; set; }
    public DateTime? Expires { get; set; }
    public KmlUpdate? Update { get; set; }
}