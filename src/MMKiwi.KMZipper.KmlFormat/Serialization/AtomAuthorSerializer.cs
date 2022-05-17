using System.Globalization;

using MMKiwi.KMZipper.KmlFormat.Atom;

namespace MMKiwi.KMZipper.KmlFormat.Serialization;

internal class AtomAuthorSerializer : SerializationHelper<AtomAuthor>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<AtomAuthor>
#endif
{
    protected override string Tag => StaticTag;
    public static string StaticTag => "author";

    public static async Task<AtomAuthor> StaticReadTagAsync(XmlReader reader)
    {
        _ = reader.MoveToElement();
        if (reader.IsEmptyElement)
            throw new InvalidDataException("<atom:author /> requires name element");

        AtomAuthor o = new();
        HashSet<string> alreadyLoaded = new();
        reader.ReadStartElement();
        while (await reader.MoveToContentAsync() is not XmlNodeType.EndElement and not XmlNodeType.None)
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                do
                {
                    if (Helpers.CheckElementName(reader, "name", Namespaces.Atom, alreadyLoaded))
                        o.Name = await Helpers.ReadElementStringAsync(reader, alreadyLoaded);

                    else if (Helpers.CheckElementName(reader, "email", Namespaces.Atom, alreadyLoaded))
                        o.Email = await Helpers.ReadElementStringAsync(reader, alreadyLoaded);

                    else if (Helpers.CheckElementName(reader, "uri", Namespaces.Atom, alreadyLoaded))
                        o.Uri = new(await Helpers.ReadElementStringAsync(reader, alreadyLoaded));

                } while (false);
            }
        }
        if (o.Name == null)
            throw new InvalidDataException("<atom:author /> requires name element");
        reader.ReadEndElement();
        return o;
    }

    public static async Task StaticWriteTagAsync(XmlWriter writer, AtomAuthor obj, XmlNamespaceManager? ns = null)
    {
        var prefix = ns?.LookupPrefix(Namespaces.Atom) ?? "";
        if (obj == null)
            return;

        await writer.WriteStartElementAsync(prefix, StaticTag, Namespaces.Atom);
        await writer.WriteElementStringAsync(prefix, "name", Namespaces.Atom, obj.Name);
        if (obj.Email != null)
            await writer.WriteElementStringAsync(prefix, "email", Namespaces.Atom, obj.Email);
        if (obj.Uri != null)
            await writer.WriteElementStringAsync(prefix, "uri", Namespaces.Atom, obj.Uri.ToString());
        await writer.WriteEndElementAsync();
    }

    public override Task<AtomAuthor> ReadTagAsync(XmlReader reader) => StaticReadTagAsync(reader);

    public override Task WriteTagAsync(XmlWriter writer, AtomAuthor o, XmlNamespaceManager? ns = null) => StaticWriteTagAsync(writer, o, ns);
}
