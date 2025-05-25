using Raylib_cs;

namespace FeatherEngine;

public class Camera2D(int x, int y, int fov, int zoom)
{
    private Raylib_cs.Camera2D _camera = new();
    public Vec2 Position = new(x, y);
    public  float Fov = fov;
    public float Zoom = zoom;

    public void SetPosition(int x, int y)
    {
        Position.X = x;
        Position.Y = y;
    }

    public void SetFov(float fov)
    {
        Fov = fov;
    }

    public void SetZoom(float zoom)
    {
        Zoom = zoom;
    }
}