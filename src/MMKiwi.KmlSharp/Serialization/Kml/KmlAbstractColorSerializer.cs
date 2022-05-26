// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlAbstractColorSerializer : IAbstractSerializationHelper<KmlAbstractColorStyle>
#if NET7_0_OR_GREATER
, IAbstractSerializationHelperStatic<KmlAbstractColorStyle>
#endif
{
    public static async Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlAbstractColorStyle o, HashSet<string> alreadyLoaded, CancellationToken ct = default)
    {
        if (Helpers.CheckElementName(reader, "color", Namespaces.Kml, alreadyLoaded))
            o.Color = await Helpers.ReadElementColorAsync(reader, alreadyLoaded)
                                   .ConfigureAwait(false);
        else if (Helpers.CheckElementName(reader, "colorMode", Namespaces.Kml, alreadyLoaded))
            o.ColorMode = await Helpers.ReadElementEnumAsync<KmlColorMode>(reader, alreadyLoaded)
                                       .ConfigureAwait(false);
        else
            return await KmlAbstractSubStyleSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoaded, ct)
                                                      .ConfigureAwait(true);
        return true;
    }

    public static async Task WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractColorStyle o, KmlWriteOptions options,
        XmlNamespaceManager? ns = null, CancellationToken ct = default)
    {
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o.Color != Color.White || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "color", Namespaces.Kml, o.Color.ToKmlString())
                        .ConfigureAwait(false);
        if (o.ColorMode != KmlColorMode.Normal || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "colorMode", Namespaces.Kml, o.ColorMode.ToKmlString())
                        .ConfigureAwait(false);
        await KmlAbstractSubStyleSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
    }

    public static Task<bool> ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractColorStyle o, HashSet<string> alreadyLoaded, CancellationToken ct = default) 
        => KmlAbstractSubStyleSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoaded, ct);

    public static Task WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractColorStyle o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default)
        => KmlAbstractSubStyleSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct);

    Task IAbstractSerializationHelper<KmlAbstractColorStyle>.WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractColorStyle o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct);
    Task IAbstractSerializationHelper<KmlAbstractColorStyle>.WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractColorStyle o, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractElementsAsync(writer, o, options, ns, ct);
    Task<bool> IAbstractSerializationHelper<KmlAbstractColorStyle>.ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractColorStyle o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractAttributesAsync(reader, o, alreadyLoaded, ct);
    Task<bool> IAbstractSerializationHelper<KmlAbstractColorStyle>.ReadAbstractElementsAsync(XmlReader reader, KmlAbstractColorStyle o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractElementsAsync(reader, o, alreadyLoaded, ct);
}