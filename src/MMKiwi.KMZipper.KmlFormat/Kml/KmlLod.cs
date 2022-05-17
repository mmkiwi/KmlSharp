namespace MMKiwi.KMZipper.KmlFormat.Kml;

public class KmlLod:KmlAbstractObject
{
    public double MidLodPixels { get; set; } = 0;
    public double MaxLodPixels { get; set; } = -1;
    public double MinFadeExtent { get; set; } = 0;
    public double MaxFadeExtent { get; set; } = 0;
}