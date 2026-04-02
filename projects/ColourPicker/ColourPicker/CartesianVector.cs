namespace ColourPicker;

public class CartesianVector
{
    public double X { get; set; } // X coordinate
    public double Y { get; set; } // Y coordinate

    public CartesianVector(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Add two Cartesian vectors
    public CartesianVector Add(CartesianVector other)
    {
        return new CartesianVector(X + other.X, Y + other.Y);
    }

    // Convert a CartesianVector to a PolarVector
    public PolarVector ToPolar()
    {
        var magnitude = Math.Sqrt(X * X + Y * Y);
        var angleDeg = Math.Atan2(Y, X) * 180.0 / Math.PI;
        return new PolarVector(magnitude, angleDeg);
    }
}