// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlItemIconTests
{
    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlItemIcon style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ItemIcon", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlItemIcon style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ItemIcon", Namespaces.Kml),
                new XElement(XName.Get("state", Namespaces.Kml), ""),
                new XElement(XName.Get("href", Namespaces.Kml), ""))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlItemIcon style = new()
        {
            Id = "TestId",
            TargetId = "#fakeTarget",
            Href = "#superFakeTarget",
            State = new(false, true, true, false, true, false, "test")
        };
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ItemIcon", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("state", Namespaces.Kml), "closed error fetching1 test"),
                new XElement(XName.Get("href", Namespaces.Kml), "#superFakeTarget"))
        ));
    }

    [Fact]
    public async Task DeserializeEmpty()
    {
        const string xml = $"""
            <ItemIcon xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlItemIcon>()).Should().NotThrowAsync();
        var c = await xml.Deserialize<KmlItemIcon>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <ItemIcon xmlns="{Namespaces.Kml}" />
            """;
        KmlItemIcon ItemIcon = new();
        KmlItemIcon? compObject = await xml.Deserialize<KmlItemIcon>();
        _ = compObject.Should().BeEquivalentTo(ItemIcon);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <ItemIcon xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <state>open test6 fetching0 test7 fetching2</state>
                <href>#superFakeTarget</href>
            </ItemIcon>
            """;
        KmlItemIcon ItemIcon = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            Href = "#superFakeTarget",
            State = new(true, false, false, true, false, true, "test6 test7")
        };
        KmlItemIcon? compObject = await xml.Deserialize<KmlItemIcon>();
        _ = compObject.Should().BeEquivalentTo(ItemIcon);
    }
}
