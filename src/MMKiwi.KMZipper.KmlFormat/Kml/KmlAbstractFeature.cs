namespace MMKiwi.KMZipper.KmlFormat.Kml;

public abstract class KmlAbstractFeature : KmlAbstractObject
{
    public string? Name { get; set; }
    public bool Visibility { get; set; } = true;

    public bool BalloonVisibility { get; set; } = true;

    public bool Open { get; set; } = false;

    public Atom.AtomAuthor? Author { get; set; }

    public Atom.AtomLink? Link { get; set; }

    public string? Address { get; set; }

    public Xal.XalAddressDetails? AddressDetails { get; set; }

    public string? Snippet { get; set; }

    public string? Description { get; set; }

    public KmlAbstractView? Viewpoint { get; set; }

    public KmlAbstractTime? TimePrimitive { get; set; }

    public Uri? StyleUrl { get; set; }

    public List<KmlAbstractStyleSelector>? StyleSelector { get; set; }

    public KmlRegion? Region { get; set; }
}
