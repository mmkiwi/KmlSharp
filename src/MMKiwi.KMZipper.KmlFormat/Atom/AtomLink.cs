namespace MMKiwi.KMZipper.KmlFormat.Atom;

public partial class AtomLink
{
    internal AtomLink() { Href = null!; }
    public AtomLink(Uri href) => Href = href;

    public Uri Href { get; set; }
    public string? Rel { get; set; }
    public string? Type { get; set; }
    public string? HrefLang { get; set; }
    public string? Title { get; set; }
    public int? Length { get; set; }
}
