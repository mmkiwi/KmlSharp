// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Serialization;

internal interface IAbstractSerializationHelper<T>
{

    Task WriteAbstractAttributesAsync(XmlWriter writer, T o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default);
    Task WriteAbstractElementsAsync(XmlWriter writer, T o, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default);
    Task<bool> ReadAbstractAttributesAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded, CancellationToken ct = default);
    Task<bool> ReadAbstractElementsAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded, CancellationToken ct = default);

}

#if NET7_0_OR_GREATER
internal interface IAbstractSerializationHelperStatic<T>
{
    static abstract Task WriteAbstractAttributesAsync(XmlWriter writer, T o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default);

    static abstract Task WriteAbstractElementsAsync(XmlWriter writer, T o, KmlWriteOptions options, XmlNamespaceManager? ns = null, CancellationToken ct = default);
    static abstract Task<bool> ReadAbstractAttributesAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded, CancellationToken ct = default);
    static abstract Task<bool> ReadAbstractElementsAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded, CancellationToken ct = default);
}

#endif
