// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KMZipper.KmlFormat.Kml;
public class KmlTour: KmlAbstractObject
{
    public string? Name { get; set; }
    public bool Visibility { get; set; }
    public bool BaloonVisibility { get; set; }
}
