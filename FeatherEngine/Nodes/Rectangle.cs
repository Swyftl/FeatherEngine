using System.Numerics;
using SDL3;

namespace FeatherEngine.Nodes;

public class Rectangle : INode
{
    private SDL.FRect _rect;
    private byte _r, _g, _b, _a;

    public Rectangle(int x, int y, int w, int h, byte r, byte g, byte b, byte a = 255)
    {
        _rect = new SDL.FRect
        {
            X = x,
            Y = y,
            W = w,
            H = h
        };

        _r = r;
        _g = g;
        _b = b;
        _a = a;
    }

    public void Init(IntPtr window, IntPtr renderer)
    {
        // If you want, initialize the resources here
    }

    public void Update(float deltaTime)
    {
        // Update logic if needed
    }

    public void Render(IntPtr renderer)
    {
        SDL.SetRenderDrawColor(renderer, _r, _g, _b, _a);
        SDL.RenderFillRect(renderer, _rect);
    }

    public void Destroy()
    {
        // Cleanup if needed
    }

    public void ChangePosition(float x, float y)
    {
        _rect.X = x;
        _rect.Y = y;
    }

    public void ChangeSize(float w, float h)
    {
        _rect.W = w;
        _rect.H = h;
    }

    public float GetX()
    {
        return _rect.X;
    }

    public float GetY()
    {
        return _rect.Y;
    }
}