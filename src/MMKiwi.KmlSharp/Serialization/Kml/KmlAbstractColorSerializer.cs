// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;

using KmlColorMode = MMKiwi.KmlSharp.Kml.KmlColorMode;

using KmlObj = MMKiwi.KmlSharp.Kml.KmlAbstractColorStyle;
namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlAbstractColorSerializer : IAbstractSerializationHelper<KmlObj>
#if NET7_0_OR_GREATER
, IAbstractSerializationHelperStatic<KmlObj>
#endif
{
    public static async Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
    {
        if (Helpers.CheckElementName(reader, "color", Namespaces.Kml, alreadyLoaded))
            o.Color = await Helpers.ReadElementColorAsync(reader, alreadyLoaded)
                                   .ConfigureAwait(false);
        else if (Helpers.CheckElementName(reader, "colorMode", Namespaces.Kml, alreadyLoaded))
            o.ColorMode = await Helpers.ReadElementEnumAsync<KmlColorMode>(reader, alreadyLoaded)
                                       .ConfigureAwait(false);
        else
            return await KmlAbstractSubStyleSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoaded)
                                                      .ConfigureAwait(true);
        return true;
    }

    public static async Task WriteAbstractElementsAsync(XmlWriter writer, KmlObj o, KmlWriteOptions options,
        XmlNamespaceManager? ns = null)
    {
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o.Color != Color.White || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "color", Namespaces.Kml, o.Color.ToKmlString())
                        .ConfigureAwait(false);
        if (o.ColorMode != KmlColorMode.Normal || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "colorMode", Namespaces.Kml, o.ColorMode.ToKmlString())
                        .ConfigureAwait(false);
        await KmlAbstractSubStyleSerializer.WriteAbstractElementsAsync(writer, o, options, ns).ConfigureAwait(false);
    }

    public static Task<bool> ReadAbstractAttributesAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded) 
        => KmlAbstractSubStyleSerializer.ReadAbstractAttributesAsync(reader,o,alreadyLoaded);

    public static Task WriteAbstractAttributesAsync(XmlWriter writer, KmlObj o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null)
        => KmlAbstractSubStyleSerializer.WriteAbstractAttributesAsync(writer,o,prefix, options, ns);

    Task IAbstractSerializationHelper<KmlObj>.WriteAbstractAttributesAsync(XmlWriter writer, KmlObj o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns)
        => WriteAbstractAttributesAsync(writer, o, prefix, options, ns);
    Task IAbstractSerializationHelper<KmlObj>.WriteAbstractElementsAsync(XmlWriter writer, KmlObj o, KmlWriteOptions options, XmlNamespaceManager? ns)
        => WriteAbstractElementsAsync(writer, o, options, ns);
    Task<bool> IAbstractSerializationHelper<KmlObj>.ReadAbstractAttributesAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
        => ReadAbstractAttributesAsync(reader, o, alreadyLoaded);
    Task<bool> IAbstractSerializationHelper<KmlObj>.ReadAbstractElementsAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
        => ReadAbstractElementsAsync(reader, o, alreadyLoaded);
}