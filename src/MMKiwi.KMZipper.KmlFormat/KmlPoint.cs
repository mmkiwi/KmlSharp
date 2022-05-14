namespace MMKiwi.KMZipper.KmlFormat;

public class KmlPoint : KmlGeometry
{
    [XmlElement("extrude", Namespace = KmlNs.Kml)]
    public bool? Extrude { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeExtrude() => Extrude.HasValue;

    [XmlElement("altitudeMode", Namespace = KmlNs.Kml)]
    public AltitudeMode? AltitudeMode { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAltitudeMode() => AltitudeMode.HasValue;

    [XmlElement("coordinates", Namespace = KmlNs.Kml, IsNullable = false)]
    public KmlCoordinates? Coordinates { get; set; }
}
