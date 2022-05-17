namespace MMKiwi.KMZipper.KmlFormat.Serialization;

internal interface ISerializationHelper<T>
{
    Task WriteRootTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null);
    Task WriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null);
    Task<T> ReadTagAsync(XmlReader reader);
    Task<T?> ReadRootTagAsync(XmlReader reader);
}
#if NET7_0_OR_GREATER
internal interface ISerializationHelperStatic<T>
{
    static abstract string StaticTag { get; }
    static abstract Task StaticWriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null);
    static abstract Task<T> StaticReadTagAsync(XmlReader reader);
}
#endif