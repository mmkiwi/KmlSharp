namespace MMKiwi.KMZipper.KmlFormat.Serialization;

internal interface ISerializationHelper<T>
{
    public Task WriteRootTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null);
    public Task WriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null);
    public Task<T> ReadTagAsync(XmlReader reader);
    public Task<T?> ReadRootTagAsync(XmlReader reader);
}

public abstract class SerializationHelper<T> : ISerializationHelper<T> where T : class
{
    protected virtual bool PrefixAttributes => false;
    protected abstract string Tag { get; }
    public virtual async Task<T?> ReadRootTagAsync(XmlReader reader)
    {
        T? o = null;
        if (reader.MoveToContent() == System.Xml.XmlNodeType.Element)
        {
            o = reader.LocalName == Tag && reader.NamespaceURI == Namespaces.Atom
                ? await ReadTagAsync(reader)
                : throw new ArgumentException($"Tag {reader.LocalName} was not expected");
        }
        return o;
    }
    public abstract Task<T> ReadTagAsync(XmlReader reader);
    public virtual async Task WriteRootTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null)
    {
        writer.WriteStartDocument();
        if (o == null)
            this.WriteEmptyElement(writer, Tag, Namespaces.Atom);
        else
            await WriteTagAsync(writer, o, ns);
    }
    public abstract Task WriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null);

    protected bool CheckElementName(XmlReader reader, string name, string ns, HashSet<string> alreadySet)
        => !alreadySet.Contains(name) && reader.LocalName == name && reader.NamespaceURI == ns;

    protected async Task<string> ReadElementStrignAsync(XmlReader reader, HashSet<string> alreadySet)
    {
        alreadySet.Add(reader.Name);
        return await reader.ReadElementContentAsStringAsync();
    }

    protected async Task<string> ReadAttributeString(XmlReader reader, HashSet<string> alreadySet)
    {
        alreadySet.Add(reader.Name);
        return await reader.GetValueAsync();
    }

    protected void WriteEmptyElement(XmlWriter writer, string localname, string ns)
    {
        writer.WriteStartElement(localname, ns);
        writer.WriteEndElement();
    }
}
