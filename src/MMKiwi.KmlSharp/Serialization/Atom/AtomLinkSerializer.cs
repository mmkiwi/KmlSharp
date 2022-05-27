// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Atom;

namespace MMKiwi.KmlSharp.Serialization.Atom;

internal sealed class AtomLinkSerializer : ISerializationHelper<AtomLink>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<AtomLink>
#endif
{
    public static string Tag => "link";
    public static string Namespace => Namespaces.Atom;

    public static async Task<AtomLink> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();
        AtomLink? o = new();
        HashSet<string> alreadyLoaded = new();
        while (reader.MoveToNextAttribute())
        {
            if (HelpExtensions.CheckAttributeName(reader, "href", Namespaces.Atom, alreadyLoaded))
                o.Href = new(await HelpExtensions.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false));
            else if (HelpExtensions.CheckAttributeName(reader, "rel", Namespaces.Atom, alreadyLoaded))
                o.Rel = await HelpExtensions.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
            else if (HelpExtensions.CheckAttributeName(reader, "type", Namespaces.Atom, alreadyLoaded))
                o.Type = await HelpExtensions.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
            else if (HelpExtensions.CheckAttributeName(reader, "hreflang", Namespaces.Atom, alreadyLoaded))
                o.HrefLang = await HelpExtensions.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
            else if (HelpExtensions.CheckAttributeName(reader, "title", Namespaces.Atom, alreadyLoaded))
                o.Title = await HelpExtensions.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
            else if (HelpExtensions.CheckAttributeName(reader, "length", Namespaces.Atom, alreadyLoaded))
                o.Length = int.Parse(await HelpExtensions.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false));
        }
        reader.ReadStartElement();
        // ensure Href was writting
        if (o.Href == null)
            throw new InvalidDataException("<atom:link /> requires href attribute");
        if (reader.NodeType != XmlNodeType.None)
            reader.ReadEndElement();
        return o;
    }

    public static async Task WriteTagAsync(XmlWriter writer, AtomLink obj, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string prefix = "";
        if (options.EmitAttributeNamespaces)
            prefix = ns?.LookupPrefix(Namespaces.Atom) ?? "";

        if (obj == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Atom).ConfigureAwait(false);
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
            await writer.WriteAttributeIntAsync(prefix, "length", Namespaces.Atom, obj.Length.Value).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    Task ISerializationHelper<AtomLink>.WriteTagAsync(XmlWriter writer, AtomLink o, XmlNamespaceManager? ns, KmlWriteOptions? options, CancellationToken ct)
        => WriteTagAsync(writer, o, ns, options, ct);

    Task<AtomLink> ISerializationHelper<AtomLink>.ReadTagAsync(XmlReader reader, CancellationToken ct)
        => ReadTagAsync(reader, ct);

    string ISerializationHelper<AtomLink>.Tag => Tag;
    string ISerializationHelper<AtomLink>.Namespace => Namespace;
}
