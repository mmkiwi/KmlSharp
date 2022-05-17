using MMKiwi.KMZipper.KmlFormat.Kml;

namespace MMKiwi.KMZipper.KmlFormat.Serialization;
internal class KmlUpdateSerializer : SerializationHelper<KmlNetworkLinkControl>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlNetworkLinkControl>
#endif
{
{
    public static string StaticTag => "Update";

    protected override string Tag => StaticTag;

    public static Task<KmlNetworkLinkControl> StaticReadTagAsync(XmlReader reader)
    {
        throw new NotImplementedException();
    }

    public static Task StaticWriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns = null)
    {
        throw new NotImplementedException();
    }

    public override Task<KmlNetworkLinkControl> ReadTagAsync(XmlReader reader)
    {
        throw new NotImplementedException();
    }

    public override Task WriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns = null)
    {
        throw new NotImplementedException();
    }
}