// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Drawing;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlEmptyAbstractSerializer<T> : IAbstractSerializationHelper<T>
#if NET7_0_OR_GREATER
, IAbstractSerializationHelperStatic<T>
#endif
    where T : KmlAbstractObject
{
    public static Task<bool> ReadAbstractAttributesAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded, CancellationToken ct = default)
        => KmlAbstractObjectSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoaded, ct);

    public static Task<bool> ReadAbstractElementsAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded, CancellationToken ct = default)
        => KmlAbstractObjectSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoaded, ct);

    public static Task WriteAbstractAttributesAsync(XmlWriter writer, T o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default)
        => KmlAbstractObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct);

    public static Task WriteAbstractElementsAsync(XmlWriter writer, T o, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default)
        => KmlAbstractObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns, ct);

    Task IAbstractSerializationHelper<T>.WriteAbstractAttributesAsync(XmlWriter writer, T o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct);
    Task IAbstractSerializationHelper<T>.WriteAbstractElementsAsync(XmlWriter writer, T o, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractElementsAsync(writer, o, options, ns, ct);
    Task<bool> IAbstractSerializationHelper<T>.ReadAbstractAttributesAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractAttributesAsync(reader, o, alreadyLoaded, ct);
    Task<bool> IAbstractSerializationHelper<T>.ReadAbstractElementsAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractElementsAsync(reader, o, alreadyLoaded, ct);
}

internal class KmlAbstractSubStyleSerializer : KmlEmptyAbstractSerializer<KmlAbstractSubStyle> { }
internal class KmlAbstractContainerSerializer : KmlEmptyAbstractSerializer<KmlAbstractContainer> { }
internal class KmlAbstractGeometrySerializer : KmlEmptyAbstractSerializer<KmlAbstractGeometry> { }
internal class KmlAbstractStyleSelectorSerializer : KmlEmptyAbstractSerializer<KmlAbstractStyleSelector> { }
internal class KmlAbstractTimeSerializer : KmlEmptyAbstractSerializer<KmlAbstractTime> { }
internal class KmlAbstractTourPrimitiveSerializer : KmlEmptyAbstractSerializer<KmlAbstractTourPrimitive> { }
internal class KmlAbstractUpdateOptionSerializer : KmlEmptyAbstractSerializer<KmlAbstractUpdateOption> { }
internal class KmlAbstractViewSerializer : KmlEmptyAbstractSerializer<KmlAbstractView> { }
internal class KmlAbstractExtentSerializer : KmlEmptyAbstractSerializer<KmlAbstractExtent> { }
