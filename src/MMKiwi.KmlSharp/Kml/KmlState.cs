// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Kml;

public record struct KmlState(bool Open, bool Closed, bool Error, bool Fetching0, bool Fetching1, bool Fetching2) { }