// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;
using System.Globalization;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlListStyleSerializer : SerializationHelper<KmlListStyle>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlListStyle>
#endif
{
    protected override string Namespace => StaticNamespace;
    public static string StaticNamespace => Namespaces.Kml;
    protected override string Tag => StaticTag;
    public static string StaticTag => "ListStyle";

    public static async Task<KmlListStyle> StaticReadTagAsync(XmlReader reader)
    {
        _ = reader.MoveToElement();

        KmlListStyle o = new();

        HashSet<string> alreadyLoadedAtt = new();
        while (reader.MoveToNextAttribute())
        {
            _ = await KmlAbstractColorSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoadedAtt).ConfigureAwait(false);
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
                if (Helpers.CheckElementName(reader, "maxSnippetLines", Namespaces.Kml, alreadyLoaded))
                    o.MaxSnippetLines = await Helpers.ReadElementIntAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (Helpers.CheckElementName(reader, "listItemType", Namespaces.Kml, alreadyLoaded))
                    o.ListItemType = await Helpers.ReadElementEnumAsync<KmlListItemType>(reader, alreadyLoaded).ConfigureAwait(false);
                else if (Helpers.CheckElementName(reader, "bgColor", Namespaces.Kml, alreadyLoaded))
                    o.BgColor = await Helpers.ReadElementColorAsync(reader, alreadyLoaded).ConfigureAwait(false);
                else if (Helpers.CheckElementName(reader, "ItemIcon", Namespaces.Kml, alreadyLoaded))
                    o.ItemIcons.Add(await KmlItemIconSerializer.StaticReadTagAsync(reader).ConfigureAwait(false));
                else if (!await KmlAbstractColorSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoadedAtt).ConfigureAwait(false))
                {
#warning todo unknown elements
                    throw new NotImplementedException();
                }
            }
        }
        if(reader.NodeType != XmlNodeType.None)
            reader.ReadEndElement();
        return o;
    }

    public static async Task StaticWriteTagAsync(XmlWriter writer, KmlListStyle o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null)
    {
        options ??= KmlWriteOptions.Default;
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o == null)
            return;

        await writer.WriteStartElementAsync(prefix, StaticTag, Namespaces.Kml).ConfigureAwait(false);
        await KmlAbstractColorSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns).ConfigureAwait(false);
        if (o.MaxSnippetLines != 2 || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "maxSnippetLines", Namespaces.Kml, o.MaxSnippetLines.ToString(CultureInfo.InvariantCulture)).ConfigureAwait(false);
        if (o.ListItemType != KmlListItemType.Check || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "listItemType", Namespaces.Kml, o.ListItemType.ToKmlString()).ConfigureAwait(false);
        if (o.BgColor != Color.White || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "bgColor", Namespaces.Kml, o.BgColor.ToKmlString()).ConfigureAwait(false);
        foreach(var icon in o.ItemIcons)
            await KmlItemIconSerializer.StaticWriteTagAsync(writer, icon, ns, options).ConfigureAwait(false);
        await KmlAbstractColorSerializer.WriteAbstractElementsAsync(writer, o, options, ns).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    public override Task WriteTagAsync(XmlWriter writer, KmlListStyle o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null)
        => StaticWriteTagAsync(writer, o, ns, options);

    public override Task<KmlListStyle> ReadTagAsync(XmlReader reader)
        => StaticReadTagAsync(reader);
}