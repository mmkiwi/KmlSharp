// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

/// <summary>
/// Enumeration of the different KML Altitude Modes
/// </summary>
/// <remarks>
///   Represents the enumeration kml:AltitudeModeEnum in the <see href="https://www.ogc.org/standards/kml/">Kml
///   specification</see>.
/// </remarks>
public enum KmlAltitudeMode
{
    /// <summary>
    ///   The specified altitude value will be overridden and set to the terrain surface instead. 
    /// </summary>
    ClampToGround,
    /// <summary>
    ///   Interpret the altitude in meters relative to the terrain surface elevation. 
    /// </summary>
    RelativeToGround,
    /// <summary>
    ///   Interpret the altitude as a value in meters relative to the vertical datum. 
    /// </summary>
    Absolute
}
