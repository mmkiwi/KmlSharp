// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Serialization;

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
                ? await ReadTagAsync(reader).ConfigureAwait(false)
                : throw new ArgumentException($"Tag {reader.LocalName} was not expected");
        }
        return o;
    }
    public abstract Task<T> ReadTagAsync(XmlReader reader);
    public virtual async Task WriteRootTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null)
    {
        string? prefix = ns?.LookupPrefix(Namespaces.Atom) ?? "";
        writer.WriteStartDocument();
        if (o == null)
            await Helpers.WriteEmptyElementAsync(writer, prefix, Tag, Namespaces.Atom).ConfigureAwait(false);
        else
            await WriteTagAsync(writer, o, ns, options).ConfigureAwait(false);
    }
    public abstract Task WriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null);
}

internal static class Helpers
{
    public static bool CheckElementName(XmlReader reader, string name, string ns, HashSet<string> alreadySet)
    {
        return !alreadySet.Contains(name) && reader.LocalName == name && reader.NamespaceURI == ns;
    }

    public static bool CheckAttributeName(XmlReader reader, string name, string ns, HashSet<string> alreadySet)
    {
        return !alreadySet.Contains(name) && reader.LocalName == name && (reader.NamespaceURI == ns || string.IsNullOrEmpty(reader.NamespaceURI));
    }

    public static async Task<string> ReadElementStringAsync(XmlReader reader, HashSet<string> alreadySet)
    {
        _ = alreadySet.Add(reader.Name);
        return await reader.ReadElementContentAsStringAsync().ConfigureAwait(false);
    }

    public static async Task<string> ReadAttributeString(XmlReader reader, HashSet<string> alreadySet)
    {
        _ = alreadySet.Add(reader.Name);
        return await reader.GetValueAsync().ConfigureAwait(false);
    }

    public static async Task WriteEmptyElementAsync(XmlWriter writer, string prefix, string localname, string ns)
    {
        await writer.WriteStartElementAsync(prefix, localname, ns).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    internal static DateTime? ToDateTime(string d)
    {
        return XmlConvert.ToDateTime(d, XmlDateTimeSerializationMode.Utc);
    }
}