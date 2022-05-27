// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Xml.Linq;

using MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlAbstractObjectSerializer : IAbstractSerializationHelper<KmlAbstractObject>
#if NET7_0_OR_GREATER
, IAbstractSerializationHelperStatic<KmlAbstractObject>
#endif
{
    public static async Task<bool> ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded, CancellationToken ct = default)
    {
        if (HelpExtensions.CheckAttributeName(reader, "id", Namespaces.Kml, alreadyLoaded))
            o.Id = new(await HelpExtensions.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false));
        else if (HelpExtensions.CheckAttributeName(reader, "targetId", Namespaces.Kml, alreadyLoaded))
            o.TargetId = await HelpExtensions.ReadAttributeString(reader, alreadyLoaded).ConfigureAwait(false);
        else
            return false;
        return true;
    }

    public static async Task WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractObject o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default)
    {
        if (o.Id != null)
            await writer.WriteAttributeStringAsync(prefix, "id", Namespaces.Kml, o.Id).ConfigureAwait(false);
        if (o.TargetId != null)
            await writer.WriteAttributeStringAsync(prefix, "targetId", Namespaces.Kml, o.TargetId).ConfigureAwait(false);
        foreach ((XName name, string value) in o.UnknownAttributes)
        {
            string? attPrefix = options.EmitAttributeNamespaces || name.NamespaceName != Namespaces.Kml
                                ? ns?.LookupPrefix(name.NamespaceName) ?? ""
                                : "";
            await writer.WriteAttributeStringAsync(attPrefix, name.LocalName, name.NamespaceName, value).ConfigureAwait(false);
        }
    }
    public static async Task WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractObject o, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default)
    {
        foreach (XElement elem in o.UnknownElements)
            await elem.WriteToAsync(writer, ct).ConfigureAwait(false);
    }

    public static Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded, CancellationToken ct = default)
        => Task.FromResult(false);

    internal static async Task LoadUnknownElementAsync(XmlReader reader, KmlAbstractObject o, CancellationToken ct)
    {
        using XmlReader subReader = reader.ReadSubtree();
        XElement el = await XElement.LoadAsync(subReader, LoadOptions.None, ct).ConfigureAwait(false);
        o.UnknownElements.Add(el);
    }

    internal static void LoadUnknownAttribueAsync(XmlReader reader, KmlAbstractObject o)
    {
        if (reader.NodeType != XmlNodeType.Attribute)
            throw new InvalidOperationException($"{nameof(LoadUnknownAttribueAsync)}() can only be called if the reader is on an attribute node");
        if (reader.LocalName == "xmlns" || reader.Prefix == "xmlns")
            return;
        o.UnknownAttributes.Add(XName.Get(reader.LocalName, reader.NamespaceURI), reader.Value);
    }

    Task<bool> IAbstractSerializationHelper<KmlAbstractObject>.ReadAbstractAttributesAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractAttributesAsync(reader, o, alreadyLoaded, ct);

    Task IAbstractSerializationHelper<KmlAbstractObject>.WriteAbstractAttributesAsync(XmlWriter writer, KmlAbstractObject o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractAttributesAsync(writer, o, prefix, options, ns, ct);

    Task IAbstractSerializationHelper<KmlAbstractObject>.WriteAbstractElementsAsync(XmlWriter writer, KmlAbstractObject o, KmlWriteOptions options, XmlNamespaceManager? ns, CancellationToken ct)
        => WriteAbstractElementsAsync(writer, o, options, ns, ct);

    Task<bool> IAbstractSerializationHelper<KmlAbstractObject>.ReadAbstractElementsAsync(XmlReader reader, KmlAbstractObject o, HashSet<string> alreadyLoaded, CancellationToken ct)
        => ReadAbstractElementsAsync(reader, o, alreadyLoaded, ct);
}
