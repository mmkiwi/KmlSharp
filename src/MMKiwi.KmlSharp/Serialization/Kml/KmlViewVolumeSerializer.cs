// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlViewVolumeSerializer : ISerializationHelper<KmlViewVolume>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlViewVolume>
#endif
{
    public static string Namespace => Namespaces.Kml;
    public static string Tag => "ViewVolume";

    public static async Task<KmlViewVolume> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlViewVolume o = new();

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
                if (HelpExtensions.CheckElementName(reader, "leftFov", Namespaces.Kml, alreadyLoaded))
                    o.LeftFieldOfView = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "rightFov", Namespaces.Kml, alreadyLoaded))
                    o.RightFieldOfView = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "bottomFov", Namespaces.Kml, alreadyLoaded))
                    o.BottomFieldOfView = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "topFov", Namespaces.Kml, alreadyLoaded))
                    o.TopFieldOfView = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "near", Namespaces.Kml, alreadyLoaded))
                    o.Near = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
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

    public static async Task WriteTagAsync(XmlWriter writer, KmlViewVolume o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (o.LeftFieldOfView != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "leftFov", Namespaces.Kml, o.LeftFieldOfView).ConfigureAwait(false);
        if (o.RightFieldOfView != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "rightFov", Namespaces.Kml, o.RightFieldOfView).ConfigureAwait(false);
        if (o.TopFieldOfView != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "topFov", Namespaces.Kml, o.TopFieldOfView).ConfigureAwait(false);
        if (o.BottomFieldOfView != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "bottomFov", Namespaces.Kml, o.BottomFieldOfView).ConfigureAwait(false);
        if (o.Near != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "near", Namespaces.Kml, o.Near).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    Task ISerializationHelper<KmlViewVolume>.WriteTagAsync(XmlWriter writer, KmlViewVolume o, XmlNamespaceManager? ns, KmlWriteOptions? options, CancellationToken ct)
        => WriteTagAsync(writer, o, ns, options, ct);

    Task<KmlViewVolume> ISerializationHelper<KmlViewVolume>.ReadTagAsync(XmlReader reader, CancellationToken ct)
        => ReadTagAsync(reader, ct);

    string ISerializationHelper<KmlViewVolume>.Tag => Tag;
    string ISerializationHelper<KmlViewVolume>.Namespace => Namespace;
}