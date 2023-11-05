using System.Numerics;
using Raylib_cs;
using RaylibSandbox.Scenes;
using Serilog;

namespace RaylibSandbox;

public class Game
{
    private const int DEFAULT_SCREEN_WIDTH = 800;
    private const int DEFAULT_SCREEN_HEIGHT = 480;
    private const int TARGET_FPS = 120;
    private const string GAME_TITLE = "Raylib Sandbox";
    
    public static int WindowWidth { get; private set; }
    public static int WindowHeight { get; private set; }
    
    private readonly SceneManager _sceneManager = new();
    
    private static bool _exit;

    public void StartGame()
    {
        Initialize();
        RunMainGameLoop();
        Close();
    }

    private void RunMainGameLoop()
    {
        while (!Raylib.WindowShouldClose() && !_exit)
        {
            if (Raylib.IsWindowResized())
            {
                WindowHeight = Raylib.GetScreenHeight();
                WindowWidth = Raylib.GetScreenWidth();
                SceneManager.Instance.OnWindowResize();
            }
            
            Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.RAYWHITE);
                
                var currentScene = _sceneManager.GetCurrentScene();
                if (currentScene != null)
                {
                    currentScene.Draw();
                }
                else
                {
                    Log.Error("Current scene is null");
                    throw new Exception("Scene is not set!");
                }
                
            Raylib.EndDrawing();
        }
    }
    
    private void Initialize()
    {
#if DEBUG
        Raylib.SetTraceLogLevel(TraceLogLevel.LOG_ALL);
#else
        Raylib.SetTraceLogLevel(TraceLogLevel.LOG_WARNING);
#endif
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(DEFAULT_SCREEN_WIDTH, DEFAULT_SCREEN_HEIGHT, GAME_TITLE);
        Raylib.SetExitKey(KeyboardKey.KEY_INSERT);
        Raylib.InitAudioDevice();
        Raylib.SetTargetFPS(TARGET_FPS);
        
        int currentMonitor = Raylib.GetCurrentMonitor();
        
        int monitorHeight = Raylib.GetMonitorHeight(currentMonitor);
        int monitorWidth = Raylib.GetMonitorWidth(currentMonitor);
        
        WindowHeight = (int)(Raylib.GetMonitorHeight(currentMonitor) * 0.8f);
        WindowWidth = (int)(Raylib.GetMonitorWidth(currentMonitor) * 0.8f);
        
        Log.Debug("Window size: {Width}x{Height}", WindowWidth, WindowHeight);

        Raylib.SetWindowSize(WindowWidth, WindowHeight);
        Raylib.SetWindowPosition(monitorWidth / 2 - WindowWidth / 2, monitorHeight / 2 - WindowHeight / 2);
        
        _sceneManager.AddScene(new MainMenu(), "mainMenu");
        _sceneManager.AddScene(new SampleMenu(), "sample");
        _sceneManager.AddScene(new SongSelection("Assets"), "songSelection");
        _sceneManager.LoadScene("mainMenu");
    }
    
    private void Close()
    {
        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }
    
    public static Vector2 GetWindowCentre()
    {
        return new Vector2(WindowWidth / 2f, WindowHeight / 2f);
    }

    public static void Exit()
    {
        _exit = true;
    }
}