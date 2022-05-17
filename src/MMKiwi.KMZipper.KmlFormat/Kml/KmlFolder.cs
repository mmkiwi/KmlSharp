namespace MMKiwi.KMZipper.KmlFormat.Kml;

public class KmlFolder: KmlAbstractContainer
{
    public List<KmlAbstractFeature> Features { get; } = new();
}