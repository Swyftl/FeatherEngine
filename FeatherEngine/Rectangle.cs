using Raylib_cs;

namespace FeatherEngine;

public class Rectangle(int x, int y, int width, int height) : IRenderable
{
    public void Draw()
    {
        Raylib.DrawRectangle(x, y, width, height, Color.Red);
    }
}