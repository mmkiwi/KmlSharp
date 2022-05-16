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