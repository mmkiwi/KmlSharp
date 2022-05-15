namespace MMKiwi.KMZipper.KmlFormat;

[XmlRoot("Folder")]
public class KmlFolder : KmlContainer
{
    public override string TagName => "Folder";
}