namespace MMKiwi.KMZipper.KmlFormat.Kml;

public class KmlUpdate : KmlAbstractObject
{
    internal KmlUpdate() { TargetHref = null!; }
    public KmlUpdate(Uri targetHref) => TargetHref = targetHref;

    public Uri TargetHref { get; set; }

    public List<KmlAbstractUpdateOption> Updates { get; } = new();
}
