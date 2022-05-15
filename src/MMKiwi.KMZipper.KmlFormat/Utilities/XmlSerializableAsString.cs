using MMKiwi.AsyncXmlSerializer;

namespace MMKiwi.KMZipper.KmlFormat.Utilities;

public abstract record class XmlStringElement: IXmlSerializableAsync, IXmlSerializable
{
    protected abstract void Parse(string input);
    public XmlSchema? GetSchema() => null;
    public void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();
        if (!reader.IsEmptyElement)
            throw new NotImplementedException();
    }

    public void WriteXml(XmlWriter writer) => writer.WriteString(ToString());
    public async Task ReadXmlAsync(XmlReader reader)
    {
        reader.MoveToContent();
        if (!reader.IsEmptyElement)
            throw new NotImplementedException();
    }
    public async Task WriteXmlAsync(XmlWriter writer) => await writer.WriteStringAsync(ToString());

}