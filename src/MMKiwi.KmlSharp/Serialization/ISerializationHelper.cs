// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Serialization;

internal interface ISerializationHelper<T>
where T : class
{
    string Namespace { get; }
    string Tag { get; }
    async Task WriteRootTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)

    {
        string? prefix = ns?.LookupPrefix(Namespace) ?? "";
        writer.WriteStartDocument();
        if (o == null)
            await HelpExtensions.WriteEmptyElementAsync(writer, prefix, Tag, Namespace).ConfigureAwait(false);
        else
            await WriteTagAsync(writer, o, ns, options, ct).ConfigureAwait(false);

    }
    Task WriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default);
    Task<T> ReadTagAsync(XmlReader reader, CancellationToken ct = default);
    async Task<T?> ReadRootTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        T? o = null;
        if (reader.MoveToContent() == System.Xml.XmlNodeType.Element)
        {
            o = reader.LocalName == Tag && reader.NamespaceURI == Namespace
                ? await ReadTagAsync(reader, ct).ConfigureAwait(false)
                : throw new ArgumentException($"Tag {reader.LocalName} was not expected");
        }
        return o;
    }
}

#if NET7_0_OR_GREATER
internal interface ISerializationHelperStatic<T> : ISerializationHelper<T>
where T : class
{
    static new abstract string Namespace { get; }
    static new abstract string Tag { get; }
    static new abstract Task WriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default);
    static new abstract Task<T> ReadTagAsync(XmlReader reader, CancellationToken ct = default);
}
#endif

public record class KmlWriteOptions
{
    public bool EmitAttributeNamespaces { get; init; } = false;
    public bool EmitValuesWhenDefault { get; set; } = false;

    public static KmlWriteOptions Default => new();
}