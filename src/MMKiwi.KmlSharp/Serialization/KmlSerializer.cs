// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using AtomObj = MMKiwi.KmlSharp.Atom;
using KmlObj = MMKiwi.KmlSharp.Kml;

namespace MMKiwi.KmlSharp.Serialization;
public static partial class KmlSerializer
{
    private static Dictionary<Type, Lazy<object>> Serializers { get; }

    static KmlSerializer()
    {
        Serializers = new();
        AddSerializer<AtomObj.AtomAuthor, Atom.AtomAuthorSerializer>();
        AddSerializer<AtomObj.AtomLink, Atom.AtomLinkSerializer>();
        AddSerializer<KmlObj.KmlLineStyle, Kml.KmlLineStyleSerializer>();
        AddSerializer<KmlObj.KmlLabelStyle, Kml.KmlLabelStyleSerializer>();
        AddSerializer<KmlObj.KmlPolyStyle, Kml.KmlPolyStyleSerializer>();
        AddSerializer<KmlObj.KmlItemIcon, Kml.KmlItemIconSerializer>();
        AddSerializer<KmlObj.KmlListStyle, Kml.KmlListStyleSerializer>();
        AddSerializer<KmlObj.KmlScale, Kml.KmlScaleSerializer>();
        AddSerializer<KmlObj.KmlLod, Kml.KmlLodSerializer>();
        AddSerializer<KmlObj.KmlOrientation, Kml.KmlOrientationSerializer>();
    }

    private static void AddSerializer<TObject, THelper>()
        where THelper : ISerializationHelper<TObject>, new()
        where TObject : class
    {
        Serializers.Add(typeof(TObject), new(() => new THelper()));
    }

    public static async Task SerializeAsync<T>(T obj, XmlWriter writer, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null)
    where T : class
    {
        ISerializationHelper<T>? serializationHelper = GetSerializer<T>();
        if (serializationHelper == null)
            throw new ArgumentException($"Could not find serializer for {typeof(T)}", nameof(obj));

        await serializationHelper.WriteRootTagAsync(writer, obj, ns, options).ConfigureAwait(false);
        writer.Flush();
    }

    public static async Task<T?> DeserializeAsync<T>(XmlReader reader)
    where T : class
    {
        ISerializationHelper<T>? serializationHelper = GetSerializer<T>();
        return serializationHelper != null
            ? await serializationHelper.ReadRootTagAsync(reader).ConfigureAwait(false)
            : throw new ArgumentException($"Could not find serializer for {typeof(T)}", nameof(T));
    }

    private static ISerializationHelper<T>? GetSerializer<T>()
    where T : class
    {
        return Serializers.ContainsKey(typeof(T)) ? Serializers[typeof(T)].Value as ISerializationHelper<T> : null;
    }
}
