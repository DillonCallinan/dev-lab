namespace ColourPicker;

public class PolarVector
{
    public double Magnitude { get; set; } // Length of the vector
    public double AngleDeg { get; set; }  // Angle in degrees

    public PolarVector(double magnitude, double angleDeg)
    {
        if (magnitude < 0)
        {
            // Reflect the angle if magnitude is negative
            magnitude = Math.Abs(magnitude);
            angleDeg += 180;
        }

        Magnitude = magnitude;
        AngleDeg = NormalizeAngle(angleDeg);
    }

    // Convert a PolarVector to a CartesianVector
    public CartesianVector ToCartesian()
    {
        var radians = AngleDeg * Math.PI / 180.0;
        var x = Magnitude * Math.Cos(radians);
        var y = Magnitude * Math.Sin(radians);
        return new CartesianVector(x, y);
    }

    // Add two polar vectors (via Cartesian conversion)
    public PolarVector Add(PolarVector other)
    {
        var cv1 = ToCartesian();
        var cv2 = other.ToCartesian();

        return cv1.Add(cv2).ToPolar();
    }

    // Normalize angle to [0, 360)
    public static double NormalizeAngle(double angleDeg)
    {
        var normalized = angleDeg % 360;
        if (normalized < 0) normalized += 360;
        return normalized;
    }
}