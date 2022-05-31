// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlLodTests
{
    [Fact]
    public async Task SerializeWithUnknown()
    {
        KmlLod style = new();
        style.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        style.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Lod", Namespaces.Kml),
                new XAttribute(XName.Get("style", Namespaces.Html), "display:none;"),
                new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph")
            )
        ));
    }

    [Fact]
    public async Task DeserializeWithUnknown()
    {
        const string xml = $"""
            <Lod xmlns="{Namespaces.Kml}" xmlns:html="{Namespaces.Html}" html:style="display:none;" >
                <html:p>This is an HTML paragraph</html:p>
            </Lod>
            """;

        KmlLod labelStyle = new();
        labelStyle.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        labelStyle.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        KmlLod? compObject = await xml.Deserialize<KmlLod>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlLod style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Lod", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlLod style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Lod", Namespaces.Kml),
                new XElement(XName.Get("minLodPixels", Namespaces.Kml), 0),
                new XElement(XName.Get("maxLodPixels", Namespaces.Kml), -1),
                new XElement(XName.Get("minFadeExtent", Namespaces.Kml), 0),
                new XElement(XName.Get("maxFadeExtent", Namespaces.Kml), 0))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlLod style = new()
        {
            Id = "TestId",
            TargetId = "#fakeTarget",
            MinLodPixels = 50.25,
            MaxLodPixels = 200.65,
            MinFadeExtent = 12.1,
            MaxFadeExtent = double.PositiveInfinity
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Lod", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("minLodPixels", Namespaces.Kml), 50.25),
                new XElement(XName.Get("maxLodPixels", Namespaces.Kml), 200.65),
                new XElement(XName.Get("minFadeExtent", Namespaces.Kml), 12.1),
                new XElement(XName.Get("maxFadeExtent", Namespaces.Kml), "INF"))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <Lod xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlLod>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <Lod xmlns="{Namespaces.Kml}" />
            """;
        KmlLod labelStyle = new();
        KmlLod? compObject = await xml.Deserialize<KmlLod>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <Lod xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <minLodPixels>8.25</minLodPixels>
                <maxLodPixels>100.6</maxLodPixels>
                <minFadeExtent>7.2</minFadeExtent>
                <maxFadeExtent>88.1</maxFadeExtent>
            </Lod>
            """;
        KmlLod labelStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            MinLodPixels = 8.25,
            MaxLodPixels = 100.6,
            MinFadeExtent = 7.2,
            MaxFadeExtent = 88.1
        };
        KmlLod? compObject = await xml.Deserialize<KmlLod>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }
}
