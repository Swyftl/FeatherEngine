using FeatherEngine.Managers;
using SDL3;

namespace FeatherEngine;

public class Engine(int width, int height, string title)
{
    public NodeManager _nodeManager;
    public InputManager _inputManager;
    private IntPtr window;
    private IntPtr renderer;

    public bool Running = true;

    public Performance performance;

    public void Init()
    {

        if (!SDL.Init(SDL.InitFlags.Video))
        {
            Console.WriteLine("SDL3 init failed.");
            return;
        }

        if (!SDL.CreateWindowAndRenderer(title, width, height, 0, out var window, out var renderer))
        {
            SDL.LogError(SDL.LogCategory.Application, $"Error creating window and rendering: {SDL.GetError()}");
            return;
        }

        this.window = window;
        this.renderer = renderer;

        // Put all the nodes into the node manager
        _nodeManager = new NodeManager(renderer);
        _inputManager = new InputManager();
        performance = new Performance();
    }

    public void Step()
    {
        while (SDL.PollEvent(out var e))
        {
            switch ((SDL.EventType)e.Type)
            {
                case SDL.EventType.Quit:
                    Running = false;
                    Quit();
                    return;
                case SDL.EventType.KeyDown:
                    var KeyDown = e.Key;
                    _inputManager.KeyDown(KeyDown.Key);
                    return;
                case SDL.EventType.KeyUp:
                    var KeyUp = e.Key;
                    _inputManager.KeyUp(KeyUp.Key);
                    return;
            }
        }

        SDL.SetRenderDrawColor(renderer, 0, 0, 0, 255);
        SDL.RenderClear(renderer);
            
        _nodeManager.RenderNodes();
            
        SDL.RenderPresent(renderer);
        performance.Update();
    }

    public void Quit()
    {
        Running = false;
        _nodeManager.OnQuit();
        SDL.DestroyRenderer(renderer);
        SDL.DestroyWindow(window);

        SDL.Quit();
    }

public IntPtr GetWindow()
    {
        return window;
    }

    public IntPtr GetRenderer()
    {
        return renderer;
    }
}

public class Performance
{
    private ulong _lastTime = SDL.GetPerformanceCounter();
    private int _frameCount;
    private double _fps;

    public void Update()
    {
        _frameCount++;
        var currentTime = SDL.GetPerformanceCounter();
        var elapsedTime = (currentTime - _lastTime) / (double)SDL.GetPerformanceFrequency();

        if (elapsedTime >= 0.1) return;

        _fps = _frameCount / elapsedTime;
        _frameCount = 0;
        _lastTime = currentTime;
    }

    public double Fps => _fps;
}