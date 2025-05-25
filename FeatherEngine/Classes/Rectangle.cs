using Raylib_cs;

namespace FeatherEngine;

public class Rectangle : IRenderable
{
    public Vec2 Position { get; private set; }
    public Vec2 Scale { get; private set; }
    public bool Visible { get; set; } = true;

    public Rectangle(int X, int Y, int Width, int Height)
    {
        this.Position = new Vec2(X, Y);
        this.Scale = new Vec2(Width, Height);
    }
    
    public void Draw()
    {
        if (Visible)
        {
            Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Scale.X, (int)Scale.Y , Color.Red);
        }
    }

    public void Set_Position(Vec2 newPosition)
    {
        this.Position = newPosition;
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

    public void Set_Visible(bool isTrue)
    {
        Visible = isTrue;
    }
}