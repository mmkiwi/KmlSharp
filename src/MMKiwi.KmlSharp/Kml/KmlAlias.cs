// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;
/// <summary>
///   Contains a mapping from SourceHref to TargetHref.  Both should be specified ouside of an update context, that is
///   when not a descendant of kml:Updat
/// </summary>
public class KmlAlias : KmlAbstractObject
{
    /// <summary>
    ///   Specifies the textured 3D object file to be fetched by an earth browser. This reference can be a relative
    ///   reference to an image file within a KMZ file, or it can be an absolute reference to the file
    ///   (for example, a URL).
    /// </summary>
    /// <value>A uri (absolute or relative)</value>
    public string? TargetHref { get; set; }
    /// <summary>
    ///   Specifies the path for the texture file within the textured 3D object. 
    /// </summary>
    /// <value>A uri (absolute or relative)</value>
    public string? SourceHref { get; set; }
}