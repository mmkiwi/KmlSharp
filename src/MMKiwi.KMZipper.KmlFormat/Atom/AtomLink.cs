namespace MMKiwi.KMZipper.KmlFormat.Atom;

[Serializable]
[XmlType(AnonymousType = true, Namespace = Namespaces.Atom)]
[XmlRoot("link", Namespace = Namespaces.Atom, IsNullable = false)]
public partial class AtomLink
{
    internal AtomLink() { Href = null!; }
    [XmlAttribute("href")]
    public Uri Href { get; set; }

    public AtomLink(Uri href)
    {
        Href = href;
    }

    [XmlAttribute("rel")]
    public string? Rel { get; set; }


    [XmlAttribute("type")]
    public string? Type { get; set; }


    [XmlAttribute("hreflang")]
    public string? HrefLang { get; set; }


    [XmlAttribute("title")]
    public string? Title { get; set; }


    [XmlAttribute("length")]
    public int? Length { get; set; }
}
