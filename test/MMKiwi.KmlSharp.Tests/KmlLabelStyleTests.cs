// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlLabelStyleTests
{
    [Fact]
    public async Task SerializeWithUnknown()
    {
        KmlLabelStyle style = new();
        style.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        style.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("LabelStyle", Namespaces.Kml),
                new XAttribute(XName.Get("style", Namespaces.Html), "display:none;"),
                new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph")
            )
        ));
    }

    [Fact]
    public async Task DeerializeWithUnknown()
    {
        const string xml = $"""
            <LabelStyle xmlns="{Namespaces.Kml}" xmlns:html="{Namespaces.Html}" html:style="display:none;" >
                <html:p>This is an HTML paragraph</html:p>
            </LabelStyle>
            """;
        
        KmlLabelStyle labelStyle = new();
        labelStyle.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        labelStyle.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        KmlLabelStyle? compObject = await xml.Deserialize<KmlLabelStyle>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }


    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlLabelStyle style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("LabelStyle", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlLabelStyle style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("LabelStyle", Namespaces.Kml),
                new XElement(XName.Get("scale", Namespaces.Kml), 1),
                new XElement(XName.Get("color", Namespaces.Kml), "ffffffff"),
                new XElement(XName.Get("colorMode", Namespaces.Kml), "normal"))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlLabelStyle style = new()
        {
            Color = Color.FromArgb(128, 16, 255, 72),
            ColorMode = KmlColorMode.Random,
            Id = "TestId",
            TargetId = "#fakeTarget",
            Scale = 700
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("LabelStyle", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("scale", Namespaces.Kml), 700),
                new XElement(XName.Get("color", Namespaces.Kml), "8048ff10"),
                new XElement(XName.Get("colorMode", Namespaces.Kml), "random"))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <LabelStyle xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlLabelStyle>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <LabelStyle xmlns="{Namespaces.Kml}" />
            """;
        KmlLabelStyle labelStyle = new();
        KmlLabelStyle? compObject = await xml.Deserialize<KmlLabelStyle>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <LabelStyle xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <scale>100.75</scale>
                <color>64CDEBFF</color>
                <colorMode>random</colorMode>
            </LabelStyle>
            """;
        KmlLabelStyle labelStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            Scale = 100.75,
            Color = Color.FromArgb(100, Color.BlanchedAlmond),
            ColorMode = KmlColorMode.Random
        };
        KmlLabelStyle? compObject = await xml.Deserialize<KmlLabelStyle>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }
}
