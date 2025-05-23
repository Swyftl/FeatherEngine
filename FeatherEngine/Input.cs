using Raylib_cs;

namespace FeatherEngine;

public class Input(KeyboardKey key)
{
    private KeyboardKey InputKey = key;
    private bool was_key_down = false;

    public bool IsKeyDown()
    {
        if (Raylib.IsKeyDown(InputKey))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsKeyUp()
    {
        if (Raylib.IsKeyUp(InputKey))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int IsKeyDown_Int()
    {
        if (Raylib.IsKeyDown(InputKey))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}