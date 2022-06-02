// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using static System.FormattableString; 
namespace MMKiwi.KmlSharp.Kml;

public record class KmlCoordinates(double X , double Y, double? Z)
{
    public override string ToString()
        => Invariant($"{X},{Y}{(Z.HasValue ? "," : "")}{Z}");
}

public static class KmlCoordinatesExtensions
{
    public static string ToCoordString(this IEnumerable<KmlCoordinates> coordinates)
        => string.Join("\r\n", coordinates.Select(c=>c.ToString()));
}