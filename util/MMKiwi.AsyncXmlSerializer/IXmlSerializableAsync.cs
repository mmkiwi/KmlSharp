namespace MMKiwi.AsyncXmlSerializer;

public interface IXmlSerializableAsync
{
    public Task ReadXmlAsync(XmlReader reader);
    public Task WriteXmlAsync(XmlWriter writer);
}
