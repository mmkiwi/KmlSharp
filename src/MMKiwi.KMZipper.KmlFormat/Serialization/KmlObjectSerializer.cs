using MMKiwi.KMZipper.KmlFormat.Kml;

namespace MMKiwi.KMZipper.KmlFormat.Serialization;
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
    public static Task WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractObject o, XmlNamespaceManager? ns = null) => Task.CompletedTask;

    public static Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded) => Task.FromResult(false);

    Task<bool> IAbstractSerializationHelper<KmlAbstractObject>.ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded)
    => ReadAbstractAttributesAsync(reader, o, alreadyLoaded);
    Task IAbstractSerializationHelper<KmlAbstractObject>.WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractObject o, string prefix, XmlNamespaceManager? ns)
        => WriteAbstractAttributesAsync(writer, o, prefix, ns);
    Task IAbstractSerializationHelper<KmlAbstractObject>.WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractObject o, XmlNamespaceManager? ns) 
        => WriteAbstractElementsAsync(writer, o,ns);

    Task<bool> IAbstractSerializationHelper<KmlAbstractObject>.ReadAbstractElementsAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded) 
        => ReadAbstractElementsAsync(reader, o, alreadyLoaded);
}
