using System.Numerics;
using Raylib_cs;
using RaylibSandbox.GameObjects;
using RaylibSandbox.GameObjects.Position;

namespace RaylibSandbox.Scenes;

public class SampleMenu : Scene
{
    public SampleMenu()
    {
        AddGameObjects(
            new SimpleText
            {
                Position = new Vector2(Game.GetWindowCentre().X, 100),
                Text = "Another menu",
                TextColor = Color.BLACK,
                FontSize = 40,
                Origin = Origin.Center,
                Spacing = 5f,
                OnWindowResizeAction = (x) => x.Position = new Vector2(Game.GetWindowCentre().X, 100)
            },
            new Button
            {
                Position = new Vector2(Game.GetWindowCentre().X, 200),
                Text = "Go back",
                ClickAction = (_) => SceneManager.Instance.LoadScene("mainMenu"),
                Width = 200,
                Origin = Origin.Center,
                OnWindowResizeAction = (x) => x.Position = new Vector2(Game.GetWindowCentre().X, 200)
            },
            new Button
            {
                Position = new Vector2(Game.GetWindowCentre().X, 300),
                Text = "Get Rekt",
                ClickAction = GameObject.Destroy,
                Width = 200,
                Origin = Origin.Center,
                OnWindowResizeAction = (x) => x.Position = new Vector2(Game.GetWindowCentre().X, 300)
            }
        );
    }
}