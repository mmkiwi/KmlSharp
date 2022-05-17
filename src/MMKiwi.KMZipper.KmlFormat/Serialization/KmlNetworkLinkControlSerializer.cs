using System;
using System.Collections.Generic;
using System.Text;

using MMKiwi.KMZipper.KmlFormat.Kml;

namespace MMKiwi.KMZipper.KmlFormat.Serialization;
internal class KmlNetworkLinkControlSerializer : SerializationHelper<KmlNetworkLinkControl>
#if NET7_0_OR_GREATER
    ,ISerializationHelperStatic<KmlNetworkLinkControl>
#endif
{
    public static string StaticTag => "NetworkLinkControlSerializer";

    protected override string Tag => StaticTag;

    public static async Task<KmlNetworkLinkControl> StaticReadTagAsync(XmlReader reader)
    {
        _ = reader.MoveToElement();
        if (reader.IsEmptyElement)
            throw new InvalidDataException("<atom:author /> requires name element");

        KmlNetworkLinkControl o = new();

        HashSet<string> alreadyLoadedAtt = new();
        while (reader.MoveToNextAttribute())
        {
            await KmlObjectSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoadedAtt);
        }

        HashSet<string> alreadyLoaded = new();
        reader.ReadStartElement();
        while (await reader.MoveToContentAsync() is not XmlNodeType.EndElement and not XmlNodeType.None)
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                do
                {
                    if (Helpers.CheckElementName(reader, "minRefreshPeriod", Namespaces.Kml, alreadyLoaded))
                        o.MinRefreshPeriod = double.Parse(await Helpers.ReadElementStringAsync(reader, alreadyLoaded));
                    else if (Helpers.CheckElementName(reader, "maxSessionlength", Namespaces.Kml, alreadyLoaded))
                        o.MaxSessionLength = double.Parse(await Helpers.ReadElementStringAsync(reader, alreadyLoaded));
                    else if (Helpers.CheckElementName(reader, "cookie", Namespaces.Kml, alreadyLoaded))
                        o.Cookie = await Helpers.ReadElementStringAsync(reader, alreadyLoaded);
                    else if (Helpers.CheckElementName(reader, "message", Namespaces.Kml, alreadyLoaded))
                        o.Message = await Helpers.ReadElementStringAsync(reader, alreadyLoaded);
                    else if (Helpers.CheckElementName(reader, "linkName", Namespaces.Kml, alreadyLoaded))
                        o.LinkName = await Helpers.ReadElementStringAsync(reader, alreadyLoaded);
                    else if (Helpers.CheckElementName(reader, "linkDescription", Namespaces.Kml, alreadyLoaded))
                        o.LinkDescription = await Helpers.ReadElementStringAsync(reader, alreadyLoaded);
                    else if (Helpers.CheckElementName(reader, "linkSnipper", Namespaces.Kml, alreadyLoaded))
                        o.LinkSnippet = await Helpers.ReadElementStringAsync(reader, alreadyLoaded);
                    else if (Helpers.CheckElementName(reader, "expires", Namespaces.Kml, alreadyLoaded))
                        o.Expires = Helpers.ToDateTime(await Helpers.ReadElementStringAsync(reader, alreadyLoaded));
                    else if (Helpers.CheckElementName(reader, "email", Namespaces.Kml, alreadyLoaded))
                    {
                        
                    }

                } while (false);
            }
        }
        reader.ReadEndElement();
        return o;
    }

    public static Task StaticWriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns = null)
    {
        throw new NotImplementedException();
    }

    public override Task<KmlNetworkLinkControl> ReadTagAsync(XmlReader reader) => StaticReadTagAsync(reader);

    public override Task WriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns = null) => StaticWriteTagAsync(writer, o, ns);
}
