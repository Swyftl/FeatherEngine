using System.Numerics;
using Raylib_cs;

namespace FeatherEngine;

public class Engine
{
    public bool IsRunning = true;

    public int Width;
    public int Height;
    public string Title;
    public bool Is3D = false;
    private int _fps;
    
    
    public GameObjectManager ObjectManager;
    public RenderManager Renderer;
    public Output Console;
    
    public Engine(int width, int height, string title, bool Is3D)
    {
        Raylib.SetTraceLogLevel(TraceLogLevel.Error);
        this.Width = width;
        this.Height = height;
        this.Title = title;
        this.ObjectManager = new GameObjectManager();
        this.Renderer = new RenderManager();
        this.Console = new Output();
        this.Is3D = Is3D;
        Raylib.InitWindow(width, height, title);

        if (Is3D)
        {
            Raylib.BeginMode3D(new Camera3D(Vector3.Zero, Vector3.Zero, new Vector3(0, 1, 0), 90.0f, CameraProjection.Perspective));
        }
        else
        {
            Raylib.BeginMode2D(new Camera2D(Vector2.Zero, Vector2.Zero, 0.0f, 1.0f));
        }
    }

    public void Run()
    {
        // Runs the function of the main loop
        if (!Raylib.WindowShouldClose())
        {
            double deltaTime = Raylib.GetFrameTime();
            ObjectManager.ProcessGameObjects(deltaTime);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Renderer.Render();
            
            Raylib.EndDrawing();
        }
        else
        {
            Raylib.CloseWindow();
            IsRunning = false;
        }
    }

    public void set_title(string t)
    {
        Raylib.SetWindowTitle(t);
        this.Title = t;
    }

    public void change_window_size(int w, int h)
    {
        this.Width = w;
        this.Height = h;
        Raylib.SetWindowSize(w, h);
    }

    public void change_framerate(int fps)
    {
        this._fps = fps;
        Raylib.SetTargetFPS(this._fps);
    }

    public void set_window_fullscreen()
    {
        if (!Raylib.IsWindowFullscreen())
        {
            Raylib.ToggleFullscreen();   
        }
    }

    public void set_window_windowed()
    {
        if (Raylib.IsWindowFullscreen())
        {
            Raylib.ToggleFullscreen();
        }
    }

    public void toggle_fullscreen()
    {
        Raylib.ToggleFullscreen();
    }

    public void take_screenshot(string filename)
    {
        Raylib.TakeScreenshot(filename);
    }

    public float get_deltaTime()
    {
        return Raylib.GetFrameTime();
    }

    public float get_FPS()
    {
        return Raylib.GetFPS();
    }
}