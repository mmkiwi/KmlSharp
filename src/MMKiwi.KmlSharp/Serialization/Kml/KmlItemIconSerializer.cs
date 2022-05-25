// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlItemIconSerializer : SerializationHelper<KmlItemIcon>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlItemIcon>
#endif
{
    protected override string Namespace => StaticNamespace;
    public static string StaticNamespace => Namespaces.Kml;
    protected override string Tag => StaticTag;
    public static string StaticTag => "ItemIcon";

    public static async Task<KmlItemIcon> StaticReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlItemIcon o = new();

        HashSet<string> alreadyLoadedAtt = new();
        while (reader.MoveToNextAttribute())
        {
            if(!await KmlAbstractObjectSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoadedAtt, ct).ConfigureAwait(false))
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
                if (Helpers.CheckElementName(reader, "state", Namespaces.Kml, alreadyLoaded))
                    o.State = new(await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false));
                else if (Helpers.CheckElementName(reader, "href", Namespaces.Kml, alreadyLoaded))
                    o.Href = await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);
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

    public static async Task StaticWriteTagAsync(XmlWriter writer, KmlItemIcon o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, StaticTag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (o.State != KmlState.Default || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "state", Namespaces.Kml, o.State.ToString()).ConfigureAwait(false);
        if (!string.IsNullOrWhiteSpace(o.Href) || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "href", Namespaces.Kml, o.Href ?? "").ConfigureAwait(false);
        await KmlAbstractObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    public override Task WriteTagAsync(XmlWriter writer, KmlItemIcon o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
        => StaticWriteTagAsync(writer, o, ns, options, ct);

    public override Task<KmlItemIcon> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
        => StaticReadTagAsync(reader, ct);
}