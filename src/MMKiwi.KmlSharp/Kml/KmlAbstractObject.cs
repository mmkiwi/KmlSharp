// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Xml.Linq;

using MMKiwi.KmlSharp.Serialization;

namespace MMKiwi.KmlSharp.Kml;

/// <summary>
///   The KmlAbstractObjectGroup is the parent abstract object that all other KML objects inhert from. It 
///   defines the <see cref="Id" /> and <see cref="TargetId" /> properties and handles <see cref="UnknownElements" />
///   and <see cref="UnknownAttributes" />.
/// </summary>
/// <remarks>
///   Represents the element kml:AbstractObjectGroup in the <see href="https://www.ogc.org/standards/kml/">Kml
///   specification</see>.
/// </remarks>
public class KmlAbstractObject
{
    /// <summary>
    ///   The id attribute may be used to specify a unique identifier for the KmlAbstractObject within the KML document
    ///   instance.
    /// </summary>
    /// <remarks>
    ///   If an element affiliated with kml:AbstractObjectGroup is not being updated (that is, it is not a descendant of
    ///   <see cref="KmlUpdate" />) and it is empty then it shall have an id attribute; otherwise it cannot be updated.
    ///   An object that is not empty should have an identifier to permit future updates.
    /// </remarks>
    public string? Id { get; set; }
    /// <summary>
    ///   The optional targetId attribute may be used to encode the id value of another KmlAbstractObject.
    /// </summary>
    /// <remarks>
    ///   If a KmlAbstractObject is being used for update purposes (is a grandchild of <see cref="KmlUpdate" />) then it
    ///   shall have a targetId attribute referencing the KmlAbstractObject element to be updated. Otherwise, outside of
    ///   an update context targetId has no meaning.
    /// </remarks>
    public string? TargetId { get; set; }

    /// <summary>
    ///   This collection contains any XML elements that are a child of the specified KmlAbstractObject that are not 
    ///   directly handled by <see cref="KmlSerializer" />.
    /// </summary>
    /// <remarks>
    ///   This collection functions similarly to all <em>...ExtensionGroup</em> placeholder elemenents in the 
    ///   <see href="https://www.ogc.org/standards/kml/">Kml specification</see>.
    /// </remarks>
    public List<XElement> UnknownElements { get; } = new();

    /// <summary>
    ///   This collection contains any XML attribes on the specified KmlAbstractObject that are not directly handled by
    ///   <see cref="KmlSerializer" />.
    /// </summary>
    /// <remarks>
    ///   This collection functions similarly to all <em>...anyAttribute</em> placeholder attributes in the 
    ///   <see href="https://www.ogc.org/standards/kml/">Kml specification</see>.
    /// </remarks>

    public Dictionary<XName, string> UnknownAttributes { get; } = new();
}