// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization;
internal class KmlUpdateSerializer : SerializationHelper<KmlNetworkLinkControl>
#if NET7_0_OR_GREATER
    , ISerializationHelperStatic<KmlNetworkLinkControl>
#endif
{
    public static string StaticTag => "Update";

    protected override string Tag => StaticTag;

    public static Task<KmlNetworkLinkControl> StaticReadTagAsync(XmlReader reader)
    {
        throw new NotImplementedException();
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