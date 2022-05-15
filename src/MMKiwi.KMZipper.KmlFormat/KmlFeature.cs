using System.ComponentModel;

namespace MMKiwi.KMZipper.KmlFormat;

public abstract class KmlFeature: KmlObject
{
    internal protected KmlFeature() //Don't allow other assemblies to subclass
    {

    }

    public string? Name { get; set; }

    public bool? Visibility { get; set; }

    public bool? BalloonVisibility { get; set; }

    public bool? Open { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public KmlSnippet? Snippet { get; set; }

    public string? Description { get; set; }
    public KmlCamera? AbstractView {get;set;}

    public KmlTimePrimitive? TimePrimitive {get;set;}

    public KmlStyleUri? StyleUrl {get;set;}

    public KmlSubStyle? StyleSelector {get;set;}

    public KmlRegion? Region {get;set; }

    public KmlExtendedData? ExtendedData {get; set;}
    

    private protected override Task<UnknownNodes> ReadXmlAsyncImpl(XmlReaderHelper reader)
    {
        throw new NotImplementedException();
    }
    private protected override async Task WriteXmlAsyncImpl(XmlWriterHelper writer)
    {
        await writer.WriteElementIfNotNullAsync("name", Name);
        await writer.WriteElementIfNotNullAsync("visibility", Visibility);
        await writer.WriteElementIfNotNullAsync("balloonVisibility", BalloonVisibility);
        await writer.WriteElementIfNotNullAsync("open", Open);
        await writer.WriteElementIfNotNullAsync("address", Address);
        await writer.WriteElementIfNotNullAsync("phoneNumber", PhoneNumber);
        await writer.WriteElementIfNotNullAsync("snippet", Snippet);

        if (Description != null) {
            await writer.WriteStartElementAsync("description");
            await writer.WriteCDataAsync(Description);
            await writer.WriteEndElementAsync();
        }

        await base.WriteXmlAsyncImpl(writer);
    }
}
