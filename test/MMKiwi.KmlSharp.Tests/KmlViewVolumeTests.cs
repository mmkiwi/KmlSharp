// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlViewVolumeTests
{
    [Fact]
    public async Task SerializeWithUnknown()
    {
        KmlViewVolume style = new();
        style.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        style.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ViewVolume", Namespaces.Kml),
                new XAttribute(XName.Get("style", Namespaces.Html), "display:none;"),
                new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph")
            )
        ));
    }

    [Fact]
    public async Task DeserializeWithUnknown()
    {
        const string xml = $"""
            <ViewVolume xmlns="{Namespaces.Kml}" xmlns:html="{Namespaces.Html}" html:style="display:none;" >
                <html:p>This is an HTML paragraph</html:p>
            </ViewVolume>
            """;

        KmlViewVolume labelStyle = new();
        labelStyle.UnknownAttributes.Add(XName.Get("style", Namespaces.Html), "display:none;");
        labelStyle.UnknownElements.Add(new XElement(XName.Get("p", Namespaces.Html), "This is an HTML paragraph"));
        KmlViewVolume? compObject = await xml.Deserialize<KmlViewVolume>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlViewVolume style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ViewVolume", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlViewVolume style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ViewVolume", Namespaces.Kml),
                new XElement(XName.Get("leftFov", Namespaces.Kml), 0),
                new XElement(XName.Get("rightFov", Namespaces.Kml), 0),
                new XElement(XName.Get("topFov", Namespaces.Kml), 0),
                new XElement(XName.Get("bottomFov", Namespaces.Kml), 0),
                new XElement(XName.Get("near", Namespaces.Kml), 0))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlViewVolume style = new()
        {
            Id = "TestId",
            TargetId = "#fakeTarget",
            LeftFieldOfView = 19.2,
            RightFieldOfView = 29.9,
            TopFieldOfView = 72.73,
            BottomFieldOfView = 1.0,
            Near = 35.332
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ViewVolume", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("leftFov", Namespaces.Kml), 19.2),
                new XElement(XName.Get("rightFov", Namespaces.Kml), 29.9),
                new XElement(XName.Get("topFov", Namespaces.Kml), 72.73),
                new XElement(XName.Get("bottomFov", Namespaces.Kml), 1),
                new XElement(XName.Get("near", Namespaces.Kml), 35.332))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <ViewVolume xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlViewVolume>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <ViewVolume xmlns="{Namespaces.Kml}" />
            """;
        KmlViewVolume labelStyle = new();
        KmlViewVolume? compObject = await xml.Deserialize<KmlViewVolume>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <ViewVolume xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <leftFov>55.00</leftFov>
                <topFov>110</topFov>
                <rightFov>72.11</rightFov>
                <bottomFov>69.42</bottomFov>
                <near>60</near>
            </ViewVolume>
            """;
        KmlViewVolume labelStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            LeftFieldOfView = 55,
            RightFieldOfView = 72.11,
            BottomFieldOfView = 69.42,
            TopFieldOfView = 110,
            Near = 60
        };
        KmlViewVolume? compObject = await xml.Deserialize<KmlViewVolume>();
        _ = compObject.Should().BeEquivalentTo(labelStyle);
    }
}
