using System.Numerics;
using Raylib_cs;
using RaylibSandbox.Chart;
using RaylibSandbox.GameObjects;

namespace RaylibSandbox.Scenes;

public class Gameplay : Scene
{
    private readonly ChartData _chartData;
    
    public Gameplay(ChartData chartData)
    {
        _chartData = chartData;
    }
    
    public override void Draw()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
        {
            SceneManager.Instance.LoadScene("songSelection");
        }
        base.Draw();
    }
    
    public override void OnSceneLoad()
    {
        AddGameObject(new NoteContainer
        {
            Position = new Vector2(Game.WindowWidth / 2f, Game.WindowHeight - 100),
        });
    }

    public override void OnSceneUnload()
    {
        
    }
}