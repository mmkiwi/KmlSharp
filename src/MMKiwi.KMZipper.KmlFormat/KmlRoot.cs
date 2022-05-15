using MMKiwi.AsyncXmlSerializer;

namespace MMKiwi.KMZipper.KmlFormat;

[AutoXmlSerialize]
public sealed class KmlRoot : KmlBase
{
    public string? Hint { get; set; }

    public KmlVersion? Version { get; set; } = new(2, 3, 0);

    public KmlFeature? RootFeature { get; set; }

    public KmlNetworkLinkControl? NetworkLinkControl { get; set; }

    public override string TagName => "kml";

    private protected override Task<UnknownNodes> ReadXmlAsyncImpl(XmlReaderHelper reader)
    {
        throw new NotImplementedException();
    }
    private protected override async Task WriteXmlAsyncImpl(XmlWriterHelper writer) 
    {
        await writer.WriteStartElementAsync("kml");
        if(!string.IsNullOrEmpty(Hint))
            await writer.WriteAttributeAsync("hint", Hint);
        if (Version != null)
            await writer.WriteAttributeAsync("version", Version.ToString());
        if(NetworkLinkControl != null)
        {
            await writer.WriteStartElementAsync(NetworkLinkControl.TagName);
            await NetworkLinkControl.WriteXmlAsync(writer);
            await writer.WriteEndElementAsync();
        }    
        if(RootFeature != null)
        {
            await writer.WriteStartElementAsync(RootFeature.TagName);
            await RootFeature.WriteXmlAsync(writer);
            await writer.WriteEndElementAsync();
        }
        await writer.WriteEndElementAsync();
    }
}
