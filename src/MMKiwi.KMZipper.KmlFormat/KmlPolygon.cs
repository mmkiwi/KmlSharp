namespace MMKiwi.KMZipper.KmlFormat;

public class KmlPolygon : KmlGeometry
{
    [XmlElement("extrude", Namespace = KmlNs.Kml)]
    public bool? Extrude { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeExtrude() => Extrude.HasValue;

    [XmlElement("tessellate", Namespace = KmlNs.Kml)]
    public bool? Tessellate { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTessellate() => Tessellate.HasValue;

    [XmlElement("altitudeMode", Namespace = KmlNs.Kml)]
    public AltitudeMode? AltitudeMode { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAltitudeMode() => AltitudeMode.HasValue;

    [XmlArray("outerBoundaryIs", IsNullable = false, Namespace = KmlNs.Kml)]
    [XmlArrayItem("LinearRing", IsNullable = false, Namespace = KmlNs.Kml)]
    public KmlLinearRing? OuterBoundary { get; set; }

    [XmlArray("innerBoundaryIs", IsNullable = false, Namespace =KmlNs.Kml)]
    [XmlArrayItem("LinearRing", IsNullable = false, Namespace = KmlNs.Kml)]
    public KmlLinearRing[]? InnerBoundary { get; set; }

    public override string TagName => "Polygon";
}
