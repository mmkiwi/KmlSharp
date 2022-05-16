using System.Globalization;

using MMKiwi.KMZipper.KmlFormat.Atom;

namespace MMKiwi.KMZipper.KmlFormat.Serialization;

internal sealed class AtomLinkSerializer : SerializationHelper<AtomLink>
{
    protected override string Tag => "link";

    public override async Task<AtomLink> ReadTagAsync(XmlReader reader)
    {
        _ = reader.MoveToElement();
        (bool Href, bool Rel, bool Type, bool HrefLang, bool Title, bool Length) read = default;

        var o = new AtomLink();
        HashSet<string> alreadyLoaded = new();
        while (reader.MoveToNextAttribute())
        {
            if (!read.Href && reader.LocalName == "href" && reader.NamespaceURI is "" or Namespaces.Atom)
                o.Href = new(await this.ReadAttributeString(reader, alreadyLoaded));
            else if (!read.Rel && reader.LocalName == "rel" && reader.NamespaceURI is "" or Namespaces.Atom)
                o.Rel = await this.ReadAttributeString(reader, alreadyLoaded);
            else if (!read.Type && reader.LocalName == "type" && reader.NamespaceURI is "" or Namespaces.Atom)
                o.Type = await this.ReadAttributeString(reader, alreadyLoaded);
            else if (!read.HrefLang && reader.LocalName == "hreflang" && reader.NamespaceURI is "" or Namespaces.Atom)
                o.HrefLang = await this.ReadAttributeString(reader, alreadyLoaded);
            else if (!read.Title && reader.LocalName == "title" && reader.NamespaceURI is "" or Namespaces.Atom)
                o.Title = await this.ReadAttributeString(reader, alreadyLoaded);
            else if (!read.Length && reader.LocalName == "length" && reader.NamespaceURI is "" or Namespaces.Atom)
                o.Length = int.Parse(await this.ReadAttributeString(reader, alreadyLoaded));
        }
        reader.ReadStartElement();
        // ensure Href was writting
        if (o.Href == null)
            throw new InvalidDataException("<atom:link /> requires href attribute");
        if (reader.NodeType != XmlNodeType.None)
            reader.ReadEndElement();
        return o;
    }

    public override async Task WriteTagAsync(XmlWriter writer, AtomLink obj, XmlNamespaceManager? ns = null)
    {
        string prefix = "";
        if (PrefixAttributes)
            prefix = ns?.LookupPrefix(Namespaces.Atom) ?? "";

        if (obj == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Atom);
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
}
