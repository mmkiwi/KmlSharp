// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlAbstractLatLonBoxSerializer : IAbstractSerializationHelper<KmlAbstractLatLonBox>
#if NET7_0_OR_GREATER
, IAbstractSerializationHelperStatic<KmlAbstractLatLonBox>
#endif
{
    public static async Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlAbstractLatLonBox o, HashSet<string> alreadyLoaded, CancellationToken ct = default)
    {
        if (HelpExtensions.CheckElementName(reader, "north", Namespaces.Kml, alreadyLoaded))
            o.North = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
        else if (HelpExtensions.CheckElementName(reader, "south", Namespaces.Kml, alreadyLoaded))
            o.South = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
        else if (HelpExtensions.CheckElementName(reader, "east", Namespaces.Kml, alreadyLoaded))
            o.East = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
        else if (HelpExtensions.CheckElementName(reader, "west", Namespaces.Kml, alreadyLoaded))
            o.West = await HelpExtensions.ReadElementDoubleAsync(reader, alreadyLoaded).ConfigureAwait(false);
        else
            return await KmlAbstractExtentSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoaded, ct)
                                                      .ConfigureAwait(true);
        return true;
    }

    public static async Task WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractLatLonBox o, KmlWriteOptions options,
        XmlNamespaceManager? ns = null, CancellationToken ct = default)
    {
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o.North != 90 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "north", Namespaces.Kml, o.North).ConfigureAwait(false);
        if (o.South != -90 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "south", Namespaces.Kml, o.South).ConfigureAwait(false);
        if (o.East != 180 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "east", Namespaces.Kml, o.South).ConfigureAwait(false);
        if (o.West != -180 || options.EmitValuesWhenDefault)
            await writer.WriteElementDoubleAsync(prefix, "west", Namespaces.Kml, o.South).ConfigureAwait(false);
        await KmlAbstractExtentSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct).ConfigureAwait(false);
    }

    public static Task<bool> ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractLatLonBox o, HashSet<string> alreadyLoaded, CancellationToken ct = default)
        => KmlAbstractExtentSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoaded, ct);

    public static Task WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractLatLonBox o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default)
        => KmlAbstractExtentSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct);

    Task IAbstractSerializationHelper<KmlAbstractLatLonBox>.WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractLatLonBox o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct);
    Task IAbstractSerializationHelper<KmlAbstractLatLonBox>.WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractLatLonBox o, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractElementsAsync(writer, o, options, ns, ct);
    Task<bool> IAbstractSerializationHelper<KmlAbstractLatLonBox>.ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractLatLonBox o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractAttributesAsync(reader, o, alreadyLoaded, ct);
    Task<bool> IAbstractSerializationHelper<KmlAbstractLatLonBox>.ReadAbstractElementsAsync(XmlReader reader, KmlAbstractLatLonBox o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractElementsAsync(reader, o, alreadyLoaded, ct);
}