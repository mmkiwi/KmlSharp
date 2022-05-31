// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlOrientationSerializer : ISerializationHelper<KmlOrientation>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlOrientation>
#endif
{
    public static string Namespace => Namespaces.Kml;
    public static string Tag => "Orientation";

    public static async Task<KmlOrientation> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlOrientation o = new();

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
                if (HelpExtensions.CheckElementName(reader, "heading", Namespaces.Kml, alreadyLoaded))
                    o.Heading = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "tilt", Namespaces.Kml, alreadyLoaded))
                    o.Tilt = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "roll", Namespaces.Kml, alreadyLoaded))
                    o.Roll = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
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

    public static async Task WriteTagAsync(XmlWriter writer, KmlOrientation o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (o.Heading != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "heading", Namespaces.Kml, o.Heading).ConfigureAwait(false);
        if (o.Tilt != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "tilt", Namespaces.Kml, o.Tilt).ConfigureAwait(false);
        if (o.Roll != 0 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "roll", Namespaces.Kml, o.Roll).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    Task ISerializationHelper<KmlOrientation>.WriteTagAsync(XmlWriter writer, KmlOrientation o, XmlNamespaceManager? ns, KmlWriteOptions? options, CancellationToken ct)
        => WriteTagAsync(writer, o, ns, options, ct);

    Task<KmlOrientation> ISerializationHelper<KmlOrientation>.ReadTagAsync(XmlReader reader, CancellationToken ct)
        => ReadTagAsync(reader, ct);

    string ISerializationHelper<KmlOrientation>.Tag => Tag;
    string ISerializationHelper<KmlOrientation>.Namespace => Namespace;
}