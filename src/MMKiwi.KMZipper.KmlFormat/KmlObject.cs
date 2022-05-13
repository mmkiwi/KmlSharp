namespace MMKiwi.KMZipper.KmlFormat;

public abstract class KmlObject
{
    [XmlAnyElement]
    public XmlElement[]? OtherElements;

    [XmlAnyAttribute]
    public XmlAttribute[]? OtherAttributes;

}