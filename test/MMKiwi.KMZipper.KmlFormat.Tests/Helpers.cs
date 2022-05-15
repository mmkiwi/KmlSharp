
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Diagnostics;
using MMKiwi.AsyncXmlSerializer;

namespace MMKiwi.KMZipper.KmlFormat.Tests;

internal static class Helpers
{


    public async static Task<XDocument> ToXDocument<T>(this T input)
        where T: IXmlSerializableAsync
    {

        using MemoryStream memStm = new();
        using XmlWriter writer = XmlWriter.Create(memStm, new()
        {
            Async = true,
            NamespaceHandling = NamespaceHandling.OmitDuplicates
        });
        await input.WriteXmlAsync(writer);

        memStm.Position = 0;

#if DEBUG
        StreamReader sr = new(memStm);
        var myStr = sr.ReadToEnd();
        Debug.WriteLine(myStr);
#endif

        memStm.Position = 0;
        return XDocument.Load(memStm);
    }

}