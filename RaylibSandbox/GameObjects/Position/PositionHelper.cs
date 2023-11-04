using System.Numerics;

namespace RaylibSandbox.GameObjects.Position;

public static class PositionHelper
{
    public static Vector2 CalculateRectanglePositionFromOrigin(Vector2 position, Vector2 rectangleDimensions, Origin origin)
    {
        return origin switch
        {
            Origin.TopLeft => position,
            Origin.TopCenter => new Vector2(position.X - rectangleDimensions.X / 2, position.Y),
            Origin.TopRight => new Vector2(position.X - rectangleDimensions.X, position.Y),
            Origin.CenterLeft => new Vector2(position.X, position.Y - rectangleDimensions.Y / 2),
            Origin.Center => new Vector2(position.X - rectangleDimensions.X / 2, position.Y - rectangleDimensions.Y / 2),
            Origin.CenterRight => new Vector2(position.X - rectangleDimensions.X, position.Y - rectangleDimensions.Y / 2),
            Origin.BottomLeft => new Vector2(position.X, position.Y - rectangleDimensions.Y),
            Origin.BottomCenter => new Vector2(position.X - rectangleDimensions.X / 2, position.Y - rectangleDimensions.Y),
            _ => new Vector2(position.X - rectangleDimensions.X, position.Y - rectangleDimensions.Y)
        };
    }
}