using System.Numerics;
using Raylib_cs;
using RaylibSandbox.Interfaces;

namespace RaylibSandbox;

public class CircleGameObject : GameObject, IClickable
{
    private const float RADIUS = 50f;
    
    private readonly Color _color = Color.RED;
    
    public CircleGameObject(Vector2 position)
    {
        Position = position;
    }

    public override void Draw()
    {
        Raylib.DrawCircleV(Position, RADIUS, _color);
    }

    public bool IsClicked()
    {
        return Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) &&
               Raylib.CheckCollisionPointCircle(Raylib.GetMousePosition(), Position, RADIUS);
    }

    public void OnClick()
    {
        var textGameObject = new TextGameObject($"Clicked at {Game.Time.Elapsed:g}", Position);
        ParentScene.AddGameObject(textGameObject);
        Destroy(this);
    }
}