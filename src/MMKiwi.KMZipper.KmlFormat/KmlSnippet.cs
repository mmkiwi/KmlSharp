namespace MMKiwi.KMZipper.KmlFormat;

public sealed class KmlSnippet {

    [XmlAttribute("maxLines")]
    public int MaxLines { get;set;} = 2;

    [XmlText]
    public string Text {get; set;}
}