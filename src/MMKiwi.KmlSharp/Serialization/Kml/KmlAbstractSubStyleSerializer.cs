// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;

using KmlObj = MMKiwi.KmlSharp.Kml.KmlAbstractSubStyle;
namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlAbstractSubStyleSerializer : IAbstractSerializationHelper<KmlObj>
#if NET7_0_OR_GREATER
, IAbstractSerializationHelperStatic<KmlObj>
#endif
{
    public static Task<bool> ReadAbstractAttributesAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded, CancellationToken ct = default)
        => KmlAbstractObjectSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoaded, ct);

    public static Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded, CancellationToken ct = default)
        => KmlAbstractObjectSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoaded, ct);

    public static Task WriteAbstractAttributesAsync(XmlWriter writer, KmlObj o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default)
        => KmlAbstractObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct);

    public static Task WriteAbstractElementsAsync(XmlWriter writer, KmlObj o, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default)
        => KmlAbstractObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct);

    Task IAbstractSerializationHelper<KmlObj>.WriteAbstractAttributesAsync(XmlWriter writer, KmlObj o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct);
    Task IAbstractSerializationHelper<KmlObj>.WriteAbstractElementsAsync(XmlWriter writer, KmlObj o, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractElementsAsync(writer, o, options, ns, ct);
    Task<bool> IAbstractSerializationHelper<KmlObj>.ReadAbstractAttributesAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractAttributesAsync(reader, o, alreadyLoaded, ct);
    Task<bool> IAbstractSerializationHelper<KmlObj>.ReadAbstractElementsAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractElementsAsync(reader, o, alreadyLoaded, ct);
}