// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Kml;

using Color = System.Drawing.Color;

namespace MMKiwi.KmlSharp.Tests;
public class KmlListStyleTests
{
    [Fact]
    public async Task SerializeWithRequired()
    {
        KmlListStyle style = new();
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ListStyle", Namespaces.Kml))
        ));
    }

    [Fact]
    public async Task SerializeWithDefault()
    {
        KmlListStyle style = new();
        XDocument xDoc = await style.ToXDocument(new Serialization.KmlWriteOptions
        {
            EmitValuesWhenDefault = true
        });
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ListStyle", Namespaces.Kml),
                new XElement(XName.Get("maxSnippetLines", Namespaces.Kml), 2),
                new XElement(XName.Get("listItemType", Namespaces.Kml), "check"),
                new XElement(XName.Get("bgColor", Namespaces.Kml), "ffffffff"),
                new XElement(XName.Get("color", Namespaces.Kml), "ffffffff"),
                new XElement(XName.Get("colorMode", Namespaces.Kml), "normal"))
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        KmlListStyle style = new()
        {
            Color = Color.FromArgb(128, 16, 255, 72),
            ColorMode = KmlColorMode.Random,
            Id = "TestId",
            TargetId = "#fakeTarget",
            BgColor = Color.FromArgb(75, Color.Azure),
            ListItemType = KmlListItemType.CheckOffOnly,
            MaxSnippetLines = 6,
        };
        style.ItemIcons.Add(new()
        {
            State = new(true, true, false, false, false, false, "test test123"),
            Href = "target1"
        });
        style.ItemIcons.Add(new()
        {
            State = new(false, false, true, true, true, true),
        });
        style.ItemIcons.Add(new());
        XDocument xDoc = await style.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("ListStyle", Namespaces.Kml),
                new XAttribute(XName.Get("id", Namespaces.Kml), "TestId"),
                new XAttribute(XName.Get("targetId", Namespaces.Kml), "#fakeTarget"),
                new XElement(XName.Get("maxSnippetLines", Namespaces.Kml), 6),
                new XElement(XName.Get("listItemType", Namespaces.Kml), "checkOffOnly"),
                new XElement(XName.Get("bgColor", Namespaces.Kml), "4bfffff0"),
                new XElement(XName.Get("ItemIcon", Namespaces.Kml),
                    new XElement(XName.Get("state", Namespaces.Kml), "open closed test test123"),
                    new XElement(XName.Get("href", Namespaces.Kml), "target1")),
                new XElement(XName.Get("ItemIcon", Namespaces.Kml),
                    new XElement(XName.Get("state", Namespaces.Kml), "error fetching0 fetching1 fetching2")),
                new XElement(XName.Get("ItemIcon", Namespaces.Kml)),
                new XElement(XName.Get("color", Namespaces.Kml), "8048ff10"),
                new XElement(XName.Get("colorMode", Namespaces.Kml), "random"))
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <ListStyle xmlns="{Namespaces.Kml}" />
            """;
        _ = xml.Awaiting(x => x.Deserialize<KmlListStyle>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <ListStyle xmlns="{Namespaces.Kml}" />
            """;
        KmlListStyle listStyle = new();
        KmlListStyle? compObject = await xml.Deserialize<KmlListStyle>();
        _ = compObject.Should().BeEquivalentTo(listStyle);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <ListStyle xmlns="{Namespaces.Kml}" id="TestID" targetId="#fakeTarget">
                <color>64CDEBFF</color>
                <colorMode>random</colorMode>
                <bgColor>4Bfffff0</bgColor>
                <listItemType>checkOffOnly</listItemType>
                <maxSnippetLines>6</maxSnippetLines>
                <ItemIcon>
                    <state>test123 open closed test</state>
                    <href>target1</href>
                </ItemIcon>
                <ItemIcon>
                    <state>error fetching0 fetching1 fetching2</state>
                </ItemIcon>
                <ItemIcon />
            </ListStyle>
            """;
        KmlListStyle listStyle = new()
        {
            Id = "TestID",
            TargetId = "#fakeTarget",
            Color = Color.FromArgb(100, Color.BlanchedAlmond),
            ColorMode = KmlColorMode.Random,
            BgColor = Color.FromArgb(75, Color.Azure),
            ListItemType = KmlListItemType.CheckOffOnly,
            MaxSnippetLines = 6,
        };
        listStyle.ItemIcons.Add(new()
        {
            State = new(true, true, false, false, false, false, "test123 test"),
            Href = "target1"
        });
        listStyle.ItemIcons.Add(new()
        {
            State = new(false, false, true, true, true, true),
        });
        listStyle.ItemIcons.Add(new());
        KmlListStyle? compObject = await xml.Deserialize<KmlListStyle>();
        _ = compObject.Should().BeEquivalentTo(listStyle,
            options => options.WithoutStrictOrdering().ComparingByValue<KmlState>());
    }
}
