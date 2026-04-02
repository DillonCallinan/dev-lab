namespace ColourPicker;

public class HslColour
{
    public double H
    {
        get;
        set => field = Math.Clamp(value, 0, 1);
    }

    public double S
    {
        get;
        set => field = Math.Clamp(value, 0, 1);
    }

    public double L
    {
        get;
        set => field = Math.Clamp(value, 0, 1);
    }

    public HslColour(double h, double s, double l)
    {
        H = h;
        S = s;
        L = l;
    }

    public RgbColour ToRgb()
    {
        double r, g, b, ratio;

        var angle = PolarVector.NormalizeAngle(H * 360);

        if (angle is >= 0 and <= 120)
        {
            ratio = angle / 120;

            r = 1 - ratio;
            g = ratio;
            b = 0;
        }
        else if (angle is > 120 and <= 240)
        {
            ratio = (angle - 120) / 120;

            r = 0;
            g = 1 - ratio;
            b = ratio;
        }
        else
        {
            ratio = (angle - 240) / 120;

            r = ratio;
            g = 0;
            b = 1 - ratio;
        }

        double min, max;

        if (L < 0.5)
        {
            max = L + S * L;
            min = L - S * L;
        }
        else
        {
            max = L + S * (1 - L);
            min = L - S * (1 - L);
        }

        min *= 255;
        max *= 255;

        var range = max - min;

        return new RgbColour(
            (int)Math.Round(min + range * r, MidpointRounding.AwayFromZero),
            (int)Math.Round(min + range * g, MidpointRounding.AwayFromZero),
            (int)Math.Round(min + range * b, MidpointRounding.AwayFromZero));
    }
}