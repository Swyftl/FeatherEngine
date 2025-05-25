using Raylib_cs;

namespace FeatherEngine;

public class Button : IRenderable
{
    private int X;
    private int Y;
    private int Width;
    private int Height;
    public RectangleCollider Collider;
    public Rectangle Rect;
    public RenderText Text;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Button"/> class with specified position, size, and label text.
    /// </summary>
    /// <param name="x">The X-coordinate of the button's top-left corner.</param>
    /// <param name="y">The Y-coordinate of the button's top-left corner.</param>
    /// <param name="width">The width of the button.</param>
    /// <param name="height">The height of the button.</param>
    /// <param name="Text">The label text displayed on the button.</param>
    public Button(int x, int y, int width, int height, string Text)
    {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
        this.Collider = new RectangleCollider(x, y, width, height);
        this.Rect = new Rectangle(x, y, width, height);
        // ToDo - Make the text of the button sit in the middle
        this.Text = new RenderText(Text, x, y);
    }

    /// <summary>
    /// Renders the button's rectangle and label to the screen.
    /// </summary>
    public void Draw()
    {
        Rect.Draw();
        Text.Draw();
    }

    /// <summary>
    /// Determines whether the button was clicked by checking if the mouse cursor is within the button's collider and the left mouse button was pressed.
    /// </summary>
    /// <returns>True if the button was clicked; otherwise, false.</returns>
    public bool ButtonClicked()
    {
        if (Collider.CheckClick() && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}