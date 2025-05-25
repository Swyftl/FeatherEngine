namespace FeatherEngine;

public struct Vec2
{
    public float X { get; set; }
    public float Y { get; set; }

    public Vec2(float x, float y)
    {
        X = x;
        Y = y;
    }

    // Vector addition
    public static Vec2 operator +(Vec2 a, Vec2 b)
    {
        return new Vec2(a.X + b.X, a.Y + b.Y);
    }

    public static bool operator !=(Vec2 a, Vec2 b)
    {
        if (a.X != b.X || a.Y != b.Y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool operator ==(Vec2 a, Vec2 b)
    {
        if (a.X == b.X && a.Y == b.Y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Vector subtraction
    public static Vec2 operator -(Vec2 a, Vec2 b)
    {
        return new Vec2(a.X - b.X, a.Y - b.Y);
    }

    // Scalar multiplication
    public static Vec2 operator *(Vec2 a, float scalar)
    {
        return new Vec2(a.X * scalar, a.Y * scalar);
    }

    // Scalar division
    public static Vec2 operator /(Vec2 a, float scalar)
    {
        return new Vec2(a.X / scalar, a.Y / scalar);
    }

    // Magnitude (Length)
    public float Magnitude()
    {
        return (float)Math.Sqrt(X * X + Y * Y);
    }

    // Normalize
    public Vec2 Normalize()
    {
        float magnitude = Magnitude();
        if (magnitude > 0)
            return this / magnitude;
        return new Vec2(0, 0);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}
