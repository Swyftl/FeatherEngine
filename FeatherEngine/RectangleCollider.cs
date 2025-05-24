using System.Numerics;
using Raylib_cs;

namespace FeatherEngine;

public class RectangleCollider(int x, int y, int width, int height)
{
    public bool checkClick()
    {
        var mousePosition = Raylib.GetMousePosition();
        if (Raylib.CheckCollisionPointRec(mousePosition,
                new Raylib_cs.Rectangle(new Vector2(x, y), new Vector2(width, height))))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}