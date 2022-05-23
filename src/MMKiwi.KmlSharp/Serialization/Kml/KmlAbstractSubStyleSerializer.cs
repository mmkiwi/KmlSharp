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
    public static Task<bool> ReadAbstractAttributesAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
        => KmlObjectSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoaded);

    public static Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
        => KmlObjectSerializer.ReadAbstractElementsAsync(reader, o, alreadyLoaded);

    public static Task WriteAbstractAttributesAsync(XmlWriter writer, KmlObj o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null)
        => KmlObjectSerializer.WriteAbstractAttributesAsync(writer, o, prefix, options, ns);

    public static Task WriteAbstractElementsAsync(XmlWriter writer, KmlObj o, KmlWriteOptions options, XmlNamespaceManager? ns = null)
        => KmlObjectSerializer.WriteAbstractElementsAsync(writer, o, options, ns);

    Task IAbstractSerializationHelper<KmlObj>.WriteAbstractAttributesAsync(XmlWriter writer, KmlObj o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns)
        => WriteAbstractAttributesAsync(writer, o, prefix, options, ns);
    Task IAbstractSerializationHelper<KmlObj>.WriteAbstractElementsAsync(XmlWriter writer, KmlObj o, KmlWriteOptions options, XmlNamespaceManager? ns)
        => WriteAbstractElementsAsync(writer, o, options, ns);
    Task<bool> IAbstractSerializationHelper<KmlObj>.ReadAbstractAttributesAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
        => ReadAbstractAttributesAsync(reader, o, alreadyLoaded);
    Task<bool> IAbstractSerializationHelper<KmlObj>.ReadAbstractElementsAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
        => ReadAbstractElementsAsync(reader, o, alreadyLoaded);
}