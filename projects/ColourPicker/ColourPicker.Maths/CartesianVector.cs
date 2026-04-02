namespace ColourPicker.Maths;

public class CartesianVector(double x, double y)
{
    public double X { get; set; } = x; // X coordinate
    public double Y { get; set; } = y; // Y coordinate

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
