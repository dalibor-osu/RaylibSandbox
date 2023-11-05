using Raylib_cs;
using RaylibSandbox.Chart;

namespace RaylibSandbox.GameObjects;

public class Note : GameObject
{
    public NoteInfo NoteInfo { get; set; }
    public bool IsHit { get; set; }
    public Color Color { get; set; } = Color.BLACK;
    public float Radius { get; set; } = 20;
    
    public override void Draw()
    { 
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color);
    }
    
    public bool IsVisibleAtTime(int time)
    {
        return time >= NoteInfo.Time - 1000 && time <= NoteInfo.Time + 200;
    }
}