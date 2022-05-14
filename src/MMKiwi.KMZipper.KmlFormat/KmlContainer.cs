namespace MMKiwi.KMZipper.KmlFormat;

public abstract class KmlContainer: KmlFeature
{
    [XmlElement(typeof(KmlDocument))]
    [XmlElement(typeof(KmlPlacemark))]
    [XmlElement(typeof(KmlFolder))]
    public List<KmlFeature> ChildFeatures { get; set; } = new();

}