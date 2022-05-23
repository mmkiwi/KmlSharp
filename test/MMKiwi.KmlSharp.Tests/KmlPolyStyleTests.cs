// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlPolyStyleTests
{
    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlPolyStyle style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("PolyStyle", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlPolyStyle style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("PolyStyle", Namespaces.Kml),
                new XElement(XName.Get("fill", Namespaces.Kml), true),
                new XElement(XName.Get("outline", Namespaces.Kml), true),
                new XElement(XName.Get("color", Namespaces.Kml), "ffffffff"),
                new XElement(XName.Get("colorMode", Namespaces.Kml), "normal"))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlPolyStyle style = new()
        {
            Color = Color.FromArgb(128, 16, 255, 72),
            ColorMode = KmlColorMode.Random,
            Id = "TestId",
            TargetId = "#fakeTarget",
            Fill = false,
            Outline = true
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("PolyStyle", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("fill", Namespaces.Kml), false),
                new XElement(XName.Get("color", Namespaces.Kml), "8048ff10"),
                new XElement(XName.Get("colorMode", Namespaces.Kml), "random"))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <PolyStyle xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlPolyStyle>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <PolyStyle xmlns="{Namespaces.Kml}" />
            """;
        KmlPolyStyle polyStyle = new();
        KmlPolyStyle? compObject = await xml.Deserialize<KmlPolyStyle>();
        _ = compObject.Should().BeEquivalentTo(polyStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <PolyStyle xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <fill>0</fill>
                <outline>1</outline>
                <color>64CDEBFF</color>
                <colorMode>random</colorMode>
            </PolyStyle>
            """;
        KmlPolyStyle polyStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            Fill = false,
            Outline = true,
            Color = Color.FromArgb(100, Color.BlanchedAlmond),
            ColorMode = KmlColorMode.Random
        };
        KmlPolyStyle? compObject = await xml.Deserialize<KmlPolyStyle>();
        _ = compObject.Should().BeEquivalentTo(polyStyle);
    }
}
