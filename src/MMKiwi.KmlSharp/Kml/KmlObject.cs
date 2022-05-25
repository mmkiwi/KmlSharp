// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Xml.Linq;

namespace MMKiwi.KmlSharp.Kml;

public class KmlAbstractObject
{
    public string? Id { get; set; }
    public string? TargetId { get; set; }

    public List<XElement> UnknownElements { get; } = new();
    public Dictionary<XName, string> UnknownAttributes { get; } = new();
}