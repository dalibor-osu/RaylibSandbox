using System.Numerics;
using Raylib_cs;
using RaylibSandbox.Chart;
using RaylibSandbox.GameObjects;
using RaylibSandbox.GameObjects.Position;
using RaylibSandbox.Interfaces;

namespace RaylibSandbox.Scenes;

public class SongSelection : Scene
{
    private readonly string _chartsPath;
    
    public SongSelection(string chartsPath)
    {
        _chartsPath = chartsPath;
    }

    public override void OnSceneLoad()
    {
        var charts = ChartParser.ParseAll(_chartsPath);
        List<IGameObject> chartInfoCards = new();
        
        for (int i = 0; i < charts.Count; i++)
        {
            chartInfoCards.Add(
                new ChartInfoCard
                {
                    ChartData = charts[i],
                    Position = new Vector2(10, 10 + i * 110),
                    Origin = Origin.TopLeft,
                    Width = Game.WindowWidth / 2f - 20,
                    ClickAction = x => SceneManager.Instance.AddAndLoadScene(
                        new Gameplay(x.ChartData).UnloadOnSceneLoad(), "gameplay"),
                    OnWindowResizeAction = x => x.Width = Game.WindowWidth / 2f - 20
                }
            );
        }
        
        AddGameObjects(chartInfoCards.ToArray());
        
        AddGameObject(
            new Button
            {
                Position = new Vector2(Game.WindowWidth - 10, Game.WindowHeight - 10),
                Origin = Origin.BottomRight,
                Width = 200,
                ClickAction = _ => SceneManager.Instance.LoadScene("mainMenu"),
                Text = "Back",
                OnWindowResizeAction = x => x.Position = new Vector2(Game.WindowWidth - 10, Game.WindowHeight - 10)
            }
        );
    }

    public override void Draw()
    {
        float mouseWheelMove = Raylib.GetMouseWheelMove();
        
        if (mouseWheelMove != 0)
        {
            var chartInfoCards = Children.OfType<ChartInfoCard>().ToList();
            foreach (var card in chartInfoCards)
            {
                card.Position = card.Position with { Y = card.Position.Y + mouseWheelMove * 10};
            }
        }
        
        base.Draw();
    }

    public override void OnSceneUnload()
    {
        Children.Clear();
    }
}