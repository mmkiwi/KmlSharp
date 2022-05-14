namespace MMKiwi.KMZipper.KmlFormat;

public record class KmlCoordinates(double Longitude, double Latitude, double? Altitude = null) : IXmlSerializable
{
    private KmlCoordinates() : this(default, default, default) { }

    public XmlSchema? GetSchema() => null;
    public void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();
        if (!reader.IsEmptyElement)
            throw new NotImplementedException();
    }
    private string AltText => Altitude.HasValue ? $",{Altitude}" : string.Empty;
    public void WriteXml(XmlWriter writer) => writer.WriteString($"{Longitude},{Latitude}{AltText}");
}
