// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

/// <summary>
///   The KmlAbstractFeature is the parent abstract object that all KML features inhert from.
/// </summary>
/// <remarks>
///   Represents the element kml:AbstractFeatureGroup in the <see href="https://www.ogc.org/standards/kml/">Kml
///   specification</see>.
/// </remarks>

public abstract class KmlAbstractFeature : KmlAbstractObject
{
    /// <summary>
    /// Specifies a label for the feature. In Google Earth, this is the label for the specified feature.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///   Specifies whether the feature shall be drawn in the geographic view when it is initially loaded or not.
    ///   In order for a feature to be visible, the Visibility of all its ancestors must also be true.
    /// </summary>
    /// <remarks>
    /// In the Google Earth List View, each Feature has a checkbox that allows the user to control visibility of the
    /// Feature.
    /// </remarks>
    public bool Visibility { get; set; } = true;

    /// <summary>
    /// Specifies whether the description balloon is opened when loaded or updated.
    /// </summary>
    public bool BalloonVisibility { get; set; } = true;

    /// <summary>
    ///   Specifies whether a <see cref="KmlAbstractContainer" /> appears expanded (true) or collapsed (false) when
    ///   first loaded into the list view.
    /// </summary>
    public bool Open { get; set; } = false;

    /// <summary>
    ///   Specifies the author of the feature. See also <seealso cref="KmlAbstractContainer"/> regarding the inheritance
    ///   of <see cref="Atom.AtomAuthor" /> within KML feature hierarchies.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   This information is displayed in geo search results, both in Earth browsers such as Google Earth, and in other
    ///   applications such as Google Maps. The ascription elements used in KML are as follows:
    ///   </para>
    ///   <list type="bullet">
    ///   <listheader>
    ///     <term>Element</term>
    ///     <description>Description</description>
    ///   </listheader>
    ///   <item>
    ///    <term><see cref="Atom.AtomAuthor"/></term>
    ///    <description>parent element for <see cref="Atom.AtomAuthor.Name" /></description>
    ///   </item>
    ///   <item>
    ///    <term><see cref="Atom.AtomAuthor.Name"/></term>
    ///    <description>the name of the author</description>
    ///   </item>
    ///   <item>
    ///    <term><see cref="Atom.AtomAuthor.Uri"/></term>
    ///    <description>URL of the web page containing the KML/KMZ file</description>
    ///   </item>
    ///   </list>
    ///   <para>
    ///   These elements are defined in the Atom Syndication Format. The complete specification is found at
    ///   <see href="http://atompub.org"/>.
    ///   </para>
    /// </remarks>
    public Atom.AtomAuthor? Author { get; set; }

    /// <summary>
    ///   Specifies the URL of the source resource that contains the feature. The URL is encoded as the value of the 
    ///   <see cref="Atom.AtomLink.Href" /> parameter. The <see cref="Atom.AtomLink.Rel" /> property must be present and
    ///   its value should be related. See also <seealso cref="KmlAbstractContainer"/> regarding the inheritance of
    ///   <see cref="Atom.AtomLink" /> within KML feature hierarchies.
    /// </summary>
    /// <value></value>
    public Atom.AtomLink? Link { get; set; }

    /// <summary>
    ///   A string value representing an unstructured address for the feature, such as street, city, state address,
    ///   and/or a postal code. This may be used to geocode the location of a feature if it does not contain a
    ///   <see cref="KmlAbstractGeometry" />.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    ///   A structured address for the feature formatted according to
    ///   <see href="https://www.oasis-open.org/committees/ciq/ciq.html#6">xAL 2.0</see>. This may be used to geocode
    ///   the location of a feature if it does not contain a <see cref="KmlAbstractGeometry" />.
    /// </summary>
    /// <remarks>
    ///    is used by KML for geocoding in Google Maps only. For details, see the Google Maps API documentation.
    ///    Currently, Google Earth does not use this element; use <see cref="Address" /> instead.
    /// </remarks>
    public Xal.XalAddressDetails? AddressDetails { get; set; }

    /// <summary>
    ///  A value representing a telephone number. The number should be formatted according to
    ///  <see href="https://www.ietf.org/rfc/rfc2806.txt">IETF RFC 3966</see>.
    /// </summary>
    /// <remarks></remarks>
    public string? PhoneNumber { get; set; }

    /// <summary>
    ///   Specifies a short description of the feature. The value of Snippet, if present, is used in the list view
    ///   instead of <see cref="Description" />.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   The element kml:snippet replaces the deprecated element kml:Snippet, however kml:Snippet may likely be
    ///   supported by KML software implementations for an indeterminate period of time. If both Kml:Snippet and
    ///   kml:snippet are present when deserializing, only kml:snippet will be kept.
    ///   </para>
    ///   <para>
    ///   The text may include HTML content. When serializing, it is automatically enclosed in a CDATA section.
    ///   </para>
    ///   <para>
    ///   A short description of the feature. In Google Earth, this description is displayed in the Places panel under
    ///   the name of the feature. If a Snippet is not supplied, the first two lines of the <see cref="Description" />
    ///   are used. In Google Earth, if a Placemark contains both a description and a Snippet, the Snippet appears 
    ///   beneath the Placemark in the Places panel, and the <see cref="Description" /> appears in the Placemark's
    ///   description balloon. This tag does not support HTML markup in Google Earth. The Google Earth MaxLines
    ///   attribute is not supported.</para>
    /// </remarks>
    public string? Snippet { get; set; }

    
    /// <summary>
    ///   Specifies a description of the feature. This should be displayed in the description balloon.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   The text may include HTML content. When serializing, it is automatically enclosed in a CDATA section.
    ///   </para>
    ///   <para>
    ///   If the description includes the HTML <c>&lt;a href=&quot;...&quot; type=&quot;...&quot;&gt;</c> tag, it should have
    ///   an HTML href and type attribute and be interpreted as follows:
    ///   </para>
    ///   <list>
    ///   <item><description>The href attribute specifies a URL.</description></item>
    ///   <item><description>If the target of the href is a KML resource, an earth browser should load the resource if
    ///     the link is activated.</description></item>
    ///   </list>
    ///   <para>
    ///   The href may reference another feature if its value is the fragment component of a URL. If such a link is
    ///   activated, the geographic view should fly to the feature whose ID matches the fragment. If this feature has a
    ///   <see cref="KmlLookAt" /> or <see cref="KmlCamera" /> element, it shall be viewed from the specified viewpoint.
    ///   </para>
    ///   <para>
    ///   For example, the following code indicates to open the resource CraftsFairs.kml resource, fly to the 
    ///   <see cref="KmlPlacemark" /> whose ID is "Albuquerque," and open its balloon: 
    ///   </para>
    ///   <code lang="xml">
    /// &lt;a href=&quot;http://myServer.com/CraftsFairs.kml#Albuquerque;balloonFlyto&quot;&gt;
    ///   One of the Best Art Shows in the West
    /// &lt;/a&gt;
    ///   </code>
    ///   <para>
    ///   The type attribute specifies the MIME type for the target resource. An earth browser should interpret the
    ///   target resource according to this specified MIME type when attempting to load it. To indicate that the target
    ///   resource is KML specify the following MIME type: application/vnd.google-earth.kml+xml To indicate that the
    ///   target resource is a KMZ archive specify the following MIME type: application/vnd.google-earth.kmz. For
    ///   example, the type attribute below indicates that an earth browser should attempt to load the target as a KML
    ///   resource even though the file extension is .php:
    /// </para>
    /// <code lang="xml">
    /// &lt;a href=&quot;myserver.com/cgi-bin/generate-kml.php#placemark123&quot;
    ///    type=&quot;application/vnd.google-earth.kml+xml&quot;&gt;...
    /// </code>
    ///   <para>
    ///   Different versions of Google Earth support HTML descriptions differently. Google Earth 5.0 and later support
    ///   more full-featured HTML using a webkit browser. Google Earth 4.3 has much more limited HTML support.
    ///  <seealso href="https://developers.google.com/kml/documentation/kmlreference#elements-specific-to-feature"> See
    ///   the Google KML documentation</seealso> for details.
    /// </para>
    /// </remarks>
    public string? Description { get; set; }

    public KmlAbstractView? Viewpoint { get; set; }

    public KmlAbstractTime? TimePrimitive { get; set; }

    public string? StyleUrl { get; set; }

    public List<KmlAbstractStyleSelector>? StyleSelector { get; set; }

    public KmlRegion? Region { get; set; }
}
