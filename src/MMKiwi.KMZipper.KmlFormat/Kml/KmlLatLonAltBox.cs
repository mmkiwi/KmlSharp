namespace MMKiwi.KMZipper.KmlFormat.Kml;

public class KmlLatLonAltBox : KmlAbstractLatLonBox
{
    public double MinAltitude { get; set; } = 0;
    public double MaxAltitude { get; set; } = 0;
    public KmlAltitudeMode AltitudeMode { get; set; } = KmlAltitudeMode.ClampToGround;
    public KmlSeaFloorAltitudeMode? SeaFloorAltitudeMode { get; set; }
}
