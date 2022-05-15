
using System.ComponentModel;

namespace MMKiwi.KMZipper.KmlFormat;

public sealed class KmlSnippet: KmlBase {

    public int? MaxLines { get;set;} = 2;

    public string Text { get; set; } = string.Empty;

    public override string TagName => "snippet";

    private protected override Task<UnknownNodes> ReadXmlAsyncImpl(XmlReaderHelper reader) => throw new NotImplementedException();
    private protected async override Task WriteXmlAsyncImpl(XmlWriterHelper writer)
    {
        await writer.WriteAttributeIfNotNullAsync("maxLines", MaxLines?.ToString());
        await writer.WriteStringAsync(Text);
    }
}