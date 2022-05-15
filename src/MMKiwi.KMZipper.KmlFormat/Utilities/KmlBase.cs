using MMKiwi.AsyncXmlSerializer;

namespace MMKiwi.KMZipper.KmlFormat.Utilities;

public abstract class KmlBase: IXmlSerializableAsync
{
    public abstract string TagName { get; }

    protected KmlBase() { }

    protected KmlBase(IEnumerable<XmlElement> otherElements, IEnumerable<XmlAttribute> otherAttributes)
    {
        OtherElements = otherElements;
        OtherAttributes = otherAttributes;
    }

    public IEnumerable<XmlElement> OtherElements { get; set; } = Enumerable.Empty<XmlElement>();

    public IEnumerable<XmlAttribute> OtherAttributes { get; set; } = Enumerable.Empty<XmlAttribute>();

    public async Task ReadXmlAsync(XmlReader reader)
    {
        UnknownNodes extra = await ReadXmlAsyncImpl(new(reader, true));
        OtherElements = extra.UnknownElements;
        OtherAttributes = extra.UnknownAttributes;

    }
    private protected abstract Task<UnknownNodes> ReadXmlAsyncImpl(XmlReaderHelper reader);

    public Task WriteXmlAsync(XmlWriter writer) => WriteXmlAsync(new XmlWriterHelper(writer, true));

    internal async Task WriteXmlAsync(XmlWriterHelper writer)
    {
        await WriteXmlAsyncImpl(writer);
        foreach (XmlElement element in OtherElements)
            element.WriteTo(writer.Writer);
        foreach (XmlAttribute attribute in OtherAttributes)
            attribute.WriteTo(writer.Writer);
        await writer.Writer.FlushAsync();
    }

    private protected abstract Task WriteXmlAsyncImpl(XmlWriterHelper writer);

    protected internal record class UnknownNodes(IEnumerable<XmlElement> UnknownElements, IEnumerable<XmlAttribute> UnknownAttributes) { }
}