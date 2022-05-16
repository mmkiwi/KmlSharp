using System.Globalization;

using MMKiwi.KMZipper.KmlFormat.Atom;

namespace MMKiwi.KMZipper.KmlFormat.Serialization;

internal class AtomAuthorSerializer : SerializationHelper<AtomAuthor>
{
    protected override string Tag => "author";

    public override async Task<AtomAuthor> ReadTagAsync(XmlReader reader)
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
                    if (this.CheckElementName(reader, "name", Namespaces.Atom, alreadyLoaded))
                        o.Name = await this.ReadElementStrignAsync(reader, alreadyLoaded);

                    else if (this.CheckElementName(reader, "email", Namespaces.Atom, alreadyLoaded))
                        o.Email = await this.ReadElementStrignAsync(reader, alreadyLoaded);

                    else if (this.CheckElementName(reader, "uri", Namespaces.Atom, alreadyLoaded))
                        o.Uri = new(await this.ReadElementStrignAsync(reader, alreadyLoaded));

                } while (false);
            }
        }
        if (o.Name == null)
            throw new InvalidDataException("<atom:author /> requires name element");
        reader.ReadEndElement();
        return o;
    }

    public override async Task WriteTagAsync(XmlWriter writer, AtomAuthor obj, XmlNamespaceManager? ns = null)
    {
        var prefix = ns?.LookupPrefix(Namespaces.Atom) ?? "";
        if (obj == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Atom);
        await writer.WriteElementStringAsync(prefix, "name", Namespaces.Atom, obj.Name);
        if (obj.Email != null)
            await writer.WriteElementStringAsync(prefix, "email", Namespaces.Atom, obj.Email);
        if (obj.Uri != null)
            await writer.WriteElementStringAsync(prefix, "uri", Namespaces.Atom, obj.Uri.ToString());
        await writer.WriteEndElementAsync();
    }
}
