using System.Numerics;
using Raylib_cs;
using RaylibSandbox.Interfaces;

namespace RaylibSandbox;

public abstract class ControllableObject : IControllableObject
{
    protected float Speed { get; set; }
    protected Vector2 Position { get; set; }
    
    public virtual void HandleControls()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            Position += new Vector2(0, -Speed);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            Position += new Vector2(0, Speed);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            Position += new Vector2(-Speed, 0);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            Position += new Vector2(Speed, 0);
        }
    }
}