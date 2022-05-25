// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.
using Color = System.Drawing.Color;
using Humanizer;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MMKiwi.KmlSharp.Serialization;

internal abstract class SerializationHelper<T> : ISerializationHelper<T> where T : class
{
    protected virtual bool PrefixAttributes => false;
    protected abstract string Tag { get; }
    protected abstract string Namespace { get; }
    public virtual async Task<T?> ReadRootTagAsync(XmlReader reader, CancellationToken ct = default)
    {
        T? o = null;
        if (reader.MoveToContent() == System.Xml.XmlNodeType.Element)
        {
            o = reader.LocalName == Tag && reader.NamespaceURI == Namespace
                ? await ReadTagAsync(reader, ct).ConfigureAwait(false)
                : throw new ArgumentException($"Tag {reader.LocalName} was not expected");
        }
        return o;
    }
    public abstract Task<T> ReadTagAsync(XmlReader reader, CancellationToken ct = default);
    public virtual async Task WriteRootTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default)
    {
        string? prefix = ns?.LookupPrefix(Namespace) ?? "";
        writer.WriteStartDocument();
        if (o == null)
            await Helpers.WriteEmptyElementAsync(writer, prefix, Tag, Namespace).ConfigureAwait(false);
        else
            await WriteTagAsync(writer, o, ns, options, ct).ConfigureAwait(false);
    }
    public abstract Task WriteTagAsync(XmlWriter writer, T o, XmlNamespaceManager? ns = null, KmlWriteOptions? options = null, CancellationToken ct = default);
}

internal static partial class Helpers
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
        return XmlConvert.ToDouble(res);
    }

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

const string hexColorRegex = @"^\s*(?<alpha>[a-zA-Z0-9]{2})?\s*(?<blue>[a-zA-Z0-9]{2})\s*(?<green>[a-zA-Z0-9]{2})\s*(?<red>[a-zA-Z0-9]{2})$";

#if NET7_0_OR_GREATER
    [RegexGenerator(hexColorRegex)]
    private static partial Regex HexColorRegex();
#else 
    private static Regex HexColorRegex() => new(hexColorRegex, RegexOptions.CultureInvariant);
#endif

    public static async Task<Color> ReadElementColorAsync(XmlReader reader, HashSet<string> alreadySet)
    {
        _ = alreadySet.Add(reader.Name);

        string colorStr = await reader.ReadElementContentAsStringAsync().ConfigureAwait(false);
        Match? matches = HexColorRegex().Match(colorStr);
        if (matches is null)
            throw new FormatException($"Could not parse color {colorStr}");


        return Color.FromArgb(alpha: matches.Groups["alpha"].ParseByteStr(colorStr),
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

public enum EnumConvertMode
{
    CamelCase, PascalCase, LowerCase, UpperCase
}

public enum BoolConvertMode
{
    Text,
    Numeric
}