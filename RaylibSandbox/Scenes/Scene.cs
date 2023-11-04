using Raylib_cs;
using RaylibSandbox.Interfaces;

namespace RaylibSandbox.Scenes;

public abstract class Scene
{
    public List<IGameObject> Children { get; } = new();
    
    public void Draw()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            Children.Where(x => x is IClickable).ToList().ForEach(x =>
            {
                if (((IClickable)x).IsClicked())
                {
                    ((IClickable)x).OnClick();
                }
            });
        }
        
        foreach (var child in Children)
        {
            child.Draw();
        }
    }
    
    public void OnWindowResize()
    {
        foreach (var child in Children)
        {
            if (child is IUIGameObject windowResizeable)
            {
                windowResizeable.OnWindowResize();
            }
        }
    }
    
    public void AddGameObject(IGameObject gameObject)
    {
        gameObject.ParentScene = this;
        Children.Add(gameObject);
    }
    
    public void AddGameObjects(params IGameObject[] gameObjects)
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.ParentScene = this;
            AddGameObject(gameObject);
        }
    }
}