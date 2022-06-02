// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.
using Color = System.Drawing.Color;
using Humanizer;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MMKiwi.KmlSharp.Serialization;

public enum EnumConvertMode
{
    CamelCase, PascalCase, LowerCase, UpperCase
}

public enum BoolConvertMode
{
    Text,
    Numeric
}