using System;
using System.Collections.Generic;
using System.Text;

namespace MMKiwi.KMZipper.KmlFormat.Kml;
public sealed class KmlRoot
{
    public string? Hint { get; set; }

    public string? Version { get; set; } = "2.3";

    public KmlAbstractFeature? RootFeature { get; set; }

    public KmlNetworkLinkControl? NetworkLinkControl { get; set; }
}
