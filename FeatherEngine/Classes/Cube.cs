using System.Numerics;
using Raylib_cs;

namespace FeatherEngine;

public class Cube: IRenderable
{

    private Vector3 Position;
    private Vector3 Size;
    
    public Cube(Vector3 position, Vector3 size)
    {
        this.Position = position;
        this.Size = size;
    }

    public void Draw()
    {
        Raylib.DrawCube(this.Position, this.Size.X, this.Size.Y, this.Size.Z, Color.Red);
    }
}