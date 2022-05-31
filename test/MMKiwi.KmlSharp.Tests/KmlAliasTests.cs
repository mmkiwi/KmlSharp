// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlAliasTests
{
    [Fact]
    public async Task SerializeWithUnknown()
    {
        KmlAlias style = new();
        style.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        style.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Alias", Namespaces.Kml),
                new XAttribute(XName.Get("style", Namespaces.Html), "display:none;"),
                new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph")
            )
        ));
    }

    [Fact]
    public async Task DeserializeWithUnknown()
    {
        const string xml = $"""
            <Alias xmlns="{Namespaces.Kml}" xmlns:html="{Namespaces.Html}" html:style="display:none;" >
                <html:p>This is an HTML paragraph</html:p>
            </Alias>
            """;

        KmlAlias labelStyle = new();
        labelStyle.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        labelStyle.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        KmlAlias? compObject = await xml.Deserialize<KmlAlias>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlAlias style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Alias", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlAlias style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Alias", Namespaces.Kml),
                new XElement(XName.Get("targetHref", Namespaces.Kml)),
                new XElement(XName.Get("sourceHref", Namespaces.Kml)))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlAlias style = new()
        {
            Id = "TestId",
            TargetId = "#fakeTarget",
            TargetHref ="#testTarget",
            SourceHref="#testSource"
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Alias", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("targetHref", Namespaces.Kml), "#testTarget"),
                new XElement(XName.Get("sourceHref", Namespaces.Kml), "#testSource"))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <Alias xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlAlias>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <Alias xmlns="{Namespaces.Kml}" />
            """;
        KmlAlias labelStyle = new();
        KmlAlias? compObject = await xml.Deserialize<KmlAlias>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <Alias xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <targetHref>#testTarget</targetHref>
                <sourceHref>#testSource</sourceHref>
            </Alias>
            """;
        KmlAlias labelStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            TargetHref = "#testTarget",
            SourceHref = "#testSource"
        };
        KmlAlias? compObject = await xml.Deserialize<KmlAlias>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }
}
