
using MMKiwi.KMZipper.KmlFormat;
using MMKiwi.KMZipper.KmlFormat.Utilities;

using System.Xml.Linq;
using System.Xml.Serialization;

namespace MMKiwi.KMZipper.OGCKmlTests;

internal static class Helpers
{


    public static XDocument ToXDocument<T>(this T input)
        where T:class, IKmlBase
    {

        using MemoryStream memStm = new();

        input.Serialize(memStm);

        memStm.Position = 0;

        return XDocument.Load(memStm);
    }

}