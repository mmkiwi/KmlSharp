// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlNetworkLinkControlSerializer : SerializationHelper<KmlNetworkLinkControl>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlNetworkLinkControl>
#endif
{
    protected override string Namespace => StaticNamespace;
    public static string StaticNamespace => Namespaces.Kml;
    protected override string Tag => StaticTag;

    public static string StaticTag => "NetworkLinkControlSerializer";

    public static async Task<KmlNetworkLinkControl> StaticReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        _ = reader.MoveToElement();
        if (reader.IsEmptyElement)
            throw new InvalidDataException("<kml:NetworkLinkControlSerializer /> requires name element");

        KmlNetworkLinkControl o = new();

        HashSet<string> alreadyLoadedAtt = new();
        while (reader.MoveToNextAttribute())
        {
            if (!await KmlAbstractObjectSerializer.ReadAbstractAttributesAsync(reader, o, alreadyLoadedAtt, ct).ConfigureAwait(false))
                KmlAbstractObjectSerializer.LoadUnknownAttribueAsync(reader, o);
        }

        HashSet<string> alreadyLoaded = new();
        reader.ReadStartElement();
        while (await reader.MoveToContentAsync().ConfigureAwait(false) is not XmlNodeType.EndElement and not XmlNodeType.None)
        {
            ct.ThrowIfCancellationRequested();
            if (reader.NodeType == XmlNodeType.Element)
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
                    await KmlAbstractObjectSerializer.LoadUnknownElementAsync(reader, o, ct).ConfigureAwait(false);
                }
            }
        }
        reader.ReadEndElement();
        return o;
    }

    public static Task StaticWriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public override Task<KmlNetworkLinkControl> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        return StaticReadTagAsync(reader, ct);
    }

    public override Task WriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        return StaticWriteTagAsync(writer, o, ns, options, ct);
    }
}
