namespace MMKiwi.KMZipper.KmlFormat.Kml;

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