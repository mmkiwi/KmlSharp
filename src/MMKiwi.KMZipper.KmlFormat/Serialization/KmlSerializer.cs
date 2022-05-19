// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KMZipper.KmlFormat.Atom;

namespace MMKiwi.KMZipper.KmlFormat.Serialization;
public static partial class KmlSerializer
{
    private static Dictionary<Type, Lazy<object>> Serializers { get; }

    static KmlSerializer()
    {
        Serializers = new();
        AddSerializer<AtomAuthor, AtomAuthorSerializer>();
        AddSerializer<AtomLink, AtomLinkSerializer>();
    }

    private static void AddSerializer<TObject, THelper>()
        where THelper : ISerializationHelper<TObject>, new()
    {
        Serializers.Add(typeof(TObject), new(() => new THelper()));
    }

    public static async Task SerializeAsync<T>(T obj, XmlWriter writer, XmlNamespaceManager? ns = null)
    {
        ISerializationHelper<T>? serializationHelper = GetSerializer<T>();
        if (serializationHelper == null)
            throw new ArgumentException($"Could not find serializer for {typeof(T)}", nameof(obj));

        await serializationHelper.WriteRootTagAsync(writer, obj, ns).ConfigureAwait(false);
        writer.Flush();
    }

    public static async Task<T?> DeserializeAsync<T>(XmlReader reader)
    {
        ISerializationHelper<T>? serializationHelper = GetSerializer<T>();
        return serializationHelper != null
            ? await serializationHelper.ReadRootTagAsync(reader).ConfigureAwait(false)
            : throw new ArgumentException($"Could not find serializer for {typeof(T)}", nameof(T));
    }

    private static ISerializationHelper<T>? GetSerializer<T>()
    {
        return Serializers.ContainsKey(typeof(T)) ? Serializers[typeof(T)].Value as ISerializationHelper<T> : null;
    }
}
