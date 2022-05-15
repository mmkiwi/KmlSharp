namespace MMKiwi.KMZipper.KmlFormat;

public class KmlLinearRing : KmlGeometry
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

    [XmlElement("coordinates", Namespace = KmlNs.Kml)]
    public KmlCoordinatesMultiple? Coordinates { get; set; }

    public override string TagName => "LinearRing";
}