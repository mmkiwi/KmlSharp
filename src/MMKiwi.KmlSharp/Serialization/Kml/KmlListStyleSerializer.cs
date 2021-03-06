// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;
using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlListStyleSerializer : ISerializationHelper<KmlListStyle>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlListStyle>
#endif
{
    public static string Namespace => Namespaces.Kml;
    public static string Tag => "ListStyle";

    public static async Task<KmlListStyle> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();

        KmlListStyle o = new();

        HashSet<string> alreadyLoadedAtt = new();
        while (reader.MoveToNextAttribute())
        {
            if (!await KmlAbstractColorSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoadedAtt, ct).ConfigureAwait(false))
                KmlAbstractObjectSerializer.LoadUnknownAttribueAsync(reader, o);
        }

        HashSet<string> alreadyLoaded = new();
        reader.ReadStartElement();
        
        int i = 0;
        while (await reader.MoveToContentAsync().ConfigureAwait(false) is not XmlNodeType.EndElement and not XmlNodeType.None)
        {
            if(i++ >= 100)
                throw new StackOverflowException();
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (HelpExtensions.CheckElementName(reader, "maxSnippetLines", Namespaces.Kml, alreadyLoaded))
                    o.MaxSnippetLines = await HelpExtensions.ReadElementIntAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "listItemType", Namespaces.Kml, alreadyLoaded))
                    o.ListItemType = await HelpExtensions.ReadElementEnumAsync<KmlListItemType>(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "bgColor", Namespaces.Kml, alreadyLoaded))
                    o.BgColor = await HelpExtensions.ReadElementColorAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (HelpExtensions.CheckElementName(reader, "ItemIcon", Namespaces.Kml, alreadyLoaded))
                    o.ItemIcons.Add(await KmlItemIconSerializer.ReadTagAsync(reader, ct).ConfigureAwait(false));
                else if (!await KmlAbstractColorSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoadedAtt, ct).ConfigureAwait(false))
                {
                    await KmlAbstractObjectSerializer.LoadUnknownElementAsync(reader, o, ct).ConfigureAwait(false);
                }
            }
        }
        if(reader.NodeType != XmlNodeType.None)
            reader.ReadEndElement();
        return o;
    }

    public static async Task WriteTagAsync(XmlWriter writer, KmlListStyle o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, Tag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractColorSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct).ConfigureAwait(false);
        if (o.MaxSnippetLines != 2 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "maxSnippetLines", Namespaces.Kml, o.MaxSnippetLines).ConfigureAwait(false);
        if (o.ListItemType != KmlListItemType.Check || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "listItemType", Namespaces.Kml, o.ListItemType.ToKmlString()).ConfigureAwait(false);
        if (o.BgColor != Color.White || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "bgColor", Namespaces.Kml, o.BgColor.ToKmlString()).ConfigureAwait(false);
        foreach(var icon in o.ItemIcons)
            await KmlItemIconSerializer.WriteTagAsync(writer, icon, ns, options, ct).ConfigureAwait(false);
        await KmlAbstractColorSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }
    Task ISerializationHelper<KmlListStyle>.WriteTagAsync(XmlWriter writer, KmlListStyle o, XmlNamespaceManager? ns, KmlWriteOptions? options, CancellationToken ct)
        => WriteTagAsync(writer, o, ns, options, ct);

    Task<KmlListStyle> ISerializationHelper<KmlListStyle>.ReadTagAsync(XmlReader reader, CancellationToken ct)
        => ReadTagAsync(reader, ct);

    string ISerializationHelper<KmlListStyle>.Tag => Tag;
    string ISerializationHelper<KmlListStyle>.Namespace => Namespace;
}