namespace MMKiwi.KMZipper.KmlFormat;

public abstract class KmlOverlay: KmlFeature
{
    [XmlElement("color", Namespace =KmlNs.Kml, IsNullable = false)]
    public KmlColor? Color { get; set; }
}
