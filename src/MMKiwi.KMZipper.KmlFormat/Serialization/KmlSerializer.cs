using MMKiwi.KMZipper.KmlFormat.Atom;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMKiwi.KMZipper.KmlFormat.Serialization;
public static partial class KmlSerializer
{
    private static Dictionary<Type, Lazy<object>> Serializers { get; } 


    static KmlSerializer()
    {
        Serializers = new();
        AddSerializer<AtomAuthor,AtomAuthorSerializer>();
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

        await serializationHelper.WriteRootTagAsync(writer, obj, ns);
        writer.Flush();
    }

    public static async Task<T?> DeserializeAsync<T>(XmlReader reader)
    {
        ISerializationHelper<T>? serializationHelper = GetSerializer<T>();
        if (serializationHelper == null)
            throw new ArgumentException($"Could not find serializer for {typeof(T)}", nameof(T));

        return await serializationHelper.ReadRootTagAsync(reader);
    }

    private static ISerializationHelper<T>? GetSerializer<T>()
        => Serializers.ContainsKey(typeof(T)) ? Serializers[typeof(T)].Value as ISerializationHelper<T> : null;
}
