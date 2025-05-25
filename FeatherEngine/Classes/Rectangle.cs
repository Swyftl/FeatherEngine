using Raylib_cs;

namespace FeatherEngine;

public class Rectangle : IRenderable
{
    public Vec2 Position { get; private set; }
    public Vec2 Scale { get; private set; }
    public bool Visible { get; set; } = true;

    /// <summary>
    /// Initializes a new Rectangle with the specified position and size.
    /// </summary>
    /// <param name="X">The X-coordinate of the rectangle's position.</param>
    /// <param name="Y">The Y-coordinate of the rectangle's position.</param>
    /// <param name="Width">The width of the rectangle.</param>
    /// <param name="Height">The height of the rectangle.</param>
    public Rectangle(int X, int Y, int Width, int Height)
    {
        this.Position = new Vec2(X, Y);
        this.Scale = new Vec2(Width, Height);
    }
    
    /// <summary>
    /// Draws the rectangle in red if it is marked as visible.
    /// </summary>
    public void Draw()
    {
        if (Visible)
        {
            Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Scale.X, (int)Scale.Y , Color.Red);
        }
    }

    /// <summary>
    /// Sets the rectangle's position to the specified coordinates.
    /// </summary>
    /// <param name="newPosition">The new position for the rectangle.</param>
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

    /// <summary>
    /// Increases the rectangle's size by the specified amount.
    /// </summary>
    /// <param name="changeAmount">The amount to add to the current size.</param>
    public void Change_Size(Vec2 changeAmount)
    {
        this.Scale = Scale + changeAmount;
    }

    /// <summary>
    /// Sets the visibility state of the rectangle.
    /// </summary>
    /// <param name="isTrue">If true, the rectangle will be visible; otherwise, it will be hidden.</param>
    public void Set_Visible(bool isTrue)
    {
        Visible = isTrue;
    }
}