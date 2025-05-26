using SDL3;

namespace FeatherEngine.System;

public class Input(SDL.Keycode key)
{

    public SDL.Keycode Key;
    
    public bool OnKeyDown()
    {
        // ToDo - This must do something
        return false;
    }

    public bool OnKeyUp()
    {
        // ToDo - Make this do something
        return false;
    }
}