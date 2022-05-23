// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;
using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlLineStyleTests
{
    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlLineStyle style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("LineStyle", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlLineStyle style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions{
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("LineStyle", Namespaces.Kml),
                new XElement(XName.Get("width", Namespaces.Kml), 1),
                new XElement(XName.Get("color", Namespaces.Kml), "ffffffff"),
                new XElement(XName.Get("colorMode", Namespaces.Kml), "normal"))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlLineStyle style = new(){
            Color = Color.FromArgb(128, 16, 255, 72),
            ColorMode = KmlColorMode.Random,
            Id = "TestId",
            TargetId = "#fakeTarget",
            Width = 700
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("LineStyle", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("width", Namespaces.Kml), 700),
                new XElement(XName.Get("color", Namespaces.Kml), "8048ff10"),
                new XElement(XName.Get("colorMode", Namespaces.Kml), "random"))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <LineStyle xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlLineStyle>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <LineStyle xmlns="{Namespaces.Kml}" />
            """;
        KmlLineStyle lineStyle = new();
        KmlLineStyle? compObject = await xml.Deserialize<KmlLineStyle>();
        _ = compObject.Should().BeEquivalentTo(lineStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <LineStyle xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <width>100.75</width>
                <color>64CDEBFF</color>
                <colorMode>random</colorMode>
            </LineStyle>
            """;
        KmlLineStyle lineStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            Width=100.75,
            Color = Color.FromArgb(100, Color.BlanchedAlmond),
            ColorMode = KmlColorMode.Random
        };
        KmlLineStyle? compObject = await xml.Deserialize<KmlLineStyle>();
        _ = compObject.Should().BeEquivalentTo(lineStyle);
    }
}
