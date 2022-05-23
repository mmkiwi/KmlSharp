// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Atom;

namespace MMKiwi.KmlSharp.Serialization.Atom;

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
        while (await reader.MoveToContentAsync().ConfigureAwait(false) is not XmlNodeType.EndElement and not XmlNodeType.None)
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (Helpers.CheckElementName(reader, "name", Namespaces.Atom, alreadyLoaded))
                    o.Name = await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                else if (Helpers.CheckElementName(reader, "email", Namespaces.Atom, alreadyLoaded))
                    o.Email = await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                else if (Helpers.CheckElementName(reader, "uri", Namespaces.Atom, alreadyLoaded))
                    o.Uri = new(await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false));
            }
        }
        if (o.Name == null)
            throw new InvalidDataException("<atom:author /> requires name element");
        reader.ReadEndElement();
        return o;
    }

    public static async Task StaticWriteTagAsync(XmlWriter writer, AtomAuthor obj, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null)
    {
        string? prefix = ns?.LookupPrefix(Namespaces.Atom) ?? "";
        if (obj == null)
            return;

        await writer.WriteStartElementAsync(prefix, StaticTag, Namespaces.Atom).ConfigureAwait(false);
        await writer.WriteElementStringAsync(prefix, "name", Namespaces.Atom, obj.Name).ConfigureAwait(false);
        if (obj.Email != null)
            await writer.WriteElementStringAsync(prefix, "email", Namespaces.Atom, obj.Email).ConfigureAwait(false);
        if (obj.Uri != null)
            await writer.WriteElementStringAsync(prefix, "uri", Namespaces.Atom, obj.Uri.ToString()).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    public override Task<AtomAuthor> ReadTagAsync(XmlReader reader)
    {
        return StaticReadTagAsync(reader);
    }

    public override Task WriteTagAsync(XmlWriter writer, AtomAuthor o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null)
    {
        return StaticWriteTagAsync(writer, o, ns, options);
    }
}
