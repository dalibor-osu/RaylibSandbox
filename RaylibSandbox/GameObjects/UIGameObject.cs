using RaylibSandbox.Interfaces;

namespace RaylibSandbox.GameObjects;

public abstract class UIGameObject<T> : GameObject, IUIGameObject where T : GameObject
{
    public Action<T> OnWindowResizeAction { get; set; } = _ => { };
    public abstract override void Draw();
    public abstract void OnWindowResize();
}