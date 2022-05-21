// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public abstract class KmlAbstractFeature : KmlAbstractObject
{
    public string? Name { get; set; }
    public bool Visibility { get; set; } = true;

    public bool BalloonVisibility { get; set; } = true;

    public bool Open { get; set; } = false;

    public Atom.AtomAuthor? Author { get; set; }

    public Atom.AtomLink? Link { get; set; }

    public string? Address { get; set; }

    public Xal.XalAddressDetails? AddressDetails { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Snippet { get; set; }

    public string? Description { get; set; }

    public KmlAbstractView? Viewpoint { get; set; }

    public KmlAbstractTime? TimePrimitive { get; set; }

    public string? StyleUrl { get; set; }

    public List<KmlAbstractStyleSelector>? StyleSelector { get; set; }

    public KmlRegion? Region { get; set; }
}
