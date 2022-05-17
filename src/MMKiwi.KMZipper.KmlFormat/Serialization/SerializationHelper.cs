namespace MMKiwi.KMZipper.KmlFormat.Serialization;

internal abstract class SerializationHelper<T> : ISerializationHelper<T> where T : class
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
        var prefix = ns?.LookupPrefix(Namespaces.Atom) ?? "";
        writer.WriteStartDocument();
        if (o == null)
            await Helpers.WriteEmptyElementAsync(writer, prefix, Tag, Namespaces.Atom);
        else
            await WriteTagAsync(writer, o, ns);
    }
    public abstract Task WriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null);
}

internal static class Helpers
{
    public static bool CheckElementName(XmlReader reader, string name, string ns, HashSet<string> alreadySet)
    => !alreadySet.Contains(name) && reader.LocalName == name && reader.NamespaceURI == ns;
    public static bool CheckAttributeName(XmlReader reader, string name, string ns, HashSet<string> alreadySet)
        => !alreadySet.Contains(name) && reader.LocalName == name && (reader.NamespaceURI == ns || string.IsNullOrEmpty(reader.NamespaceURI));

    public static async Task<string> ReadElementStringAsync(XmlReader reader, HashSet<string> alreadySet)
    {
        alreadySet.Add(reader.Name);
        return await reader.ReadElementContentAsStringAsync();
    }

    public static async Task<string> ReadAttributeString(XmlReader reader, HashSet<string> alreadySet)
    {
        alreadySet.Add(reader.Name);
        return await reader.GetValueAsync();
    }

    public static async Task WriteEmptyElementAsync(XmlWriter writer, string prefix, string localname, string ns)
    {
        await writer.WriteStartElementAsync(prefix, localname, ns);
        await writer.WriteEndElementAsync();
    }

    internal static DateTime? ToDateTime(string d) => XmlConvert.ToDateTime(d, XmlDateTimeSerializationMode.Utc);
}