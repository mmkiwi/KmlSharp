using MMKiwi.AsyncXmlSerializer;

using System.Xml.Linq;

namespace MMKiwi.KMZipper.KmlFormat;

[AutoXmlSerialize]
public sealed class KmlRoot : KmlBase
{
    [XmlAttribute("hint")]
    public string? Hint { get; set; }

    public KmlVersion? Version { get; set; } = new(2, 3, 0);

    public KmlFeature? RootFeature { get; set; }

    public KmlNetworkLinkControl? NetworkLinkControl { get; set; }

    public override string TagName => "kml";

    private protected override async Task<UnknownNodes> ReadXmlAsyncImpl(XmlReaderHelper reader)
    {
        Hint = default;
        Version = default;
        RootFeature = default;
        NetworkLinkControl = default;
        List<UnknownAttribute> unknownAttributes = new();
        List<XmlElement> unknownElements = new();

        XmlNodeType content = await reader.Reader.MoveToContentAsync();

        if (content == XmlNodeType.Element && reader.Reader.LocalName == "kml")
        {
            while (reader.Reader.MoveToNextAttribute())
            {
                if (reader.Reader.HasAttributes)
                {
                    switch (reader.Reader.LocalName)
                    {
                        case "hint":
                            Hint = reader.Reader.Value;
                            break;
                        case "version":
                            Version = reader.Reader.Value != null ? new(reader.Reader.Value) : null;
                            break;
                        case "xmlns": //ignore namespaces
                            break;
                        default:
                            unknownAttributes.Add(new(reader.Reader.LocalName, reader.Reader.NamespaceURI, reader.Reader.Prefix, reader.Reader.Value));
                            break;
                    }
                }
            }
            reader.Reader.MoveToElement();
            bool isEmptyElement = reader.Reader.IsEmptyElement;
            reader.Reader.ReadStartElement();
            if (!isEmptyElement) // (1)
            {
                while (reader.Reader.IsStartElement())
                {
                    if (reader.Reader.Name == "Document" && reader.Reader.NamespaceURI == KmlNs.Kml)
                    {
                        RootFeature = new KmlDocument();
                        await RootFeature.ReadXmlAsync(reader.Reader);
                    }
                    else if (reader.Reader.Name == "NetworkLinkControl" && reader.Reader.NamespaceURI == KmlNs.Kml)
                    {
                        NetworkLinkControl = new();
                        await NetworkLinkControl.ReadXmlAsync(reader.Reader);
                    }
                    reader.Reader.ReadEndElement();
                }
                reader.Reader.ReadEndElement();
            }
        }
        return new(Enumerable.Empty<XmlElement>(), Enumerable.Empty<XmlAttribute>());
    }
    private protected override async Task WriteXmlAsyncImpl(XmlWriterHelper writer)
    {
        await writer.WriteStartElementAsync("kml");
        if (!string.IsNullOrEmpty(Hint))
            await writer.WriteAttributeAsync("hint", Hint);
        if (Version != null)
            await writer.WriteAttributeAsync("version", Version.ToString());
        if (NetworkLinkControl != null)
        {
            await writer.WriteStartElementAsync(NetworkLinkControl.TagName);
            await NetworkLinkControl.WriteXmlAsync(writer);
            await writer.WriteEndElementAsync();
        }
        if (RootFeature != null)
        {
            await writer.WriteStartElementAsync(RootFeature.TagName);
            await RootFeature.WriteXmlAsync(writer);
            await writer.WriteEndElementAsync();
        }
        await writer.WriteEndElementAsync();
    }
}
