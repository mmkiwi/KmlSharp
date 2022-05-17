namespace MMKiwi.KMZipper.KmlFormat.Kml;

public class KmlNetworkLink : KmlAbstractFeature
{
    public bool RefreshVisibility { get; set; } = false;
    public bool FlyToView { get; set; } = false;

    public KmlLink? Link { get; set; }
}