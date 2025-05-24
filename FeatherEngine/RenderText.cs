using Raylib_cs;

namespace FeatherEngine;

public class RenderText : IRenderable
{

    private string Text;
    private int X;
    private int Y;
    private int FontSize = 22;
    private Color FontColor = Color.Black;
    
    public RenderText(string Text, int X, int Y)
    {
        this.Text = Text;
        this.X = X;
        this.Y = Y;
    }

    public void Draw()
    {
        Raylib.DrawText(Text, X, Y, FontSize, FontColor);
    }

    public void ChangeFontSize(int NewFontSize)
    {
        this.FontSize = NewFontSize;
    }

    public void ChangeFontColor(Color NewFontColor)
    {
        this.FontColor = NewFontColor;
    }
}