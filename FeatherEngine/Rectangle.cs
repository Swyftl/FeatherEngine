using Raylib_cs;

namespace FeatherEngine;

public class Rectangle : IRenderable
{
    public Vec2 Position { get; private set; }
    private Vec2 Scale;

    public Rectangle(Vec2 Position, Vec2 Scale)
    {
        this.Position = Position;
        this.Scale = Scale;
    }
    
    public void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Scale.X, (int)Scale.Y , Color.Red);
    }

    public void Set_Position(int newX, int newY)
    {
        this.Position = new Vec2(newX, newY);
    }

    public void Change_Position(Vec2 newPosition)
    {
        this.Position = (Position + newPosition);
    }

    public void Set_Size(Vec2 newSize)
    {
        this.Scale = newSize;
    }

    public void Change_Size(Vec2 changeAmount)
    {
        this.Scale = Scale + changeAmount;
    }
}