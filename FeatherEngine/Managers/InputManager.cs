using FeatherEngine.System;
using SDL3;

namespace FeatherEngine.Managers;

public class InputManager
{
    private List<Input> inputs = new List<Input>();

    private void AddInput(Input input)
    {
        inputs.Add(input);
    }

    public void RemoveInput(Input input)
    {
        inputs.Remove(input);
    }

    public void KeyDown(SDL.Keycode key)
    {
        foreach (var input in inputs.Where(input => input.Key == key))
        {
            input.OnKeyDown();
            break;
        }
    }

    public void KeyUp(SDL.Keycode key)
    {
        foreach (var input in inputs.Where(input => input.Key == key))
        {
            input.OnKeyUp();
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