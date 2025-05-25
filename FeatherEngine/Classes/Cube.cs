using System.Numerics;
using Raylib_cs;

namespace FeatherEngine;

public class Cube: IRenderable
{

    private Vector3 Position;
    private Vector3 Size;
    
    /// <summary>
    /// Initializes a new instance of the Cube class with the specified position and size.
    /// </summary>
    /// <param name="position">The 3D position of the cube's center.</param>
    /// <param name="size">The dimensions (width, height, depth) of the cube.</param>
    public Cube(Vector3 position, Vector3 size)
    {
        this.Position = position;
        this.Size = size;
    }

    /// <summary>
    /// Renders the cube at its specified position and size using a red color.
    /// </summary>
    public void Draw()
    {
        Raylib.DrawCube(this.Position, this.Size.X, this.Size.Y, this.Size.Z, Color.Red);
    }
}