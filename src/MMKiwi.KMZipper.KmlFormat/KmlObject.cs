namespace MMKiwi.KMZipper.KmlFormat;

public abstract class KmlObject : KmlBase
{
    [XmlAttribute("id", Namespace = "http://schemas.opengis.net/kml/2.3")]
    public string? Id { get; set; }

    [XmlAttribute("targetId", Namespace = "http://schemas.opengis.net/kml/2.3")]
    public string? TargetId { get; set; }

    private protected override Task<UnknownNodes> ReadXmlAsyncImpl(XmlReaderHelper reader)
    {
        throw new NotImplementedException();
    }
    private protected override async Task WriteXmlAsyncImpl(XmlWriterHelper writer)
    {
        await writer.WriteAttributeIfNotNullAsync("id", Id);
        await writer.WriteAttributeIfNotNullAsync("targetId", TargetId);
    }
}
