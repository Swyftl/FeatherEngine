using Raylib_cs;

namespace FeatherEngine;

public class Engine
{
    public bool IsRunning = true;

    public int Width;
    public int Height;
    public string Title;
    private int _fps;
    private GameObjectManager _gameObjectManager;

    public RenderManager Renderer;
    
    public Engine(int width, int height, string title)
    {
        this.Width = width;
        this.Height = height;
        this.Title = title;
        this._gameObjectManager = new GameObjectManager();
        this.Renderer = new RenderManager();
        Raylib.InitWindow(width, height, title);
    }

    public void Run()
    {
        // Runs the function of the main loop
        if (!Raylib.WindowShouldClose())
        {
            double deltaTime = Raylib.GetFrameTime();
            _gameObjectManager.ProcessGameObjects(deltaTime);
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

    public void change_window_title(string t)
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
}