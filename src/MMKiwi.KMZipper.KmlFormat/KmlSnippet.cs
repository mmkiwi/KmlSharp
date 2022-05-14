using System.ComponentModel;

namespace MMKiwi.KMZipper.KmlFormat;

public sealed class KmlSnippet {

    [XmlIgnore]
    public int? MaxLines { get;set;} = 2;

    [XmlText]
    public string? Text {get; set;}

    [XmlAttribute("maxLines", Namespace = "http://schemas.opengis.net/kml/2.3")]
    private string? MaxLinesAttr
    {
        get => MaxLines.HasValue ? MaxLines.Value.ToString() : null;
        set
        {
            if (value == null)
                MaxLines = null;
            else MaxLines = int.Parse(value);
        }
    }

    [EditorBrowsableAttribute(EditorBrowsableState.Never)]
    public bool ShouldSerializeMaxLinesAttr() => MaxLines.HasValue;
}