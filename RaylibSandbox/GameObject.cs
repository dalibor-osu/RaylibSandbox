using System.Numerics;
using RaylibSandbox.Interfaces;

namespace RaylibSandbox;

public abstract class GameObject : IGameObject
{
    public Scene ParentScene { get; set; }
    public Vector2 Position { get; set; }
    public abstract void Draw();
    
    public static void Destroy(IGameObject gameObject)
    {
        gameObject.ParentScene.Children.Remove(gameObject);
    }
}