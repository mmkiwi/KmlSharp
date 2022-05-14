namespace MMKiwi.KMZipper.KmlFormat;

public abstract class KmlObject
{
    [XmlAttribute("id", Namespace = "http://schemas.opengis.net/kml/2.3")]
    public string? Id { get; set; }

    [XmlAttribute("targetId", Namespace = "http://schemas.opengis.net/kml/2.3")]
    public string? TargetId { get; set; }

    [XmlAnyElement]
    public XmlElement[]? OtherElements;

    [XmlAnyAttribute]
    public XmlAttribute[]? OtherAttributes;

}
