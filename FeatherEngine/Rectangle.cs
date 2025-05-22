using Raylib_cs;

namespace FeatherEngine;

public class Rectangle(int x, int y, int width, int height) : IRenderable
{
    public void Draw()
    {
        Raylib.DrawRectangle(x, y, width, height, Color.Red);
    }

    public void Change_Position(int newX, int newY)
    {
        x = newX;
        y = newY;
    }

    public void Change_Size(int newWidth, int newHeight)
    {
        width = newWidth;
        height = newHeight;
    }
}