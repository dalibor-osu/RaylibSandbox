using System.Numerics;
using RaylibSandbox.Interfaces;

namespace RaylibSandbox;

public class Scene
{
    public List<IGameObject> Children { get; } = new();
    
    public void Draw()
    {
        Children.Where(x => x is IClickable).ToList().ForEach(x =>
        {
            if (((IClickable)x).IsClicked())
            {
                ((IClickable)x).OnClick();
            }
        });
        
        foreach (var child in Children)
        {
            child.Draw();
        }
    }
    
    public void AddGameObject(IGameObject gameObject)
    {
        gameObject.ParentScene = this;
        Children.Add(gameObject);
    }
}