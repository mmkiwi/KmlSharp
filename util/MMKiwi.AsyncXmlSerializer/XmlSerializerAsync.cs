namespace MMKiwi.AsyncXmlSerializer;

public static class XmlSerializerAsync
{
    public static async Task SerializeAsync<T>(this T o, XmlWriter writer)
        where T : IXmlSerializableAsync => await o.WriteXmlAsync(writer);

    public static async Task<T> DeserializeAsync<T>(this XmlReader reader)
    where T : IXmlSerializableAsync ,new()
    {
        T o = new();
        await o.ReadXmlAsync(reader);
        return o;
    }
}