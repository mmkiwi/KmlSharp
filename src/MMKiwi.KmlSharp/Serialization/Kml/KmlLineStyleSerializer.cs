// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlLineStyleSerializer : SerializationHelper<KmlLineStyle>
{
    protected override string Namespace => StaticNamespace;
    public static string StaticNamespace => Namespaces.Kml;
    protected override string Tag => StaticTag;
    public static string StaticTag => "LineStyle";

    public static async Task<KmlLineStyle> StaticReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlLineStyle o = new();

        HashSet<string> alreadyLoadedAtt = new();
        while (reader.MoveToNextAttribute())
        {
            if (!await KmlAbstractColorSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoadedAtt, ct).ConfigureAwait(false))
                KmlAbstractObjectSerializer.LoadUnknownAttribueAsync(reader, o);
        }

        HashSet<string> alreadyLoaded = new();
        reader.ReadStartElement();
        while (await reader.MoveToContentAsync().ConfigureAwait(false) is not XmlNodeType.EndElement and not XmlNodeType.None)
        {
            ct.ThrowIfCancellationRequested();
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (Helpers.CheckElementName(reader, "width", Namespaces.Kml, alreadyLoaded))
                    o.Width = await Helpers.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (!await KmlAbstractColorSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoadedAtt, ct).ConfigureAwait(false))
                {
                    await KmlAbstractObjectSerializer.LoadUnknownElementAsync(reader, o, ct).ConfigureAwait(false);
                }
            }
        }
        if (reader.NodeType != XmlNodeType.None)
            reader.ReadEndElement();
        return o;
    }

    public static async Task StaticWriteTagAsync(XmlWriter writer, KmlLineStyle o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, StaticTag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractColorSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (o.Width != 1 || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "width", Namespaces.Kml, o.Width.ToString(CultureInfo.InvariantCulture)).ConfigureAwait(false);
        await KmlAbstractColorSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    public override Task WriteTagAsync(XmlWriter writer, KmlLineStyle o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
        => StaticWriteTagAsync(writer, o, ns, options, ct);

    public override Task<KmlLineStyle> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
        => StaticReadTagAsync(reader, ct);
}