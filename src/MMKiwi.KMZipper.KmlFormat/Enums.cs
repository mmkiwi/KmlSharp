using System;
using System.Xml.Serialization;

namespace MMKiwi.KMZipper.KmlFormat
{

    public enum AltitudeMode
    {
        [XmlEnum("clampToGround")]
        ClampToGround,
        [XmlEnum("relativeToGround")]
        RelativeToGround,
        [XmlEnum("absolute")]
        Absolute
    }
}
