using System.Numerics;
using Raylib_cs;
using RaylibSandbox.Chart;
using RaylibSandbox.GameObjects.Position;
using RaylibSandbox.Interfaces;
using Serilog;

namespace RaylibSandbox.GameObjects;

public class ChartInfoCard : UIGameObject<ChartInfoCard>, IClickable
{
    public ChartData ChartData { get; set; }
    public float Width { get; set; } = 200f;
    public float Height { get; set; } = 100f;
    public Color BackgroundColor { get; set; } = Color.BLACK;
    public Color TextColor { get; set; } = Color.WHITE;
    public int FontSize { get; set; } = 20;
    public Action<ChartInfoCard> ClickAction { get; set; } = (_) => { };
    
    public override void Draw()
    {
        var rectanglePosition = PositionHelper.CalculateRectanglePositionFromOrigin(Position, new Vector2(Width, Height), Origin);
        var nameTextPosition = CalculateTextPosition(new Vector2(Position.X + 10, Position.Y + 10), ChartData.SongData.Name);
        
        Raylib.DrawRectangle((int)rectanglePosition.X, (int)rectanglePosition.Y, (int)Width, (int)Height, BackgroundColor);
        Raylib.DrawText(ChartData.SongData.Name, (int)nameTextPosition.X, (int)nameTextPosition.Y, FontSize, TextColor);
        Raylib.DrawText($"by {ChartData.SongData.Artist}", (int)nameTextPosition.X, (int)nameTextPosition.Y + FontSize + 10, (int)(FontSize * 0.8), TextColor);
    }

    public override void OnWindowResize()
    {
        OnWindowResizeAction(this);
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
    
    private Vector2 CalculateTextPosition(Vector2 boxCentreLeft, string text)
    {
        var textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), text, FontSize, 1f);
        return PositionHelper.CalculateRectanglePositionFromOrigin(boxCentreLeft, textSize, Origin.TopLeft);
    }
}