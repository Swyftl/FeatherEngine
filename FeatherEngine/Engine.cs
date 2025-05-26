using FeatherEngine.Managers;
using SDL3;

namespace FeatherEngine;

public class Engine(int width, int height, string title)
{
    public NodeManager _nodeManager;
    private IntPtr window;
    private IntPtr renderer;

    public bool Running = true;

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
    }

    public void Step()
    {
        while (SDL.PollEvent(out var e))
        {
            if ((SDL.EventType)e.Type == SDL.EventType.Quit)
            {
                Running = false;
                Quit();
            }
        }

        SDL.SetRenderDrawColor(renderer, 0, 0, 0, 255);
        SDL.RenderClear(renderer);
            
        _nodeManager.RenderNodes();
            
        SDL.RenderPresent(renderer);
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