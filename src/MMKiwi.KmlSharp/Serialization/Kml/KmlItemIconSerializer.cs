// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlItemIconSerializer : ISerializationHelper<KmlItemIcon>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlItemIcon>
#endif
{
    public static string Namespace => Namespaces.Kml;
    public static string Tag => "ItemIcon";

    public static async Task<KmlItemIcon> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlItemIcon o = new();

        HashSet<string> alreadyLoadedAtt = new();
        while (reader.MoveToNextAttribute())
        {
            if (!await KmlAbstractObjectSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoadedAtt, ct).ConfigureAwait(false))
                KmlAbstractObjectSerializer.LoadUnknownAttribueAsync(reader, o);
        }

        HashSet<string> alreadyLoaded = new();
        reader.ReadStartElement();

        int i = 0;
        while (await reader.MoveToContentAsync().ConfigureAwait(false) is not XmlNodeType.EndElement and not XmlNodeType.None)
        {
            if (i++ >= 100)
                throw new StackOverflowException();
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (HelpExtensions.CheckElementName(reader, "state", Namespaces.Kml, alreadyLoaded))
                    o.State = new(await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false));
                else if (HelpExtensions.CheckElementName(reader, "href", Namespaces.Kml, alreadyLoaded))
                    o.Href = await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (!await KmlAbstractObjectSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoadedAtt, ct).ConfigureAwait(false))
                {
                    await KmlAbstractObjectSerializer.LoadUnknownElementAsync(reader, o, ct).ConfigureAwait(false);
                }
            }
        }
        if (reader.NodeType != XmlNodeType.None)
            reader.ReadEndElement();
        return o;
    }

    public static async Task WriteTagAsync(XmlWriter writer, KmlItemIcon o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (o.State != KmlState.Default || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "state", Namespaces.Kml, o.State.ToString()).ConfigureAwait(false);
        if (!string.IsNullOrWhiteSpace(o.Href) || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "href", Namespaces.Kml, o.Href ?? "").ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    Task ISerializationHelper<KmlItemIcon>.WriteTagAsync(XmlWriter writer, KmlItemIcon o, XmlNamespaceManager? ns, KmlWriteOptions? options, CancellationToken ct)
        => WriteTagAsync(writer, o, ns, options, ct);

    Task<KmlItemIcon> ISerializationHelper<KmlItemIcon>.ReadTagAsync(XmlReader reader, CancellationToken ct)
        => ReadTagAsync(reader, ct);

    string ISerializationHelper<KmlItemIcon>.Tag => Tag;
    string ISerializationHelper<KmlItemIcon>.Namespace => Namespace;
}