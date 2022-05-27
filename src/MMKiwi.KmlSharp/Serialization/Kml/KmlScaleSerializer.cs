// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlScaleSerializer : ISerializationHelper<KmlScale>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlScale>
#endif
{
    public static string Namespace => Namespaces.Kml;
    public static string Tag => "Scale";

    public static async Task<KmlScale> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlScale o = new();

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
                if (Helpers.CheckElementName(reader, "x", Namespaces.Kml, alreadyLoaded))
                    o.X = await Helpers.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (Helpers.CheckElementName(reader, "y", Namespaces.Kml, alreadyLoaded))
                    o.Y = await Helpers.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (Helpers.CheckElementName(reader, "z", Namespaces.Kml, alreadyLoaded))
                    o.Z = await Helpers.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
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

    public static async Task WriteTagAsync(XmlWriter writer, KmlScale o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (o.X != 1 || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "x", Namespaces.Kml, o.X.ToString(CultureInfo.InvariantCulture)).ConfigureAwait(false);
        if (o.Y != 1 || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "y", Namespaces.Kml, o.Y.ToString(CultureInfo.InvariantCulture)).ConfigureAwait(false);
        if (o.Z != 1 || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "z", Namespaces.Kml, o.Z.ToString(CultureInfo.InvariantCulture)).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    Task ISerializationHelper<KmlScale>.WriteTagAsync(XmlWriter writer, KmlScale o, XmlNamespaceManager? ns, KmlWriteOptions? options, CancellationToken ct)
        => WriteTagAsync(writer, o, ns, options, ct);

    Task<KmlScale> ISerializationHelper<KmlScale>.ReadTagAsync(XmlReader reader, CancellationToken ct)
        => ReadTagAsync(reader, ct);

    string ISerializationHelper<KmlScale>.Tag => Tag;
    string ISerializationHelper<KmlScale>.Namespace => Namespace;
}