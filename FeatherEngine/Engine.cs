using FeatherEngine.Managers;
using FeatherEngine.Nodes;
using SDL3;

namespace FeatherEngine;

public class Engine(int width, int height, string title)
{
    private NodeManager? _nodeManager;
    
    private INode? _node;

    public void Run()
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
        
        // Put all the nodes into the node manager
        _nodeManager = new NodeManager(renderer);
        
        _node = new Rectangle(200, 150, 400, 300, 255, 100, 100);
        _node.Init(window, renderer);
        
        _nodeManager.AddNode(_node);

        bool running = true;
        while (running)
        {
            while (SDL.PollEvent(out var e))
            {
                if ((SDL.EventType)e.Type == SDL.EventType.Quit)
                {
                    running = false;
                }
            }

            SDL.SetRenderDrawColor(renderer, 0, 0, 0, 255);
            SDL.RenderClear(renderer);
            
            _nodeManager.RenderNodes();
            
            SDL.RenderPresent(renderer);
        }
        _nodeManager.OnQuit();
        SDL.DestroyRenderer(renderer);
        SDL.DestroyWindow(window);
        
        SDL.Quit();
    }
}