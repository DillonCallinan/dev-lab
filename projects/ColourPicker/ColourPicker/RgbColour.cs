namespace ColourPicker;

public class RgbColour
{
    public int R
    {
        get;
        set => field = Math.Clamp(value, 0, 255);
    }

    public int G
    {
        get;
        set => field = Math.Clamp(value, 0, 255);
    }

    public int B
    {
        get;
        set => field = Math.Clamp(value, 0, 255);
    }

    public RgbColour(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public HslColour ToHsl()
    {
        var min = Math.Min(R, Math.Min(G, B));
        var max = Math.Max(R, Math.Max(G, B));

        var r = new PolarVector(R, 0);
        var g = new PolarVector(G, 120);
        var b = new PolarVector(B, 240);

        var sum = r.Add(g).Add(b);

        var h = sum.AngleDeg / 360;
        var s = sum.Magnitude / 255;
        var l = min + max / (255 * 2.0);

        return new HslColour(h, s, l);
    }
}