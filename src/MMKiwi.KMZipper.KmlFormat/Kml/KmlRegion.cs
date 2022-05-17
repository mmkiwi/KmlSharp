namespace MMKiwi.KMZipper.KmlFormat.Kml;

public class KmlRegion: KmlAbstractObject
{
    public KmlAbstractExtent? Extents { get; set; }

    public KmlLod? Lod { get; set; }
}