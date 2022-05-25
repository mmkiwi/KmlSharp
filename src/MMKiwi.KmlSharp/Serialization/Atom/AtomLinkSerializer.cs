// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Atom;

namespace MMKiwi.KmlSharp.Serialization.Atom;

internal sealed class AtomLinkSerializer : SerializationHelper<AtomLink>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<AtomLink>
#endif
{
    protected override string Tag => StaticTag;
    public static string StaticTag => "link";

    protected override string Namespace => StaticNamespace;
    public static string StaticNamespace => Namespaces.Atom;

    public static async Task<AtomLink> StaticReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();
        AtomLink? o = new();
        HashSet<string> alreadyLoaded = new();
        while (reader.MoveToNextAttribute())
        {
            if (Helpers.CheckAttributeName(reader, "href", Namespaces.Atom, alreadyLoaded))
                o.Href = new(await Helpers.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false));
            else if (Helpers.CheckAttributeName(reader, "rel", Namespaces.Atom, alreadyLoaded))
                o.Rel = await Helpers.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
            else if (Helpers.CheckAttributeName(reader, "type", Namespaces.Atom, alreadyLoaded))
                o.Type = await Helpers.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
            else if (Helpers.CheckAttributeName(reader, "hreflang", Namespaces.Atom, alreadyLoaded))
                o.HrefLang = await Helpers.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
            else if (Helpers.CheckAttributeName(reader, "title", Namespaces.Atom, alreadyLoaded))
                o.Title = await Helpers.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
            else if (Helpers.CheckAttributeName(reader, "length", Namespaces.Atom, alreadyLoaded))
                o.Length = int.Parse(await Helpers.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false));
        }
        reader.ReadStartElement();
        // ensure Href was writting
        if (o.Href == null)
            throw new InvalidDataException("<atom:link /> requires href attribute");
        if (reader.NodeType != XmlNodeType.None)
            reader.ReadEndElement();
        return o;
    }

    public static async Task StaticWriteTagAsync(XmlWriter writer, AtomLink obj, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string prefix = "";
        if (options.EmitAttributeNamespaces)
            prefix = ns?.LookupPrefix(Namespaces.Atom) ?? "";

        if (obj == null)
            return;

        await writer.WriteStartElementAsync(prefix, StaticTag, Namespaces.Atom).ConfigureAwait(false);
        await writer.WriteAttributeStringAsync(prefix, "href", Namespaces.Atom, obj.Href?.ToString() ?? "").ConfigureAwait(false);
        if (obj.Rel != null)
            await writer.WriteAttributeStringAsync(prefix, "rel", Namespaces.Atom, obj.Rel).ConfigureAwait(false);
        if (obj.Type != null)
            await writer.WriteAttributeStringAsync(prefix, "type", Namespaces.Atom, obj.Type).ConfigureAwait(false);
        if (obj.HrefLang != null)
            await writer.WriteAttributeStringAsync(prefix, "hreflang", Namespaces.Atom, obj.HrefLang).ConfigureAwait(false);
        if (obj.Title != null)
            await writer.WriteAttributeStringAsync(prefix, "title", Namespaces.Atom, obj.Title.ToString()).ConfigureAwait(false);
        if (obj.Length.HasValue)
            await writer.WriteAttributeStringAsync(prefix, "length", Namespaces.Atom, obj.Length.Value.ToString(CultureInfo.InvariantCulture)).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    public override Task<AtomLink> ReadTagAsync(XmlReader reader, CancellationToken ct = default) 
        => StaticReadTagAsync(reader, ct);

    public override Task WriteTagAsync(XmlWriter writer, AtomLink o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default) 
        => StaticWriteTagAsync(writer, o, ns, options, ct);
}
