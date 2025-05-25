using Raylib_cs;

namespace FeatherEngine;

public class Camera2D(int x, int y, int fov, int zoom)
{
    private Raylib_cs.Camera2D _camera = new();
    public Vec2 Position = new(x, y);
    public  float Fov = fov;
    public float Zoom = zoom;

    /// <summary>
    /// Sets the camera's position to the specified coordinates.
    /// </summary>
    /// <param name="x">The new X coordinate.</param>
    /// <param name="y">The new Y coordinate.</param>
    public void SetPosition(int x, int y)
    {
        Position.X = x;
        Position.Y = y;
    }

    /// <summary>
    /// Sets the camera's field of view to the specified value.
    /// </summary>
    /// <param name="fov">The new field of view.</param>
    public void SetFov(float fov)
    {
        Fov = fov;
    }

    /// <summary>
    /// Sets the camera's zoom level.
    /// </summary>
    /// <param name="zoom">The new zoom value.</param>
    public void SetZoom(float zoom)
    {
        Zoom = zoom;
    }
}