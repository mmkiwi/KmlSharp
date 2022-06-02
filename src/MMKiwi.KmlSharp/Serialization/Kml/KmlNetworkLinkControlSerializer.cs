// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlNetworkLinkControlSerializer : ISerializationHelper<KmlNetworkLinkControl>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlNetworkLinkControl>
#endif
{
    public static string Namespace => Namespaces.Kml;
    public static string Tag => "NetworkLinkControlSerializer";

    public static async Task<KmlNetworkLinkControl> ReadTagAsync(XmlReader reader, CancellationToken ct = default)
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
                if (HelpExtensions.CheckElementName(reader, "minRefreshPeriod", Namespaces.Kml, alreadyLoaded))
                    o.MinRefreshPeriod = double.Parse(await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false));

                else if (HelpExtensions.CheckElementName(reader, "maxSessionlength", Namespaces.Kml, alreadyLoaded))
                    o.MaxSessionLength = double.Parse(await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false));

                else if (HelpExtensions.CheckElementName(reader, "cookie", Namespaces.Kml, alreadyLoaded))
                    o.Cookie = await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                else if (HelpExtensions.CheckElementName(reader, "message", Namespaces.Kml, alreadyLoaded))
                    o.Message = await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                else if (HelpExtensions.CheckElementName(reader, "linkName", Namespaces.Kml, alreadyLoaded))
                    o.LinkName = await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                else if (HelpExtensions.CheckElementName(reader, "linkDescription", Namespaces.Kml, alreadyLoaded))
                    o.LinkDescription = await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                else if (HelpExtensions.CheckElementName(reader, "linkSnipper", Namespaces.Kml, alreadyLoaded))
                    o.LinkSnippet = await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false);

                else if (HelpExtensions.CheckElementName(reader, "expires", Namespaces.Kml, alreadyLoaded))
                    o.Expires = HelpExtensions.ToDateTime(await HelpExtensions.ReadElementStringAsync(reader, alreadyLoaded).ConfigureAwait(false));

                else if (HelpExtensions.CheckElementName(reader, "email", Namespaces.Kml, alreadyLoaded))
                {
                    await KmlAbstractObjectSerializer.LoadUnknownElementAsync(reader, o, ct).ConfigureAwait(false);
                }
            }
        }
        reader.ReadEndElement();
        return o;
    }

    public static Task WriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    Task ISerializationHelper<KmlNetworkLinkControl>.WriteTagAsync(XmlWriter writer, KmlNetworkLinkControl o, XmlNamespaceManager? ns, KmlWriteOptions? options, CancellationToken ct)
        => WriteTagAsync(writer, o, ns, options, ct);

    Task<KmlNetworkLinkControl> ISerializationHelper<KmlNetworkLinkControl>.ReadTagAsync(XmlReader reader, CancellationToken ct)
        => ReadTagAsync(reader, ct);

    string ISerializationHelper<KmlNetworkLinkControl>.Tag => Tag;
    string ISerializationHelper<KmlNetworkLinkControl>.Namespace => Namespace;
}
