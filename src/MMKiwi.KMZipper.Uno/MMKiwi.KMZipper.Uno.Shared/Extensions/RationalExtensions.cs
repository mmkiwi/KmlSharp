// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using SixLabors.ImageSharp;

namespace MMKiwi.KMZipper.Uno.Extensions;

public static class RationalExtensions
{
    public static double ToDouble(this Rational[] portions)
    {
        double result = 0;
        for (int i = 0; i < portions.Length; i++)
        {
            result += portions[i].ToDouble() / Math.Pow(60, i);
        }

        return result;
    }
}