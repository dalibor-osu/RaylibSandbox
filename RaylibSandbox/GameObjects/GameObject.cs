using System.Numerics;
using RaylibSandbox.GameObjects.Position;
using RaylibSandbox.Interfaces;
using RaylibSandbox.Scenes;

namespace RaylibSandbox.GameObjects;

public abstract class GameObject : IGameObject
{
    public Scene ParentScene { get; set; }
    public Vector2 Position { get; set; }
    public Origin Origin { get; set; } = Origin.TopLeft;
    public abstract void Draw();
    
    public static void Destroy(IGameObject gameObject)
    {
        gameObject.ParentScene.Children.Remove(gameObject);
    }
}