// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Serialization;

internal interface IAbstractSerializationHelper<T>
{

    Task WriteAbstractAttributesAsync(XmlWriter writer, T o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null);
    Task WriteAbstractElementsAsync(XmlWriter writer, T o, KmlWriteOptions options, XmlNamespaceManager? ns = null);
    Task<bool> ReadAbstractAttributesAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded);
    Task<bool> ReadAbstractElementsAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded);

}

#if NET7_0_OR_GREATER
internal interface IAbstractSerializationHelperStatic<T>
{
    static abstract Task WriteAbstractAttributesAsync(XmlWriter writer, T o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null);

    static abstract Task WriteAbstractElementsAsync(XmlWriter writer, T o, KmlWriteOptions options, XmlNamespaceManager? ns = null);
    static abstract Task<bool> ReadAbstractAttributesAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded);
    static abstract Task<bool> ReadAbstractElementsAsync(XmlReader reader, T o, HashSet<string> alreadyLoaded);
}

#endif
