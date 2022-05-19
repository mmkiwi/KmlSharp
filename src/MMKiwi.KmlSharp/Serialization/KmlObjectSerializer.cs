// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization;
internal class KmlObjectSerializer : IAbstractSerializationHelper<KmlAbstractObject>
#if NET7_0_OR_GREATER
, IAbstractSerializationHelperStatic<KmlAbstractObject>
#endif
{
    public static async Task<bool> ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded)
    {
        if (Helpers.CheckAttributeName(reader, "id", Namespaces.Atom, alreadyLoaded))
            o.Id = new(await Helpers.ReadAttributeString(reader, alreadyLoaded));
        else if (Helpers.CheckAttributeName(reader, "rel", Namespaces.Atom, alreadyLoaded))
            o.TargetId = await Helpers.ReadAttributeString(reader, alreadyLoaded);
        else
            return false;
        return true;
    }

    public static async Task WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractObject o, string prefix, XmlNamespaceManager? ns = null)
    {
        if (o.Id != null)
            await writer.WriteAttributeStringAsync(prefix, "id", Namespaces.Atom, o.Id);
        if (o.TargetId != null)
            await writer.WriteAttributeStringAsync(prefix, "targetId", Namespaces.Atom, o.TargetId);
    }
    public static Task WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractObject o, XmlNamespaceManager? ns = null)
    {
        return Task.CompletedTask;
    }

    public static Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded)
    {
        return Task.FromResult(false);
    }

    Task<bool> IAbstractSerializationHelper<KmlAbstractObject>.ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded)
    {
        return ReadAbstractAttributesAsync(reader, o, alreadyLoaded);
    }

    Task IAbstractSerializationHelper<KmlAbstractObject>.WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractObject o, string prefix, XmlNamespaceManager? ns)
    {
        return WriteAbstractAttributesAsync(writer, o, prefix, ns);
    }

    Task IAbstractSerializationHelper<KmlAbstractObject>.WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractObject o, XmlNamespaceManager? ns)
    {
        return WriteAbstractElementsAsync(writer, o, ns);
    }

    Task<bool> IAbstractSerializationHelper<KmlAbstractObject>.ReadAbstractElementsAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded)
    {
        return ReadAbstractElementsAsync(reader, o, alreadyLoaded);
    }
}
