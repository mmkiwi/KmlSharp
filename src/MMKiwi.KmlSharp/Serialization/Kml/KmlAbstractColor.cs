using System.Drawing;

using MMKiwi.KmlSharp.Kml;

using KmlObj = MMKiwi.KmlSharp.Kml.KmlAbstractColorStyle;
namespace MMKiwi.KmlSharp.Serialization.Kml;
internal class KmlAbstractColor : IAbstractSerializationHelper<KmlObj>
#if NET7_0_OR_GREATER
, IAbstractSerializationHelperStatic<KmlObj>
#endif
{
    public static async Task<bool> ReadAbstractElementsAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
    {
        if (Helpers.CheckElementName(reader, "color", Namespaces.Kml, alreadyLoaded))
            o.Color = await Helpers.ReadElementColorAsync(reader, alreadyLoaded)
                                   .ConfigureAwait(false);
        else if (Helpers.CheckElementName(reader, "colorMode", Namespaces.Kml, alreadyLoaded))
            o.ColorMode = await Helpers.ReadElementEnumAsync<KmlColorMode>(reader, alreadyLoaded)
                                       .ConfigureAwait(false);
        else return false;
        return true;
    }

    public static async Task WriteAbstractElementsAsync(XmlWriter writer, KmlObj o, KmlWriteOptions options,
        XmlNamespaceManager? ns = null)
    {
        string? prefix = ns?.LookupPrefix(Namespaces.Kml) ?? "";
        if (o.Color != Color.White || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "color", Namespaces.Atom, o.Color.ToKmlString())
                        .ConfigureAwait(false);
        if (o.ColorMode != KmlColorMode.Normal || options.EmitValuesWhenDefault)
            await writer.WriteElementStringAsync(prefix, "colorMode", Namespaces.Atom, o.ColorMode.ToKmlString())
                        .ConfigureAwait(false);
    }

    public static Task<bool> ReadAbstractAttributesAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded) 
        => Task.FromResult(false);

    public static Task WriteAbstractAttributesAsync(XmlWriter writer, KmlObj o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns = null)
        => Task.CompletedTask;

    Task IAbstractSerializationHelper<KmlObj>.WriteAbstractAttributesAsync(XmlWriter writer, KmlObj o, string prefix, KmlWriteOptions options, XmlNamespaceManager? ns)
        => WriteAbstractAttributesAsync(writer, o, prefix, options, ns);
    Task IAbstractSerializationHelper<KmlObj>.WriteAbstractElementsAsync(XmlWriter writer, KmlObj o, KmlWriteOptions options, XmlNamespaceManager? ns)
        => WriteAbstractElementsAsync(writer, o, options, ns);
    Task<bool> IAbstractSerializationHelper<KmlObj>.ReadAbstractAttributesAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
        => ReadAbstractAttributesAsync(reader, o, alreadyLoaded);
    Task<bool> IAbstractSerializationHelper<KmlObj>.ReadAbstractElementsAsync(XmlReader reader, KmlObj o, HashSet<string> alreadyLoaded)
        => ReadAbstractElementsAsync(reader, o, alreadyLoaded);
}