using System.Numerics;
using RaylibSandbox.GameObjects.Position;
using RaylibSandbox.Interfaces;
using RaylibSandbox.Scenes;

namespace RaylibSandbox.GameObjects;

public abstract class GameObject : IGameObject
{
    public virtual Scene ParentScene { get; set; }
    public virtual Vector2 Position { get; set; }
    public virtual Origin Origin { get; set; } = Origin.TopLeft;
    public virtual bool IsVisible { get; set; }
    public abstract void Draw();
    
    public static void Destroy(IGameObject gameObject)
    {
        gameObject.ParentScene.Children.Remove(gameObject);
    }
}