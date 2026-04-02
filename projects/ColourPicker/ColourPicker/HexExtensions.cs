namespace ColourPicker;

public static class HexExtensions
{
    public static string ToHex(this RgbColour color)
    {
        return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
    }

    public static RgbColour FromHex(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex is not ['#', _, _, _, _, _, _])
        {
            throw new ArgumentException("Invalid hex color format. Use #RRGGBB.");
        }

        var r = Convert.ToInt32(hex.Substring(1, 2), 16);
        var g = Convert.ToInt32(hex.Substring(3, 2), 16);
        var b = Convert.ToInt32(hex.Substring(5, 2), 16);

        return new RgbColour(r, g, b);
    }
}