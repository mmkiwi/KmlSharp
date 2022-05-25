// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Diagnostics;

using MMKiwi.KmlSharp.Serialization;

namespace MMKiwi.KmlSharp.Tests;

internal static class Helpers
{

    public static async Task<T?> Deserialize<T>(this string input)
    {
        using StringReader str = new(input);
        using XmlReader? reader = XmlReader.Create(str, new XmlReaderSettings()
        {
            Async = true,
        });
        return await KmlSerializer.DeserializeAsync<T>(reader);
    }

    public static async Task<XDocument> ToXDocument<T>(this T input, KmlWriteOptions? options = null)
    {
        options ??= KmlWriteOptions.Default;
        XmlNamespaceManager? ns = new(new NameTable());
        ns.AddNamespace("", Namespaces.Kml);
        ns.AddNamespace("atom", Namespaces.Atom);
        ns.AddNamespace("html", Namespaces.Html);
        ns.AddNamespace("gx", Namespaces.GoogleExtensions);

        using MemoryStream memStm = new();
        using XmlWriter? writer = XmlWriter.Create(memStm, new()
        {
            Async = true,
            NamespaceHandling = NamespaceHandling.OmitDuplicates,
        });
        await KmlSerializer.SerializeAsync(input, writer, ns, options);

        memStm.Position = 0;

#if DEBUG
        StreamReader sr = new(memStm);
        string? myStr = sr.ReadToEnd();
        Debug.WriteLine(myStr);
#endif

        memStm.Position = 0;
        return XDocument.Load(memStm);
    }
}