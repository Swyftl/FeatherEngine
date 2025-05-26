using SDL3;

namespace FeatherEngine.System;

public class Input
{

    public SDL.Keycode Key;
    public bool KeyDown = false;

    public Input(SDL.Keycode key)
    {
        this.Key = key;
        this.KeyDown = false;
    }
    
    public bool IsKeyPressed()
    {
        return KeyDown;
    }

    public bool OnKeyUp()
    {
        return !KeyDown;
    }
}