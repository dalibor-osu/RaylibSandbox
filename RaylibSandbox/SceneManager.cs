using RaylibSandbox.Scenes;
using Serilog;

namespace RaylibSandbox;

public class SceneManager
{
    public static SceneManager Instance { get; private set; }
    
    public Scene CurrentScene { get; private set; }
    private readonly Dictionary<string, Scene> _scenes = new();
    
    public SceneManager()
    {
        Instance = this;
    }
    
    public void AddScene(Scene scene, string name)
    {
        _scenes.Add(name, scene);
    }
    
    public void RemoveScene(string name)
    {
        _scenes.Remove(name);
    }
    
    public void OnWindowResize()
    {
        foreach (var scene in _scenes.Values)
        {
            scene.OnWindowResize();
        }
    }
    
    public void LoadScene(string name)
    {
        if (_scenes.TryGetValue(name, out var scene))
        {
            CurrentScene = scene;
        }
        else
        {
            Log.Error("Scene \"{name}\" does not exist", name);
        }
    }
}