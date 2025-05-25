using System;
using FeatherEngine;
using FeatherEngine.Nodes;
using SDL3;

public class Engine(int width, int height, string title)
{
    private INode _node;

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

        _node = new Rectangle(200, 150, 400, 300, 255, 0, 0);
        _node.Init(window, renderer);

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

            SDL.RenderClear(renderer);
            SDL.RenderPresent(renderer);
        }

        _node.Destroy();
        SDL.DestroyRenderer(renderer);
        SDL.DestroyWindow(window);
        
        SDL.Quit();
    }
}