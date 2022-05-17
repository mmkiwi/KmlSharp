namespace MMKiwi.KMZipper.KmlFormat.Atom;

public partial class AtomAuthor
{
    internal AtomAuthor() { Name = null!; }
    public AtomAuthor(string name) => Name = name;

    public string Name { get; set; } 
    public string? Email { get; set; }
    public Uri? Uri { get; set; }
}
