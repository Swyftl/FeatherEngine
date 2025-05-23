namespace FeatherEngine;

public class Output
{
    public void Print(string input)
    {
        System.Console.WriteLine(input);
    }

    public void Print(string input, ConsoleColor color)
    {
        System.Console.ForegroundColor = color;
        System.Console.WriteLine(input);
    }
}