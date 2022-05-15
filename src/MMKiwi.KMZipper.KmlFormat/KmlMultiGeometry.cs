namespace MMKiwi.KMZipper.KmlFormat;

public class KmlMultiGeometry : KmlGeometry
{
    [XmlElement("Point", Type = typeof(KmlPoint), Namespace = KmlNs.Kml)]
    [XmlElement("LineString", Type = typeof(KmlLineString), Namespace = KmlNs.Kml)]
    [XmlElement("LinearRing", Type = typeof(KmlLinearRing), Namespace = KmlNs.Kml)]
    [XmlElement("Polygon", Type = typeof(KmlPolygon), Namespace = KmlNs.Kml)]
    [XmlElement("MultiGeometry", Type = typeof(KmlMultiGeometry), Namespace = KmlNs.Kml)]
    [XmlElement("Model", Type = typeof(KmlModel), Namespace = KmlNs.Kml)]
    public KmlGeometry[]? Geometries { get; set; }

    public override string TagName => "MultiGeometry";
}
