using RaylibSandbox.Scenes;
using Serilog;

namespace RaylibSandbox;

public class SceneManager
{
    public static SceneManager Instance { get; private set; }

    private string _currentScene = string.Empty;
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
            var currentScene = GetCurrentScene();
            currentScene?.OnSceneUnload();
            
            if (currentScene?.Unload ?? false)
            {
                _scenes.Remove(_currentScene);
            }
            
            _currentScene = name;
            scene.OnSceneLoad();
        }
        else
        {
            Log.Error("Scene \"{name}\" does not exist", name);
        }
    }

    public void LoadScene<T>(string name, T parameter)
    {
        if (_scenes.TryGetValue(name, out var scene))
        {
            var currentScene = GetCurrentScene();
            currentScene?.OnSceneUnload();
            
            if (currentScene?.Unload ?? false)
            {
                _scenes.Remove(_currentScene);
            }
            
            _currentScene = name;
            scene.OnSceneLoad<T>(parameter);
        }
        else
        {
            Log.Error("Scene \"{name}\" does not exist", name);
        }
    }
    
    public void AddAndLoadScene(Scene scene, string name)
    {
        AddScene(scene, name);
        LoadScene(name);
    }
    
    public void AddAndLoadScene<T>(Scene scene, string name, T parameter)
    {
        AddScene(scene, name);
        LoadScene(name, parameter);
    }

    public Scene? GetCurrentScene()
    {
        if (_scenes.TryGetValue(_currentScene, out var scene))
        {
            return scene;
        }

        return null;
    }
}