// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlOrientationTests
{
    [Fact]
    public async Task SerializeWithUnknown()
    {
        KmlOrientation style = new();
        style.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        style.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Orientation", Namespaces.Kml),
                new XAttribute(XName.Get("style", Namespaces.Html), "display:none;"),
                new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph")
            )
        ));
    }

    [Fact]
    public async Task DeserializeWithUnknown()
    {
        const string xml = $"""
            <Orientation xmlns="{Namespaces.Kml}" xmlns:html="{Namespaces.Html}" html:style="display:none;" >
                <html:p>This is an HTML paragraph</html:p>
            </Orientation>
            """;

        KmlOrientation labelStyle = new();
        labelStyle.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        labelStyle.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        KmlOrientation? compObject = await xml.Deserialize<KmlOrientation>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlOrientation style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Orientation", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlOrientation style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Orientation", Namespaces.Kml),
                new XElement(XName.Get("heading", Namespaces.Kml), 0),
                new XElement(XName.Get("tilt", Namespaces.Kml), 0),
                new XElement(XName.Get("roll", Namespaces.Kml), 0))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlOrientation style = new()
        {
            Id = "TestId",
            TargetId = "#fakeTarget",
            Heading = 55,
            Tilt = 72.224,
            Roll = 102.33
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Orientation", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("heading", Namespaces.Kml), "55"),
                new XElement(XName.Get("tilt", Namespaces.Kml), "72.224"),
                new XElement(XName.Get("roll", Namespaces.Kml), "102.33"))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <Orientation xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlOrientation>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <Orientation xmlns="{Namespaces.Kml}" />
            """;
        KmlOrientation labelStyle = new();
        KmlOrientation? compObject = await xml.Deserialize<KmlOrientation>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <Orientation xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <heading>55.0</heading>
                <tilt>69.42</tilt>
                <roll>72.11</roll>
            </Orientation>
            """;
        KmlOrientation labelStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            Heading = 55,
            Tilt = 69.42,
            Roll = 72.11
        };
        KmlOrientation? compObject = await xml.Deserialize<KmlOrientation>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }
}
