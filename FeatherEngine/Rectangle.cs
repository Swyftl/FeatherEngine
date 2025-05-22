using Raylib_cs;

namespace FeatherEngine;

public class Rectangle : IRenderable
{
    private Vec2 Position;
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

    public void Change_Position(int newX, int newY)
    {
        this.Position = new Vec2(newX, newY);
    }

    public void Change_Size(int newWidth, int newHeight)
    {
        this.Scale = new Vec2(newWidth, newHeight);
    }
}