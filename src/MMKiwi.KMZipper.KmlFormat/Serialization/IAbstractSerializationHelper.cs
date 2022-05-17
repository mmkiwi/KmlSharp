namespace MMKiwi.KMZipper.KmlFormat.Serialization;

internal interface IAbstractSerializationHelper<T>
{

    Task WriteAbstractAttributesAsync(XmlWriter writer, T o, string prefix, XmlNamespaceManager? ns = null);
    Task WriteAbstractElementsAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null);
    Task<bool> ReadAbstractAttributesAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded);
    Task<bool> ReadAbstractElementsAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded);

}

#if NET7_0_OR_GREATER
internal interface IAbstractSerializationHelperStatic<T>
{
    static abstract Task WriteAbstractAttributesAsync(XmlWriter writer, T o, string prefix, XmlNamespaceManager? ns = null);

    static abstract Task WriteAbstractElementsAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null);
    static abstract Task<bool> ReadAbstractAttributesAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded);
    static abstract Task<bool> ReadAbstractElementsAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded);
}

#endif
