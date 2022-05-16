using MMKiwi.KMZipper.KmlFormat.Atom;

namespace MMKiwi.KMZipper.KmlFormat.Tests;
public class AtomLinkTests
{
    [Fact]
    public async Task SerializeWithRequired()
    {
        AtomLink link = new(new("http://google.com"));
        XDocument xDoc = await link.ToXDocument();
        xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("link", Namespaces.Atom),
                new XAttribute(XName.Get("href", Namespaces.Atom), new Uri("http://google.com").ToString())
            )
        ));
    }

    [Fact]
    public async Task SerializeWithAll()
    {
        AtomLink link = new(new("http://google.com"))
        {
            HrefLang = "en-us",
            Length = 4000,
            Rel = "self",
            Title = "Self Reference",
            Type = "unknown"
        };
        XDocument xDoc = await link.ToXDocument();
        xDoc.Should().BeEquivalentTo(new XDocument(
            new XElement(XName.Get("link", Namespaces.Atom),
                new XAttribute(XName.Get("hreflang", Namespaces.Atom), "en-us"),
                new XAttribute(XName.Get("length", Namespaces.Atom), "4000"),
                new XAttribute(XName.Get("rel", Namespaces.Atom), "self"),
                new XAttribute(XName.Get("title", Namespaces.Atom), "Self Reference"),
                new XAttribute(XName.Get("type", Namespaces.Atom), "unknown"),
                new XAttribute(XName.Get("href", Namespaces.Atom), new Uri("http://google.com").ToString())
            )
        ));
    }

    [Fact]
    public void DeserializeInvalidEmpty()
    {
        const string xml = $"""
            <link xmlns="{Namespaces.Atom}" />
            """;
        xml.Awaiting(x => x.Deserialize<AtomLink>()).Should().ThrowAsync<InvalidDataException>();
    }

    [Fact]
    public async Task DeserializeWithRequired()
    {
        const string xml = $"""
            <link xmlns="{Namespaces.Atom}" href="https://example.com" />
            """;
        AtomLink author = new(new Uri("https://example.com"));
        AtomLink? compObject = await xml.Deserialize<AtomLink>();
        compObject.Should().BeEquivalentTo(author);
    }

    [Fact]
    public async Task DeserializeWithAll()
    {
        const string xml = $"""
            <link xmlns="{Namespaces.Atom}"
                  href="https://example.com"
                  hreflang="en-gb"
                  rel="self"
                  length="4000"
                  title="Unit Test"
                  type="unknown">
            </link>
            """;
        AtomLink author = new(new("https://example.com"))
        {
            HrefLang = "en-gb",
            Length = 4000,
            Rel = "self",
            Title = "Unit Test",
            Type = "unknown"
        };
        AtomLink? compObject = await xml.Deserialize<AtomLink>();
        compObject.Should().BeEquivalentTo(author);
    }
}
