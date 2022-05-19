// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public class KmlPolygon : KmlAbstractGeometry
{
    public bool Extrude { get; set; } = false;
    public bool Tessellate { get; set; } = false;
    public KmlAltitudeMode AltitudeMode { get; set; }
    public KmlSeaFloorAltitudeMode SeaFloorAltitudeMode { get; set; }
    public KmlLinearRing? OuterBoundary { get; set; }
    public List<KmlLinearRing> InnerBoundaries { get; } = new();
}

public class KmlModel : KmlAbstractGeometry
{
    public KmlAltitudeMode AltitudeMode { get; set; }
    public KmlSeaFloorAltitudeMode SeaFloorAltitudeMode { get; set; }
    public KmlLocation? Location { get; set; }
    public KmlOrientation? Orientation { get; set; }
    public KmlScale? Scale { get; set; }
    public KmlLink? Link { get; set; }

    public KmlResourceMap? ResourceMap { get; set; }
}

public class KmlLocation : KmlAbstractObject
{
    public double Longitude { get; set; } = 0;
    public double Latitude { get; set; } = 0;
    public double Altitude { get; set; } = 0;
}

public class KmlOrientation : KmlAbstractObject
{
    public double Heading { get; set; } = 0;
    public double Tilt { get; set; } = 0;
    public double Roll { get; set; } = 0;
}

public class KmlScale : KmlAbstractObject
{
    public double X { get; set; } = 1;
    public double Y { get; set; } = 1;
    public double Z { get; set; } = 1;
}

public class KmlResourceMap : KmlAbstractObject
{
    public List<KmlAlias> Aliases { get; } = new();
}
public class KmlAlias : KmlAbstractObject
{
    public string? TargetHref {get;set;}
    public string? SourceHref {get;set;}
}