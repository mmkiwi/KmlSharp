using System.Globalization;

namespace MMKiwi.KMZipper.KmlFormat;

public record class KmlCoordinates : XmlStringElement
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double? Altitude { get; set; }

    public KmlCoordinates()
    { }

    public KmlCoordinates(string input)
    {
        (Longitude, Latitude, Altitude) = parse(input);
    }


    private (double Longitude, double Latitude, double? Altitude) parse(string input)
    {
        //Split at commas, trim out any whitespace
        string[] elements = input.Split(',').Select(el => el.Trim()).ToArray();
        if (elements.Length is not 2 and not 3)
            throw new ArgumentException(input, $"Coordinate string {input} is not well formed.");

        double? altitude;
        if (!double.TryParse(elements[0], NumberStyles.Number, CultureInfo.InvariantCulture, out double longitude))
            throw new ArgumentException(input, $"Coordinate string {input} is not well formed.");
        if (!double.TryParse(elements[1], NumberStyles.Number, CultureInfo.InvariantCulture, out double latitude))
            throw new ArgumentException(input, $"Coordinate string {input} is not well formed.");
        if (elements.Length == 2 || string.IsNullOrEmpty(elements[2]))
            altitude = null;
        else if (!double.TryParse(elements[2], NumberStyles.Number, CultureInfo.InvariantCulture, out double altitudeVal))
            throw new ArgumentException(input, $"Coordinate string {input} is not well formed.");
        else
            altitude = altitudeVal;

        return (longitude, latitude, altitude);

    }

    public override string ToString() => $"{Longitude},{Latitude}{(Altitude == null ? null : $",{Altitude}")}";
    protected override void Parse(string input) => (Longitude, Latitude, Altitude) = parse(input);
}
