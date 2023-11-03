namespace RaylibSandbox.Interfaces;

public interface IGameObject
{
    public Scene ParentScene { get; set; }
    public void Draw();
}