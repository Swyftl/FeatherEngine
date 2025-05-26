using FeatherEngine.System;
using SDL3;

namespace FeatherEngine.Managers;

public class InputManager
{
    private List<Input> _inputs = [];

    private void AddInput(Input input)
    {
        _inputs.Add(input);
    }

    public void RemoveInput(Input input)
    {
        _inputs.Remove(input);
    }

    public void KeyDown(SDL.Keycode key)
    {
        foreach (var input in _inputs.Where(input => input.Key == key))
        {
            input.KeyDown = true;
            break;
        }
    }

    public void KeyUp(SDL.Keycode key)
    {
        foreach (var input in _inputs.Where(input => input.Key == key))
        {
            input.KeyDown = false;
            break;
        }
    }

    public Input NewInput(SDL.Keycode key)
    {
        var newInput = new Input(key);
        AddInput(newInput);
        return newInput;
    }
}