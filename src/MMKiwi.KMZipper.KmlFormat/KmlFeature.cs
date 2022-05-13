namespace MMKiwi.KMZipper.KmlFormat;

public abstract class KmlFeature: KmlObject
{
    private string? description;

    internal protected KmlFeature() //Don't allow other assemblies to subclass
    {

    }

    [XmlElement("name")]
    public string? Name { get; set; }

    [XmlElement("visibility")]
    public bool? Visibility { get; set; }

    [XmlElement("open")]
    public bool? Open { get; set; }

    [XmlElement("address")]
    public string? Address { get; set; }

    [XmlElement("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [XmlElement("Snippet")]
    public KmlSnippet? Snippet { get; set; }

    [XmlElement("description")]
    public XmlCDataSection? Description
    {
        get => description == null ? null : new XmlDocument().CreateCDataSection(description);
        set => description = value?.Value;
    }
    [XmlElement]
    public KmlCamera? AbstractView {get;set;}

    [XmlElement]
    public KmlTimePrimitive? TimePrimitive {get;set;}

    [XmlElement("styleUrl")]
    public KmlStyleUri? StyleUrl {get;set;}

    [XmlElement]
    public KmlSubStyle? StyleSelector {get;set;}

    public KmlRegion? Region {get;set;}

    public KmlExtendedData? ExtendedData {get;set;}
}
