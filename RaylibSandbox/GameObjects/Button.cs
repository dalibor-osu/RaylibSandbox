using System.Numerics;
using Raylib_cs;
using RaylibSandbox.GameObjects.Position;
using RaylibSandbox.Interfaces;

namespace RaylibSandbox.GameObjects;

public class Button : UIGameObject<Button>, IClickable
{
    public string Text { get; set; } = string.Empty;
    public Action<Button> ClickAction { get; set; } = (_) => { };
    public float Width { get; set; } = 100f;
    public float Height { get; set; } = 50f;
    public Color TextColor { get; set; } = Color.WHITE;
    public Color BackgroundColor { get; set; } = Color.BLACK;
    public int FontSize { get; set; } = 20;
    
    public override void Draw()
    {
        var rectanglePosition = PositionHelper.CalculateRectanglePositionFromOrigin(Position, new Vector2(Width, Height), Origin);
        var rectangleCentre = new Vector2(rectanglePosition.X + Width / 2f, rectanglePosition.Y + Height / 2f);
        var textPosition = CalculateTextPosition(rectangleCentre);
        
        Raylib.DrawRectangle((int)rectanglePosition.X, (int)rectanglePosition.Y, (int)Width, (int)Height, BackgroundColor);
        Raylib.DrawText(Text, (int)textPosition.X, (int)textPosition.Y, FontSize, TextColor);
    }

    public bool IsClicked()
    {
        var rectanglePosition = PositionHelper.CalculateRectanglePositionFromOrigin(Position, new Vector2(Width, Height), Origin);
        return Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(),
            new Rectangle(rectanglePosition.X, rectanglePosition.Y, Width, Height));
    }

    public void OnClick()
    {
        ClickAction(this);
    }
    
    public override void OnWindowResize() => OnWindowResizeAction(this);
    
    private Vector2 CalculateTextPosition(Vector2 boxCentre)
    {
        var textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), Text, FontSize, 1f);
        return PositionHelper.CalculateRectanglePositionFromOrigin(boxCentre, textSize, Origin.Center);
    }
}