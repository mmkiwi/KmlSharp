namespace MMKiwi.KMZipper.KmlFormat.Utilities;
public static class KmlSerialization

{
    private static Lazy<XmlSerializerNamespaces> namespaces = new(() =>
    {
        XmlSerializerNamespaces ns = new();
        ns.Add("", "http://schemas.opengis.net/kml/2.3");
        return ns;
    });
    public static XmlSerializerNamespaces Namespaces => namespaces.Value;

    public static XmlSerializer Serializer<T>() => new(typeof(T));

    public static T? Deserialize<T>(TextReader textReader)
        where T : KmlBase
        => Serializer<T>().Deserialize(textReader) as T;

    public static T? Deserialize<T>(Stream stream)
        where T : KmlBase
        => Serializer<T>().Deserialize(stream) as T;

    public static T? Deserialize<T>(XmlReader xmlReader)
        where T : KmlBase
        => Serializer<T>().Deserialize(xmlReader) as T;

    public static void Serialize<T>(this T root, TextWriter textWriter)
       where T : KmlBase
       => Serializer<T>().Serialize(textWriter, root, Namespaces);

    public static void Serialize<T>(this T root, XmlWriter xmlWriter)
       where T : KmlBase
       => Serializer<T>().Serialize(xmlWriter, root, Namespaces);

    public static void Serialize<T>(this T root, Stream stream)
        where T : KmlBase
        => Serializer<T>().Serialize(stream, root, Namespaces);
}