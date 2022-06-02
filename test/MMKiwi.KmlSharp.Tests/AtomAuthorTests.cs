// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using MMKiwi.KmlSharp.Atom;

namespace MMKiwi.KmlSharp.Tests;
public class AtomAuthorTests
{
    [Fact]
    public async Task SerializeWithOnlyName()
    {
        AtomAuthor author = new("John Doe");
        XDocument xDoc = await author.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("author", Namespaces.Atom),
            new XElement(XName.Get("name", Namespaces.Atom), "John Doe"))));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        AtomAuthor author = new("John Doe")
        {
            Email = "test@gmail.com",
            Uri = new("https://example.com")
        };
        XDocument xDoc = await author.ToXDocument();
        _ = xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("author", Namespaces.Atom),
                new XElement(XName.Get("name", Namespaces.Atom), "John Doe"),
                new XElement(XName.Get("email", Namespaces.Atom), "test@gmail.com"),
                new XElement(XName.Get("uri", Namespaces.Atom), new Uri("https://example.com/").ToString())
            )
        ));
    }

    [Fact]
    public async Task DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <author xmlns="{Namespaces.Atom}" />
            """;
        _ = await xml.Awaiting(x => x.Deserialize<AtomAuthor>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithOnlyName()
    {
        const string xml = $"""
            <author xmlns="{Namespaces.Atom}">
                <name>John Doe</name>
            </author>
            """;
        AtomAuthor author = new("John Doe");
        AtomAuthor? compObbject = await xml.Deserialize<AtomAuthor>();
        _ = compObbject.Should().BeEquivalentTo(author);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <author xmlns="{Namespaces.Atom}">
                <name>John Doe</name>
                <email>johndoe@gmail.com</email>
                <uri>http://google.com</uri>
            </author>
            """;
        AtomAuthor author = new("John Doe")
        {
            Email = "johndoe@gmail.com",
            Uri = new("http://google.com")
        };
        AtomAuthor? compObject = await xml.Deserialize<AtomAuthor>();
        _ = compObject.Should().BeEquivalentTo(author);
    }
}
