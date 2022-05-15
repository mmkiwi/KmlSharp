using System;
using System.Collections.Generic;
using System.Text;

namespace MMKiwi.KMZipper.KmlFormat.Utilities;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE2001:Embedded statements must be on their own line", Justification = "Shortens adapter class")]
internal class XmlWriterHelper
{
    public XmlWriterHelper(XmlWriter writer, bool isAsync)
    {
        Writer = writer;
        IsAsync = isAsync;
    }

    public XmlWriter Writer { get; }
    public bool IsAsync { get; }

    internal async Task WriteStartElementAsync(string localName, string ns = KmlNs.Kml, string prefix = "")
    {
        if (IsAsync) await Writer.WriteStartElementAsync(prefix, localName, ns);
        else Writer.WriteStartElement(prefix, localName, ns);
    }

    public async Task WriteAttributeIfNotNullAsync(string localName, string? value, string prefix = "", string ns = KmlNs.Kml)
    {
        if (value == null) return;
        await WriteAttributeAsync(localName, value, prefix, ns);
    }

    private async Task WriteElementIfNotNullAsync<T>(string localName, T value, Func<T, Task> writeAction, string prefix = "", string ns = KmlNs.Kml)
    {
        if (value == null) return;
        await WriteStartElementAsync(localName, ns, prefix);
        await writeAction(value);
        await WriteEndElementAsync();
    }

    private async Task WriteElementIfNotNullAsync<T>(string localName, T value, Action<T> writeAction, string prefix = "", string ns = KmlNs.Kml)
    {
        if (value == null) return;
        await WriteStartElementAsync(localName, prefix, ns);
        writeAction(value);
        await WriteEndElementAsync();
    }

    public Task WriteElementIfNotNullAsync(string localName, string? value, string prefix = "", string ns = KmlNs.Kml)
        => WriteElementIfNotNullAsync(localName, value, v => WriteStringAsync(v!), prefix, ns);
    public async Task WriteCDataAsync(string description) {
        if (IsAsync)
            await Writer.WriteCDataAsync(description);
        else
            Writer.WriteCData(description);
    }

    public Task WriteElementIfNotNullAsync(string localName, bool? value, string prefix = "", string ns = KmlNs.Kml)
        => WriteElementIfNotNullAsync(localName, value, v => Writer.WriteValue(v), prefix, ns);

    public Task WriteElementIfNotNullAsync(string localName, double? value, string prefix = "", string ns = KmlNs.Kml)
            => WriteElementIfNotNullAsync(localName, value, v => Writer.WriteValue(v), prefix, ns);

    public Task WriteElementIfNotNullAsync(string localName, int? value, string prefix = "", string ns = KmlNs.Kml)
        => WriteElementIfNotNullAsync(localName, value, v => Writer.WriteValue(v), prefix, ns);

    public Task WriteElementIfNotNullAsync(string localName, KmlBase? value, string prefix = "", string ns = KmlNs.Kml)
        => WriteElementIfNotNullAsync(localName, value, v => v!.WriteXmlAsync(this), prefix, ns);


    public async Task WriteStringAsync(string text)
    {
        if (IsAsync) await Writer.WriteStringAsync(text);
        else Writer.WriteString(text);
    }

    internal async Task WriteEndElementAsync()
    {
        if (IsAsync) await Writer.WriteEndElementAsync();
        else Writer.WriteEndElement();
    }

    public async Task WriteAttributeAsync(string localName, string? value, string prefix = "", string ns = "")
    {
        if (IsAsync) await Writer.WriteAttributeStringAsync(prefix, localName, ns, value);
        else Writer.WriteAttributeString(prefix, localName, ns, value);
    }

    /*
    public abstract void WriteBase64(byte[] buffer, int index, int count);
    public virtual Task WriteBase64Async(byte[] buffer, int index, int count);
    public virtual void WriteBinHex(byte[] buffer, int index, int count);
    public virtual Task WriteBinHexAsync(byte[] buffer, int index, int count);
    public abstract void WriteCData(string text);
    public virtual Task WriteCDataAsync(string text);
    public abstract void WriteCharEntity(char ch);
    public virtual Task WriteCharEntityAsync(char ch);
    public abstract void WriteChars(char[] buffer, int index, int count);
    public virtual Task WriteCharsAsync(char[] buffer, int index, int count);
    public abstract void WriteComment(string text);
    public virtual Task WriteCommentAsync(string text);
    public abstract void WriteDocType(string name, string pubid, string sysid, string subset);
    public virtual Task WriteDocTypeAsync(string name, string pubid, string sysid, string subset);
    public void WriteElementString(string localName, string value);
    public void WriteElementString(string localName, string ns, string value);
    public void WriteElementString(string prefix, string localName, string ns, string value);
    public Task WriteElementStringAsync(string prefix, string localName, string ns, string value);
    public abstract void WriteEndAttribute();
    public abstract void WriteEndDocument();
    public virtual Task WriteEndDocumentAsync();
    public abstract void WriteEndElement();
    public virtual Task WriteEndElementAsync();
    public abstract void WriteEntityRef(string name);
    public virtual Task WriteEntityRefAsync(string name);
    public abstract void WriteFullEndElement();
    public virtual Task WriteFullEndElementAsync();
    public virtual void WriteName(string name);
    public virtual Task WriteNameAsync(string name);
    public virtual void WriteNmToken(string name);
    public virtual Task WriteNmTokenAsync(string name);
    public virtual void WriteNode(XmlReader reader, bool defattr);
    public virtual void WriteNode(XPathNavigator navigator, bool defattr);
    public virtual Task WriteNodeAsync(XPathNavigator navigator, bool defattr);
    public virtual Task WriteNodeAsync(XmlReader reader, bool defattr);
    public abstract void WriteProcessingInstruction(string name, string text);
    public virtual Task WriteProcessingInstructionAsync(string name, string text);
    public virtual void WriteQualifiedName(string localName, string ns);
    public virtual Task WriteQualifiedNameAsync(string localName, string ns);
    public abstract void WriteRaw(char[] buffer, int index, int count);
    public abstract void WriteRaw(string data);
    public virtual Task WriteRawAsync(char[] buffer, int index, int count);
    public virtual Task WriteRawAsync(string data);
    public void WriteStartAttribute(string localName, string ns);
    public abstract void WriteStartAttribute(string prefix, string localName, string ns);
    public void WriteStartAttribute(string localName);
    public abstract void WriteStartDocument();
    public abstract void WriteStartDocument(bool standalone);
    public virtual Task WriteStartDocumentAsync();
    public virtual Task WriteStartDocumentAsync(bool standalone);
    public abstract void WriteStartElement(string prefix, string localName, string ns);
    public void WriteStartElement(string localName, string ns);
    public void WriteStartElement(string localName);
    public virtual Task WriteStartElementAsync(string prefix, string localName, string ns);
    public abstract void WriteString(string text);
    public virtual Task WriteStringAsync(string text);
    public abstract void WriteSurrogateCharEntity(char lowChar, char highChar);
    public virtual Task WriteSurrogateCharEntityAsync(char lowChar, char highChar);
    public virtual void WriteValue(string value);
    public virtual void WriteValue(float value);
    public virtual void WriteValue(object value);
    public virtual void WriteValue(long value);
    public virtual void WriteValue(decimal value);
    public virtual void WriteValue(DateTimeOffset value);
    public virtual void WriteValue(DateTime value);
    public virtual void WriteValue(bool value);
    public virtual void WriteValue(double value);
    public virtual void WriteValue(int value);
    public abstract void WriteWhitespace(string ws);
    public virtual Task WriteWhitespaceAsync(string ws);
    protected virtual void Dispose(bool disposing);
    protected internal virtual Task WriteEndAttributeAsync();
    protected internal virtual Task WriteStartAttributeAsync(string prefix, string localName, string ns);
    */
}
