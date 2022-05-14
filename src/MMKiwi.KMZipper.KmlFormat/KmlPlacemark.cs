namespace MMKiwi.KMZipper.KmlFormat;

[XmlRoot("Placemark")]
public class KmlPlacemark:KmlContainer
{
    [XmlElement("Point", Type = typeof(KmlPoint), Namespace = KmlNs.Kml)]
    [XmlElement("LineString", Type = typeof(KmlLineString), Namespace = KmlNs.Kml)]
    [XmlElement("LinearRing", Type = typeof(KmlLinearRing), Namespace = KmlNs.Kml)]
    [XmlElement("Polygon", Type = typeof(KmlPolygon), Namespace = KmlNs.Kml)]
    [XmlElement("MultiGeometry", Type = typeof(KmlMultiGeometry), Namespace = KmlNs.Kml)]
    [XmlElement("Model", Type = typeof(KmlModel), Namespace = KmlNs.Kml)]
    public KmlGeometry? Geometry { get; set; }
}