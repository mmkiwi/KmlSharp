﻿// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

/* Unmerged change from project 'MMKiwi.KMZipper.KmlFormat (netstandard2.1)'
Before:
using System;
After:
// System;
*/
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KMZipper.KmlFormat.Kml;
public sealed class KmlRoot
{
    public string? Hint { get; set; }

    public string? Version { get; set; } = "2.3";

    public KmlAbstractFeature? RootFeature { get; set; }

    public KmlNetworkLinkControl? NetworkLinkControl { get; set; }
}
