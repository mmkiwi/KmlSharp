namespace MMKiwi.KMZipper.KmlFormat.Kml;

public abstract class KmlAbstractLatLonBox : KmlAbstractExtent
{
    public double North { get; set; } = 90;
    public double South { get; set; } = -90;
    public double East { get; set; } = 180;
    public double West { get; set; } = -180;
}

