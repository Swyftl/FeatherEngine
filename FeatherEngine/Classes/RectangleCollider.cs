using System.Numerics;
using Raylib_cs;

namespace FeatherEngine;

public class RectangleCollider(int x, int y, int width, int height)
{
    /// <summary>
    /// Determines whether the current mouse position is within the bounds of the rectangle collider.
    /// </summary>
    /// <returns>True if the mouse is inside the rectangle; otherwise, false.</returns>
    public bool CheckClick()
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