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
    
    public Button(int x, int y, int width, int height, string Text)
    {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
        this.Collider = new RectangleCollider(x, y, width, height);
        this.Rect = new Rectangle(x, y, width, height);
        this.Text = new RenderText(Text, x, y);
    }

    public void Draw()
    {
        Rect.Draw();
        Text.Draw();
    }

    public bool ButtonClicked()
    {
        if (Collider.checkClick() && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}