using System.ComponentModel;

namespace MMKiwi.KMZipper.KmlFormat;

public abstract class KmlFeature: KmlObject
{
    private string? description;

    internal protected KmlFeature() //Don't allow other assemblies to subclass
    {

    }

    [XmlElement("name", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public string? Name { get; set; }

    [XmlElement("visibility", Namespace = "http://schemas.opengis.net/kml/2.3")]
    public bool? Visibility { get; set; }
    
    [EditorBrowsableAttribute(EditorBrowsableState.Never)]
    public bool ShouldSerializeVisibility() => Visibility.HasValue;

    [XmlElement("open", Namespace = "http://schemas.opengis.net/kml/2.3")]
    public bool? Open { get; set; }

    [EditorBrowsableAttribute(EditorBrowsableState.Never)]
    public virtual bool ShouldSerializeOpen() => Open.HasValue;

    [XmlElement("address", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public string? Address { get; set; }

    [XmlElement("phoneNumber", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public string? PhoneNumber { get; set; }

    [XmlElement("Snippet", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public KmlSnippet? Snippet { get; set; }

    [XmlElement("description", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public XmlCDataSection? Description
    {
        get => description == null ? null : new XmlDocument().CreateCDataSection(description);
        set => description = value?.Value;
    }
    [XmlElement("AbstractView", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public KmlCamera? AbstractView {get;set;}

    [XmlElement("TimePrimitive", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public KmlTimePrimitive? TimePrimitive {get;set;}

    [XmlElement("styleUrl", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public KmlStyleUri? StyleUrl {get;set;}

    [XmlElement("StyleSelector", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public KmlSubStyle? StyleSelector {get;set;}

    [XmlElement("Region", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public KmlRegion? Region {get;set; }

    [XmlElement("ExtendedData", Namespace = "http://schemas.opengis.net/kml/2.3", IsNullable = false)]
    public KmlExtendedData? ExtendedData {get;set;}
}
