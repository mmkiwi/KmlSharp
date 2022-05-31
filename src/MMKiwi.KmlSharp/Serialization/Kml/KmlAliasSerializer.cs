// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlAliasSerializer : ISerializationHelper<KmlAlias>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlAlias>
#endif
{
    public static string Namespace => Namespaces.Kml;
    public static string Tag => "Alias";

    public static async Task<KmlAlias> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlAlias o = new();

        HashSet<string> alreadyLoadedAtt = new();
        while (reader.MoveToNextAttribute())
        {
            if (!await KmlAbstractObjectSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoadedAtt, ct).ConfigureAwait(false))
                KmlAbstractObjectSerializer.LoadUnknownAttribueAsync(reader, o);
        }

        HashSet<string> alreadyLoaded = new();
        reader.ReadStartElement();
        while (await reader.MoveToContentAsync().ConfigureAwait(false) is not XmlNodeType.EndElement and not XmlNodeType.None)
        {
            ct.ThrowIfCancellationRequested();
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (HelpExtensions.CheckElementName(reader, "targetHref", Namespaces.Kml, alreadyLoaded))
                    o.TargetHref = await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "sourceHref", Namespaces.Kml, alreadyLoaded))
                    o.SourceHref = await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);
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

    public static async Task WriteTagAsync(XmlWriter writer, KmlAlias o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (!string.IsNullOrWhiteSpace(o.TargetHref) || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "targetHref", Namespaces.Kml, o.TargetHref).ConfigureAwait(false);
        if (!string.IsNullOrWhiteSpace(o.SourceHref) || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "sourceHref", Namespaces.Kml, o.SourceHref).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    Task ISerializationHelper<KmlAlias>.WriteTagAsync(XmlWriter writer, KmlAlias o, XmlNamespaceManager? ns, KmlWriteOptions? options, CancellationToken ct)
        => WriteTagAsync(writer, o, ns, options, ct);

    Task<KmlAlias> ISerializationHelper<KmlAlias>.ReadTagAsync(XmlReader reader, CancellationToken ct)
        => ReadTagAsync(reader, ct);

    string ISerializationHelper<KmlAlias>.Tag => Tag;
    string ISerializationHelper<KmlAlias>.Namespace => Namespace;
}