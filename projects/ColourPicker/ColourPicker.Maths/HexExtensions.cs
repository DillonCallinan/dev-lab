namespace ColourPicker.Maths;

public static class HexExtensions
{
    public static string ToHex(this RgbColour color)
    {
        return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
    }

    public static RgbColour FromHex(string hex)
    {
        if (string.IsNullOrEmpty(hex)
            || hex is not ['#', char r1, char r2, char g1, char g2, char b1, char b2]
            || !IsHexDigit(r1)
            || !IsHexDigit(r2)
            || !IsHexDigit(g1)
            || !IsHexDigit(g2)
            || !IsHexDigit(b1)
            || !IsHexDigit(b2))
        {
            throw new ArgumentException("Invalid hex color format. Use #RRGGBB.");
        }

        var r = Convert.ToInt32(hex.Substring(1, 2), 16);
        var g = Convert.ToInt32(hex.Substring(3, 2), 16);
        var b = Convert.ToInt32(hex.Substring(5, 2), 16);

        return new RgbColour(r, g, b);
    }

    private static bool IsHexDigit(char c)
    {
        return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');
    }
}
