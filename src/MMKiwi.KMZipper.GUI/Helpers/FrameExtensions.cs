using Microsoft.UI.Xaml.Controls;

using SixLabors.ImageSharp;

namespace MMKiwi.KMZipper.GUI.Helpers;

public static class FrameExtensions
{
    public static object? GetPageViewModel(this Frame frame)
        => frame?.Content?.GetType().GetProperty("ViewModel")?.GetValue(frame.Content, null);
}

public static class RationalExtensions
{
    public static double ToDouble(this Rational[] portions)
    {
        double result = 0;
        for (int i = 0; i < portions.Length; i++)
            result += portions[i].ToDouble() / Math.Pow(60, i);

        return result;
    }
}