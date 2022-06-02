// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.
using Color = System.Drawing.Color;
using Humanizer;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MMKiwi.KmlSharp.Serialization;

internal static partial class HelpExtensions
{
    public static bool CheckElementName(XmlReader reader, string name, string ns, HashSet<string> alreadySet)
    {
        return !alreadySet.Contains(name) && reader.LocalName == name && reader.NamespaceURI == ns;
    }

    public static bool CheckAttributeName(XmlReader reader, string name, string ns, HashSet<string> alreadySet)
    {
        return !alreadySet.Contains(name) && reader.LocalName == name && (reader.NamespaceURI == ns || string.IsNullOrEmpty(reader.NamespaceURI));
    }

    public static async Task<string> ReadElementStringAsync(XmlReader reader, HashSet<string> alreadySet)
    {
        _ = alreadySet.Add(reader.Name);
        return await reader.ReadElementContentAsStringAsync().ConfigureAwait(false);
    }

    public static async Task<double> ReadElementDoubleAsync(XmlReader reader, HashSet<string> alreadySet)
    {
        _ = alreadySet.Add(reader.Name);
        string res = await reader.ReadElementContentAsStringAsync().ConfigureAwait(false);
        return res switch
        {
            "INF" => double.PositiveInfinity,
            "-INF" => double.NegativeInfinity,
            "NaN" => double.NaN,
            _ => XmlConvert.ToDouble(res)
        };
    }

    public static async Task WriteElementDoubleAsync(this XmlWriter writer, string? prefix, string localName, string? ns, double value)
        //Using XmlConvert since it handles edge cases like NaN and Infinity
        => await writer.WriteElementStringAsync(prefix, localName, ns, XmlConvert.ToString(value)).ConfigureAwait(false);
    public static async Task WriteAttributeDoubleAsync(this XmlWriter writer, string? prefix, string localName, string? ns, double value)
        //Using XmlConvert since it handles edge cases like NaN and Infinity
        => await writer.WriteAttributeStringAsync(prefix, localName, ns, XmlConvert.ToString(value)).ConfigureAwait(false);

    public static async Task WriteElementIntAsync(this XmlWriter writer, string? prefix, string localName, string? ns, int value)
        => await writer.WriteElementStringAsync(prefix, localName, ns, XmlConvert.ToString(value)).ConfigureAwait(false);

    public static async Task WriteAttributeIntAsync(this XmlWriter writer, string? prefix, string localName, string? ns, int value)
        => await writer.WriteAttributeStringAsync(prefix, localName, ns, XmlConvert.ToString(value)).ConfigureAwait(false);

    public static async Task<int> ReadElementIntAsync(XmlReader reader, HashSet<string> alreadySet)
    {
        _ = alreadySet.Add(reader.Name);
        string res = await reader.ReadElementContentAsStringAsync().ConfigureAwait(false);
        return XmlConvert.ToInt32(res);
    }

    public static async Task<bool> ReadElementBoolAsync(XmlReader reader, HashSet<string> alreadySet)
    {
        _ = alreadySet.Add(reader.Name);
        string res = await reader.ReadElementContentAsStringAsync().ConfigureAwait(false);
        return XmlConvert.ToBoolean(res);
    }

    const string _hexColorRegex = @"^\s*(?<alpha>[a-zA-Z0-9]{2})?\s*(?<blue>[a-zA-Z0-9]{2})\s*(?<green>[a-zA-Z0-9]{2})\s*(?<red>[a-zA-Z0-9]{2})$";

#if NET7_0_OR_GREATER
    [RegexGenerator(_hexColorRegex)]
    private static partial Regex HexColorRegex();
#else 
    private static Regex HexColorRegex() => new(_hexColorRegex, RegexOptions.CultureInvariant);
#endif

    public static async Task<Color> ReadElementColorAsync(XmlReader reader, HashSet<string> alreadySet)
    {
        _ = alreadySet.Add(reader.Name);

        string colorStr = await reader.ReadElementContentAsStringAsync().ConfigureAwait(false);
        Match? matches = HexColorRegex().Match(colorStr);
        return matches is null
            ? throw new FormatException($"Could not parse color {colorStr}")
            : Color.FromArgb(alpha: matches.Groups["alpha"].ParseByteStr(colorStr),
                                blue: matches.Groups["blue"].ParseByteStr(colorStr),
                                green: matches.Groups["green"].ParseByteStr(colorStr),
                                red: matches.Groups["red"].ParseByteStr(colorStr));
    }

#if NET7_0_OR_GREATER
    public static byte ParseByteStr(this Group inValue, string fullStr)
        => inValue.Success
            ? byte.TryParse(inValue.ValueSpan, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte result)
                        ? result
                        : throw new FormatException($"Could not parse color {fullStr}")
            : (byte)255;
#else
    public static byte ParseByteStr(this Group inValue, string fullStr)
        => inValue.Success
            ? byte.TryParse(inValue.Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte result)
                        ? result
                        : throw new FormatException($"Could not parse color {fullStr}")
            : (byte)255;
#endif

    public static string ToKmlString(this Color color)
            => $"{color.A:x}{color.B:x}{color.G:x}{color.R:x}";

    public static string ToKmlString<T>(this T enumVal, EnumConvertMode mode = EnumConvertMode.CamelCase)
        where T : struct, Enum
        => mode switch
        {
            EnumConvertMode.CamelCase => enumVal.ToString().Camelize(),
            EnumConvertMode.PascalCase => enumVal.ToString().Pascalize(),
            EnumConvertMode.LowerCase => enumVal.ToString().ToLowerInvariant(),
            EnumConvertMode.UpperCase => enumVal.ToString().ToUpperInvariant(),
            _ => throw new NotImplementedException(),
        };

    public static string ToKmlString(this bool boolVal, BoolConvertMode mode = BoolConvertMode.Text)
        => (boolVal, mode) switch
        {
            (true, BoolConvertMode.Text) => "true",
            (false, BoolConvertMode.Text) => "false",
            (true, BoolConvertMode.Numeric) => "1",
            (false, BoolConvertMode.Numeric) => "0",
            _ => throw new NotImplementedException(),
        };

    public static async Task<T> ReadElementEnumAsync<T>(XmlReader reader, HashSet<string> alreadySet)
        where T : struct, Enum
    {
        _ = alreadySet.Add(reader.Name);
        string res = await reader.ReadElementContentAsStringAsync().ConfigureAwait(false);
        return Enum.Parse<T>(res.Pascalize());
    }

    public static async Task<string> ReadAttributeString(XmlReader reader, HashSet<string> alreadySet)
    {
        _ = alreadySet.Add(reader.Name);
        return await reader.GetValueAsync().ConfigureAwait(false);
    }

    public static async Task WriteEmptyElementAsync(XmlWriter writer, string prefix, string localname, string ns)
    {
        await writer.WriteStartElementAsync(prefix, localname, ns).ConfigureAwait(false);
        await writer.WriteEndElementAsync().ConfigureAwait(false);
    }

    internal static DateTime? ToDateTime(string d)
    {
        return XmlConvert.ToDateTime(d, XmlDateTimeSerializationMode.Utc);
    }
}
