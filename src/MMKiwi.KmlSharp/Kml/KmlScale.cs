// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;
/// <summary>
/// Scales a model along the x, y, and z axes in the model's coordinate space. Scale should contain at least one child
/// element outside of an update context, that is when not a descendant of a KmlUpdate. It is advised that x, y, and z 
/// all be specified. 
/// </summary>
/// <remarks>
///   Represents the element kml:Scale in the <see href="https://www.ogc.org/standards/kml/">Kml
///   specification</see>.
/// </remarks>
public class KmlScale : KmlAbstractObject
{
    /// <summary>
    /// Scale factor along x axis.
    /// </summary>
    /// <value>The x scale (double, default = 1.0)</value>
    public double X { get; set; } = 1;
    /// <summary>
    /// Scale factor along y axis.
    /// </summary>
    /// <value>The y scale (double, default = 1.0)</value>
    public double Y { get; set; } = 1;
    /// <summary>
    /// Scale factor along z axis.
    /// </summary>
    /// <value>The z scale (double, default = 1.0)</value>
    public double Z { get; set; } = 1;
}
