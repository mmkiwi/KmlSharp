namespace MMKiwi.KMZipper.KmlFormat.Atom;

[Serializable]
[XmlType(Namespace = Namespaces.Atom)]
[XmlRoot("author", Namespace = Namespaces.Atom, IsNullable = false)]
public partial class AtomAuthor
{
    internal AtomAuthor() { Name = null!; }
    public AtomAuthor(string name) => Name = name;
    public string Name { get; set; } 

    [XmlElement(IsNullable =false)]
    public string? Email { get; set; }
    [XmlElement(IsNullable = false)]
    public Uri? Uri { get; set; }

}
