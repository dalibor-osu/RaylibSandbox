using System.Numerics;
using Raylib_cs;
using RaylibSandbox.GameObjects.Position;

namespace RaylibSandbox.GameObjects;

public class SimpleText : UIGameObject<SimpleText>
{
    public string Text { get; set; } = string.Empty;
    public Color TextColor { get; set; } = Color.WHITE;
    public int FontSize { get; set; } = 20;
    public Font Font { get; set; } = Raylib.GetFontDefault();
    public float Spacing { get; set; } = 1f;

    public override void Draw()
    {
        var textPosition = CalculateTextPosition();
        Raylib.DrawTextEx(Font, Text, textPosition, FontSize, Spacing, TextColor);
    }

    public override void OnWindowResize() => OnWindowResizeAction(this);

    private Vector2 CalculateTextPosition()
    {
        var textSize = Raylib.MeasureTextEx(Font, Text, FontSize, Spacing);
        return PositionHelper.CalculateRectanglePositionFromOrigin(Position, textSize, Origin);
    }
}