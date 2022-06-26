// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlIconTests
{
    [Fact]
    public async Task SerializeWithUnknown()
    {
        KmlIcon style = new();
        style.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        style.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Icon", Namespaces.Kml),
                new XAttribute(XName.Get("style", Namespaces.Html), "display:none;"),
                new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph")
            )
        ));
    }

    [Fact]
    public async Task DeserializeWithUnknown()
    {
        const string xml = $"""
            <Icon xmlns="{Namespaces.Kml}" xmlns:html="{Namespaces.Html}" html:style="display:none;" >
                <html:p>This is an HTML paragraph</html:p>
            </Icon>
            """;

        KmlIcon labelStyle = new();
        labelStyle.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        labelStyle.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        KmlIcon? compObject = await xml.Deserialize<KmlIcon>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlIcon style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Icon", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlIcon style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Icon", Namespaces.Kml),
                new XElement(XName.Get("href", Namespaces.Kml)))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlIcon style = new()
        {
            Id = "TestId",
            TargetId = "#fakeTarget",
            Href = "https://www.example.com"
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("Icon", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("href", Namespaces.Kml), "https://www.example.com"))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <Icon xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlIcon>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <Icon xmlns="{Namespaces.Kml}" />
            """;
        KmlIcon labelStyle = new();
        KmlIcon? compObject = await xml.Deserialize<KmlIcon>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <Icon xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <href>#testAnchro</href>
            </Icon>
            """;
        KmlIcon labelStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            Href = "#testAnchro"
        };
        KmlIcon? compObject = await xml.Deserialize<KmlIcon>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }
}
