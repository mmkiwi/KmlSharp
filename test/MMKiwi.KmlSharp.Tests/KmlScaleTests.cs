// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlScaleTests
{
    [Fact]
    public async Task SerializeWithUnknown()
    {
        KmlScale style = new();
        style.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        style.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Scale", Namespaces.Kml),
                new XAttribute(XName.Get("style", Namespaces.Html), "display:none;"),
                new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph")
            )
        ));
    }

    [Fact]
    public async Task DeerializeWithUnknown()
    {
        const string xml = $"""
            <Scale xmlns="{Namespaces.Kml}" xmlns:html="{Namespaces.Html}" html:style="display:none;" >
                <html:p>This is an HTML paragraph</html:p>
            </Scale>
            """;

        KmlScale labelStyle = new();
        labelStyle.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        labelStyle.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        KmlScale? compObject = await xml.Deserialize<KmlScale>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }


    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlScale style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Scale", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlScale style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Scale", Namespaces.Kml),
                new XElement(XName.Get("x", Namespaces.Kml), 1),
                new XElement(XName.Get("y", Namespaces.Kml), 1),
                new XElement(XName.Get("z", Namespaces.Kml), 1))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlScale style = new()
        {
            Id = "TestId",
            TargetId = "#fakeTarget",
            X = 55,
            Y = 72.224,
            Z = 102.33
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Scale", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("x", Namespaces.Kml), "55"),
                new XElement(XName.Get("y", Namespaces.Kml), "72.224"),
                new XElement(XName.Get("z", Namespaces.Kml), "102.33"))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <Scale xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlScale>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <Scale xmlns="{Namespaces.Kml}" />
            """;
        KmlScale labelStyle = new();
        KmlScale? compObject = await xml.Deserialize<KmlScale>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <Scale xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <x>55.0</x>
                <z>69.42</z>
                <y>72.11</y>
            </Scale>
            """;
        KmlScale labelStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            X = 55,
            Y = 72.11,
            Z = 69.42
        };
        KmlScale? compObject = await xml.Deserialize<KmlScale>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }
}
