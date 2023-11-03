using System.Numerics;
using Raylib_cs;

namespace RaylibSandbox;

public class TextGameObject : GameObject
{
    public string Text { get; private set; }
    
    public TextGameObject(string text, Vector2 position)
    {
        Text = text;
        Position = position;
    }
    
    public void SetText(string text)
    {
        Text = text;
    }
    
    public override void Draw()
    {
        Raylib.DrawText(Text, (int)Position.X, (int)Position.Y, 20, Color.BLACK);
    }
}