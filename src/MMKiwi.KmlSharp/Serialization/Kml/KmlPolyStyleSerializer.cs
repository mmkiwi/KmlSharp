// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlPolyStyleSerializer : SerializationHelper<KmlPolyStyle>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlPolyStyle>
#endif
{
    protected override string Namespace => StaticNamespace;
    public static string StaticNamespace => Namespaces.Kml;
    protected override string Tag => StaticTag;
    public static string StaticTag => "PolyStyle";

    public static async Task<KmlPolyStyle> StaticReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlPolyStyle o = new();

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
                if (Helpers.CheckElementName(reader, "fill", Namespaces.Kml, alreadyLoaded))
                    o.Fill = await Helpers.ReadElementBoolAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (Helpers.CheckElementName(reader, "outline", Namespaces.Kml, alreadyLoaded))
                    o.Outline = await Helpers.ReadElementBoolAsync(reader, alreadyLoaded).ConfigureAwait(false);
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

    public static async Task StaticWriteTagAsync(XmlWriter writer, KmlPolyStyle o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, StaticTag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractColorSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (o.Fill != true || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "fill", Namespaces.Kml, o.Fill.ToKmlString()).ConfigureAwait(false);
        if (o.Outline != true || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "outline", Namespaces.Kml, o.Outline.ToKmlString()).ConfigureAwait(false);
        await KmlAbstractColorSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    public override Task WriteTagAsync(XmlWriter writer, KmlPolyStyle o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
        => StaticWriteTagAsync(writer, o, ns, options, ct);

    public override Task<KmlPolyStyle> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
        => StaticReadTagAsync(reader, ct);
}