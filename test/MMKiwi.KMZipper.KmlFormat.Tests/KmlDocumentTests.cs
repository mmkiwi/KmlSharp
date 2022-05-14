using Xunit;
using FluentAssertions;
using System.Xml;
using System.Xml.Serialization;

namespace MMKiwi.KMZipper.KmlFormat.Tests;
public class KmlDocumentTests
{
    [Fact]
    public void DocumentSerialization()
    {
        KmlDocument doc = new()
        {
            Name = "Test",
            ChildFeatures = new()
            {
                new KmlDocument() {Name = "SubDocument"},
                new KmlFolder() {Name="SubFolder"},
                new KmlFolder() {Name="SubSubFolder"},
                new KmlPlacemark()
                {
                    Name = "TestPlacemark",
                    Geometry = new KmlPoint()
                    {
                        Coordinates = new(-78.455, 20.212)
                    }
                }
            }
        };

        XmlSerializer s = new(typeof(KmlDocument));
        StringWriter sw = new();
        s.Serialize(sw, doc, KmlDocument.Namespaces);
        sw.ToString().Should().Be("""
<?xml version="1.0" encoding="utf-16"?><Document xmlns="http://schemas.opengis.net/kml/2.3"><name>Test</name><KmlDocument><name>SubDocument</name></KmlDocument><KmlFolder><name>SubFolder</name></KmlFolder><KmlFolder><name>SubSubFolder</name></KmlFolder><KmlPlacemark><name>TestPlacemark</name><Geometry><coordinates>-78.455,20.212</coordinates></Geometry></KmlPlacemark></Document>
""");
    }
}