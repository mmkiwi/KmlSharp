// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KMZipper.KmlFormat.Serialization;

internal interface ISerializationHelper<T>
{
    Task WriteRootTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null);
    Task WriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null);
    Task<T> ReadTagAsync(XmlReader reader);
    Task<T?> ReadRootTagAsync(XmlReader reader);
}
#if NET7_0_OR_GREATER
internal interface ISerializationHelperStatic<T>
{
    static abstract string StaticTag { get; }
    static abstract Task StaticWriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null);
    static abstract Task<T> StaticReadTagAsync(XmlReader reader);
}
#endif

public record class KmlWriteOptions
{
    public bool EmitAttributeNamespaces { get; init; } = false;
    public bool EmitValuesWhenDefault { get; set; } = false;

    public static KmlWriteOptions Default => new();
}