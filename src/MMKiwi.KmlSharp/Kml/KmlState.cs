// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Text;

namespace MMKiwi.KmlSharp.Kml;

public record struct KmlState(bool Open, bool Closed, bool Error, bool Fetching0, bool Fetching1, bool Fetching2, string OtherStates = "")
{
    public static KmlState Default => new(false, false, false, false, false, false);
    public KmlState(string state) : this(false, false, false, false, false, false)
    {
        var splits = state.Split(" ");
        StringBuilder otherStates = new();
        foreach (var item in splits)
        {
            if (item == "open")
                Open = true;
            else if (item == "closed")
                Closed = true;
            else if (item == "error")
                Error = true;
            else if (item == "fetching0")
                Fetching0 = true;
            else if (item == "fetching1")
                Fetching1 = true;
            else if (item == "fetching2")
                Fetching2 = true;
            else
            {
                otherStates.Append(item);
                otherStates.Append(' ');
            }
        }
        OtherStates = otherStates.ToString().TrimEnd();
    }

    public override string ToString()
    {
        List<string> states = new(6);
        if (Open) states.Add("open");
        if (Closed) states.Add("closed");
        if (Error) states.Add("error");
        if (Fetching0) states.Add("fetching0");
        if (Fetching1) states.Add("fetching1");
        if (Fetching2) states.Add("fetching2");
        if (!string.IsNullOrWhiteSpace(OtherStates)) states.Add(OtherStates);
        return string.Join(" ", states);
    }
}