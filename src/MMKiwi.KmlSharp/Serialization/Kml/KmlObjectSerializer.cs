// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlObjectSerializer : IAbstractSerializationHelper<KmlAbstractObject>
#if NET7_0_OR_GREATER
, IAbstractSerializationHelperStatic<KmlAbstractObject>
#endif
{
    public static async Task<bool> ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded)
    {
        if (Helpers.CheckAttributeName(reader, "id", Namespaces.Kml, alreadyLoaded))
            o.Id = new(await Helpers.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false));
        else if (Helpers.CheckAttributeName(reader, "targetId", Namespaces.Kml, alreadyLoaded))
            o.TargetId = await Helpers.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
        else
            return false;
        return true;
    }

    public static async Task WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractObject o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null)
    {
        if (o.Id != null)
            await writer.WriteAttributeStringAsync(prefix, "id", Namespaces.Kml, o.Id).ConfigureAwait(false);
        if (o.TargetId != null)
            await writer.WriteAttributeStringAsync(prefix, "targetId", Namespaces.Kml, o.TargetId).ConfigureAwait(false);
    }
    public static Task WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractObject o, KmlWriteOptions options, XmlNamespaceManager? ns = null) 
        => Task.CompletedTask;

    public static Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded) 
        => Task.FromResult(false);

    Task<bool> IAbstractSerializationHelper<KmlAbstractObject>.ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded) => ReadAbstractAttributesAsync(reader, o, alreadyLoaded);

    Task IAbstractSerializationHelper<KmlAbstractObject>.WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractObject o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns)
    {
        return WriteAbstractAttributesAsync(writer, o, prefix, options, ns);
    }

    Task IAbstractSerializationHelper<KmlAbstractObject>.WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractObject o, KmlWriteOptions options, XmlNamespaceManager? ns)
    {
        return WriteAbstractElementsAsync(writer, o, options, ns);
    }

    Task<bool> IAbstractSerializationHelper<KmlAbstractObject>.ReadAbstractElementsAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded)
    {
        return ReadAbstractElementsAsync(reader, o, alreadyLoaded);
    }
}
