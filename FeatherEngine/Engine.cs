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
    
    /// <summary>
    /// Initializes the game engine with the specified window size, title, and rendering mode (2D or 3D).
    /// </summary>
    /// <param name="width">The width of the game window in pixels.</param>
    /// <param name="height">The height of the game window in pixels.</param>
    /// <param name="title">The title of the game window.</param>
    /// <param name="Is3D">If true, initializes the engine in 3D mode; otherwise, uses 2D mode.</param>
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
            Raylib.BeginMode2D(new Raylib_cs.Camera2D(Vector2.Zero, Vector2.Zero, 0.0f, 1.0f));
        }
    }

    /// <summary>
    /// Executes a single iteration of the main game loop, processing game objects and rendering the current frame. Closes the window and stops the engine if the window should close.
    /// </summary>
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

    /// <summary>
    /// Sets the window title to the specified string.
    /// </summary>
    /// <param name="t">The new title for the window.</param>
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

    /// <summary>
    /// Captures the current window and saves it as an image file with the specified filename.
    /// </summary>
    /// <param name="filename">The name of the file to save the screenshot to.</param>
    public void take_screenshot(string filename)
    {
        Raylib.TakeScreenshot(filename);
    }

    /// <summary>
    /// Returns the time elapsed during the last frame in seconds.
    /// </summary>
    /// <returns>Frame time in seconds.</returns>
    public float get_deltaTime()
    {
        return Raylib.GetFrameTime();
    }

    /// <summary>
    /// Returns the current frames per second.
    /// </summary>
    /// <returns>The current FPS value.</returns>
    public float get_FPS()
    {
        return Raylib.GetFPS();
    }
}