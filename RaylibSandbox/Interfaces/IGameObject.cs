using System.Numerics;
using RaylibSandbox.GameObjects.Position;
using RaylibSandbox.Scenes;

namespace RaylibSandbox.Interfaces;

public interface IGameObject
{
    public Scene ParentScene { get; set; }
    public Vector2 Position { get; set; }
    public Origin Origin { get; set; }
    public bool IsVisible { get; set; }
    public void Draw();
}