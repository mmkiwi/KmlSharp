// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization;
internal class KmlNetworkLinkControlSerializer : SerializationHelper<KmlNetworkLinkControl>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlNetworkLinkControl>
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
            _ = await KmlObjectSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoadedAtt).ConfigureAwait(false);
        }

        HashSet<string> alreadyLoaded = new();
        reader.ReadStartElement();
        while (await reader.MoveToContentAsync().ConfigureAwait(false) is not XmlNodeType.EndElement and not XmlNodeType.None)
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                do
                {
                    if (Helpers.CheckElementName(reader, "minRefreshPeriod", Namespaces.Kml, alreadyLoaded))
                        o.MinRefreshPeriod = double.Parse(await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false));

                    else if (Helpers.CheckElementName(reader, "maxSessionlength", Namespaces.Kml, alreadyLoaded))
                        o.MaxSessionLength = double.Parse(await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false));

                    else if (Helpers.CheckElementName(reader, "cookie", Namespaces.Kml, alreadyLoaded))
                        o.Cookie = await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                    else if (Helpers.CheckElementName(reader, "message", Namespaces.Kml, alreadyLoaded))
                        o.Message = await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                    else if (Helpers.CheckElementName(reader, "linkName", Namespaces.Kml, alreadyLoaded))
                        o.LinkName = await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                    else if (Helpers.CheckElementName(reader, "linkDescription", Namespaces.Kml, alreadyLoaded))
                        o.LinkDescription = await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                    else if (Helpers.CheckElementName(reader, "linkSnipper", Namespaces.Kml, alreadyLoaded))
                        o.LinkSnippet = await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                    else if (Helpers.CheckElementName(reader, "expires", Namespaces.Kml, alreadyLoaded))
                        o.Expires = Helpers.ToDateTime(await Helpers.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false));

                    else if (Helpers.CheckElementName(reader, "email", Namespaces.Kml, alreadyLoaded))
                    {

                    }
                } while (false);
            }
        }
        reader.ReadEndElement();
        return o;
    }

    public static Task StaticWriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null)
    {
        throw new NotImplementedException();
    }

    public override Task<KmlNetworkLinkControl> ReadTagAsync(XmlReader reader)
    {
        return StaticReadTagAsync(reader);
    }

    public override Task WriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null)
    {
        return StaticWriteTagAsync(writer, o, ns, options);
    }
}
