// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Atom;

public partial class AtomAuthor
{
    internal AtomAuthor() { Name = null!; }
    public AtomAuthor(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public string? Email { get; set; }
    public Uri? Uri { get; set; }
}
