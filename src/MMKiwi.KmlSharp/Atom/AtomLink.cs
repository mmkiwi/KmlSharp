// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace MMKiwi.KmlSharp.Atom;

public partial class AtomLink
{
    internal AtomLink() { Href = null!; }
    public AtomLink(Uri href)
    {
        Href = href;
    }

    public Uri Href { get; set; }
    public string? Rel { get; set; }
    public string? Type { get; set; }
    public string? HrefLang { get; set; }
    public string? Title { get; set; }
    public int? Length { get; set; }
}
