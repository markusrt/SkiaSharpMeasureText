using SkiaSharp;

namespace TestMeasurements;

public class Utils
{
    public static SKTypeface LoadFontFromResource(string font)
    {
        var assembly = typeof(Utils).Assembly;
        var stream = assembly.GetManifestResourceStream($"TestMeasurements.Fonts.{font}.ttf");
        if (stream == null)
            return null;
        var typeface = SKTypeface.FromStream(stream);
        return typeface;
    }
}