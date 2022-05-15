namespace MMKiwi.KMZipper.KmlFormat.Utilities;

internal class XmlReaderHelper
{
    public XmlReaderHelper(XmlReader reader, bool isAsync)
    {
        Reader = reader;
        IsAsync = isAsync;
    }

    public XmlReader Reader { get; }
    public bool IsAsync { get; }


}