using Raylib_cs;

namespace RaylibSandbox.GameObjects;

public class NoteContainer : UIGameObject<NoteContainer>
{
    public float Radius { get; set; } = 50;
    public float Spacing { get; set; } = 10;
    public Color Color { get; set; } = Color.RED;
    public override void Draw()
    {
        float x = Position.X - 1.5f * Spacing - 3 * Radius;
        for (int i = 0; i < 4; i++)
        {
            Raylib.DrawCircle((int)x, (int)Position.Y, Radius, Color);
            x += Spacing + 2 * Radius;
        }
    }

    public override void OnWindowResize()
    {
        throw new NotImplementedException();
    }
}