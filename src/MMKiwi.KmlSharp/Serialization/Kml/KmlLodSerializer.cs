// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlLodSerializer : ISerializationHelper<KmlLod>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlLod>
#endif
{
    public static string Namespace => Namespaces.Kml;
    public static string Tag => "Lod";

    public static async Task<KmlLod> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlLod o = new();

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
                if (HelpExtensions.CheckElementName(reader, "minLodPixels", Namespaces.Kml, alreadyLoaded))
                    o.MinLodPixels = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "maxLodPixels", Namespaces.Kml, alreadyLoaded))
                    o.MaxLodPixels = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "minFadeExtent", Namespaces.Kml, alreadyLoaded))
                    o.MinFadeExtent = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "maxFadeExtent", Namespaces.Kml, alreadyLoaded))
                    o.MaxFadeExtent = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
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

    public static async Task WriteTagAsync(XmlWriter writer, KmlLod o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (o.MinLodPixels != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "minLodPixels", Namespaces.Kml, o.MinLodPixels).ConfigureAwait(false);
        if (o.MaxLodPixels != -1 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "maxLodPixels", Namespaces.Kml, o.MaxLodPixels).ConfigureAwait(false);
        if (o.MinFadeExtent != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "minFadeExtent", Namespaces.Kml, o.MinFadeExtent).ConfigureAwait(false);
        if (o.MaxFadeExtent != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "maxFadeExtent", Namespaces.Kml, o.MaxFadeExtent).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    Task ISerializationHelper<KmlLod>.WriteTagAsync(XmlWriter writer, KmlLod o, XmlNamespaceManager? ns, KmlWriteOptions? options, CancellationToken ct)
        => WriteTagAsync(writer, o, ns, options, ct);

    Task<KmlLod> ISerializationHelper<KmlLod>.ReadTagAsync(XmlReader reader, CancellationToken ct)
        => ReadTagAsync(reader, ct);

    string ISerializationHelper<KmlLod>.Tag => Tag;
    string ISerializationHelper<KmlLod>.Namespace => Namespace;
}