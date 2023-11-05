using System.Numerics;
using Raylib_cs;
using RaylibSandbox.GameObjects;
using RaylibSandbox.GameObjects.Position;

namespace RaylibSandbox.Scenes;

public class MainMenu : Scene
{
    public MainMenu()
    {
        AddGameObjects(
            new SimpleText
            {
                Position = new Vector2(Game.WindowWidth / 2f, 100),
                Text = "Main Menu",
                FontSize = 40,
                TextColor = Color.BLACK,
                Origin = Origin.Center,
                Spacing = 5f,
                OnWindowResizeAction = (x) => x.Position = new Vector2(Game.WindowWidth / 2f, 100)
            },
            new Button
            {
                Position = new Vector2(Game.WindowWidth / 2f, 200),
                Text = "Start Game",
                ClickAction = (x) => SceneManager.Instance.LoadScene("songSelection"),
                Width = 200,
                Origin = Origin.Center,
                OnWindowResizeAction = (x) => x.Position = new Vector2(Game.WindowWidth / 2f, 200)
            },
            new Button
            {
                Position = new Vector2(Game.WindowWidth / 2f, 300),
                Text = "Quit",
                ClickAction = (_) => Game.Exit(),
                Width = 200,
                Origin = Origin.Center,
                OnWindowResizeAction = (x) => x.Position = new Vector2(Game.WindowWidth / 2f, 300)
            }
        );
    }
}