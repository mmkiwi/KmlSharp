global using System.Xml.Serialization;
global using System.Xml;
using MMKiwi.KMZipper.KmlFormat.Atom;

XmlSerializer atomAuthor = new XmlSerializer(typeof(AtomAuthor));
XmlSerializer atomLink = new XmlSerializer(typeof(AtomLink));
public static class Namespaces
{
    public const string Atom = "http://www.w3.org/2005/Atom";
    public const string Kml = "http://www.opengis.net/kml/2.2";
}