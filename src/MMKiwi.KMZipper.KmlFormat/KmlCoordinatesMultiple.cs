namespace MMKiwi.KMZipper.KmlFormat;

public record class KmlCoordinatesMultiple(KmlCoordinates[] Coordinates) : IXmlSerializable
{
    private KmlCoordinatesMultiple() : this(Array.Empty<KmlCoordinates>()) { }

    public XmlSchema? GetSchema() => null;
    public void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();
        if (!reader.IsEmptyElement)
            throw new NotImplementedException();
    }

    public void WriteXml(XmlWriter writer) => writer.WriteString(string.Join(" ", Coordinates.Select(c => c.ToString())));
}