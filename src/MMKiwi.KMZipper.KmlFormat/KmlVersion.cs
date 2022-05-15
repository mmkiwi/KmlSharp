using System.Text.RegularExpressions;

namespace MMKiwi.KMZipper.KmlFormat;

public record class KmlVersion
{
    public KmlVersion()
    {
    }

    public KmlVersion(int major, int minor, int? patch = default)
    {
        Major = major;
        Minor = minor;
        Patch = patch;
    }

    public KmlVersion(string versionString)
    {
        (Major, Minor, Patch) = Parse(versionString);
    }

    public int Major { get; set; }
    public int Minor { get; set; }
    public int? Patch { get; set; }

    public override string ToString() => $"{Major}.{Minor}{(Patch.HasValue?$".{Patch}":"")}";

    internal (int major, int minor, int? patch) Parse(string versionString)
    {
        Regex regex = new("^(?<major>[1-2]).(?<minor>[1-9])(.(?<patch>0|[1-9][0-9]?))?$");
        Match match = regex.Match(versionString);
        if (!match.Success)
            throw new ArgumentException($"Invalid version string {versionString}", nameof(versionString));
        int major = int.Parse(match.Groups["major"].Value);
        int minor = int.Parse(match.Groups["minor"].Value);
        int? patch = match.Groups["patch"].Success ? int.Parse(match.Groups["patch"].Value) : null;

        return (major, minor, patch);
    }
}