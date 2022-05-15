namespace MMKiwi.KMZipper.KmlFormat;
[XmlRoot("Document",Namespace= "http://schemas.opengis.net/kml/2.3")]
public class KmlDocument: KmlContainer
{
    [XmlArrayItem("Schema")]
    public List<KmlSchema> Schemas { get; set; } = new();

    public override string TagName => "Document";

}
