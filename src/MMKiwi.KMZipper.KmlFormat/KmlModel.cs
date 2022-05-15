namespace MMKiwi.KMZipper.KmlFormat;

/// <summary>
/// Strong typing not supported. Use <see cref="KmlObject.OtherElements"/>
/// to access child elements.
/// </summary>
public class KmlModel : KmlGeometry
{
    public override string TagName => "KmlModel";
}