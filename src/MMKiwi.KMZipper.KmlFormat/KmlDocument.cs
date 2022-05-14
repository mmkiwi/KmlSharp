namespace MMKiwi.KMZipper.KmlFormat;
[XmlRoot("Document",Namespace= "http://schemas.opengis.net/kml/2.3")]
public class KmlDocument: KmlContainer
{
    [XmlArrayItem("Schema")]
    public List<KmlSchema> Schemas { get; set; } = new();

    [EditorBrowsableAttribute(EditorBrowsableState.Never)]
    public bool ShouldSerializeSchemas() => Schemas.Any();

    private static Lazy<XmlSerializerNamespaces> namespaces = new(() =>
    {
        XmlSerializerNamespaces ns = new();
        ns.Add("", "http://schemas.opengis.net/kml/2.3");
        return ns;
    });
    public static XmlSerializerNamespaces Namespaces => namespaces.Value;

    public static XmlSerializer Serializer = new(typeof(KmlDocument));

    public static KmlDocument? Deserialize(TextReader textReader) => Serializer.Deserialize(textReader) as KmlDocument;

    public static KmlDocument? Deserialize(Stream stream) => Serializer.Deserialize(stream) as KmlDocument;

    public static KmlDocument? Deserialize(XmlReader xmlReader) => Serializer.Deserialize(xmlReader) as KmlDocument;

    public void Serialize(TextWriter textWriter) => Serializer.Serialize(textWriter, this, Namespaces);

    public void Serialize(XmlWriter xmlWriter) => Serializer.Serialize(xmlWriter, this, Namespaces);

    public void Serialize(Stream stream) => Serializer.Serialize(stream, this, Namespaces);
}
