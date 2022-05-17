using System.Globalization;

using MMKiwi.KMZipper.KmlFormat.Atom;

namespace MMKiwi.KMZipper.KmlFormat.Serialization;

internal sealed class AtomLinkSerializer : SerializationHelper<AtomLink>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<AtomLink>
#endif
{
    protected override string Tag => "link";
    public static string StaticTag => "link";


    public static async Task<AtomLink> StaticReadTagAsync(XmlReader reader)
    {
        _ = reader.MoveToElement();
        var o = new AtomLink();
        HashSet<string> alreadyLoaded = new();
        while (reader.MoveToNextAttribute())
        {
            if (Helpers.CheckAttributeName(reader, "href", Namespaces.Atom, alreadyLoaded))
                o.Href = new(await Helpers.ReadAttributeString(reader, alreadyLoaded));
            else if (Helpers.CheckAttributeName(reader, "rel", Namespaces.Atom, alreadyLoaded))
                o.Rel = await Helpers.ReadAttributeString(reader, alreadyLoaded);
            else if (Helpers.CheckAttributeName(reader, "type", Namespaces.Atom, alreadyLoaded))
                o.Type = await Helpers.ReadAttributeString(reader, alreadyLoaded);
            else if (Helpers.CheckAttributeName(reader, "hreflang", Namespaces.Atom, alreadyLoaded))
                o.HrefLang = await Helpers.ReadAttributeString(reader, alreadyLoaded);
            else if (Helpers.CheckAttributeName(reader, "title", Namespaces.Atom, alreadyLoaded))
                o.Title = await Helpers.ReadAttributeString(reader, alreadyLoaded);
            else if (Helpers.CheckAttributeName(reader, "length", Namespaces.Atom, alreadyLoaded))
                o.Length = int.Parse(await Helpers.ReadAttributeString(reader, alreadyLoaded));
        }
        reader.ReadStartElement();
        // ensure Href was writting
        if (o.Href == null)
            throw new InvalidDataException("<atom:link /> requires href attribute");
        if (reader.NodeType != XmlNodeType.None)
            reader.ReadEndElement();
        return o;
    }

    public static async Task StaticWriteTagAsync(XmlWriter writer, AtomLink obj, XmlNamespaceManager? ns = null)
    {
        string prefix = "";
        if (false)// (PrefixAttributes)
            prefix = ns?.LookupPrefix(Namespaces.Atom) ?? "";

        if (obj == null)
            return;

        await writer.WriteStartElementAsync(prefix, StaticTag, Namespaces.Atom);
        await writer.WriteAttributeStringAsync(prefix, "href", Namespaces.Atom, obj.Href?.ToString() ?? "");
        if (obj.Rel != null)
            await writer.WriteAttributeStringAsync(prefix, "rel", Namespaces.Atom, obj.Rel);
        if (obj.Type != null)
            await writer.WriteAttributeStringAsync(prefix, "type", Namespaces.Atom, obj.Type);
        if (obj.HrefLang != null)
            await writer.WriteAttributeStringAsync(prefix, "hreflang", Namespaces.Atom, obj.HrefLang);
        if (obj.Title != null)
            await writer.WriteAttributeStringAsync(prefix, "title", Namespaces.Atom, obj.Title.ToString());
        if (obj.Length.HasValue)
            await writer.WriteAttributeStringAsync(prefix, "length", Namespaces.Atom, obj.Length.Value.ToString(CultureInfo.InvariantCulture));
        await writer.WriteEndElementAsync();
    }

    public override Task<AtomLink> ReadTagAsync(XmlReader reader) => StaticReadTagAsync(reader);

    public override Task WriteTagAsync(XmlWriter writer, AtomLink o, XmlNamespaceManager? ns = null) => StaticWriteTagAsync(writer, o, ns);
}
