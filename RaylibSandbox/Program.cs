using System.Diagnostics;
using System.Numerics;
using Raylib_cs;
using Color = Raylib_cs.Color;

namespace RaylibSandbox;

internal static class Program
{
    private const int SCREEN_WIDTH = 800;
    private const int SCREEN_HEIGHT = 480;
    private const int TARGET_FPS = 60;
    
    
    private const int AUDIO_OFFSET = 0;
    private const int AUDIO_BPM = 174;
    private const float BEAT_LENGTH_MILLISECONDS = 60000f / AUDIO_BPM;
    
    private static readonly List<Scene> Scenes = new();
    private static Scene _currentScene;
    
    private static readonly TextGameObject TextGameObject = new ("0", new Vector2(Game.SCREEN_WIDTH / 2f, Game.SCREEN_HEIGHT / 4f));
    
    public static void Main()
    {
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "Hello World");
        Raylib.InitAudioDevice();
        Raylib.SetTargetFPS(TARGET_FPS);
        var music = Raylib.LoadMusicStream("Resources/music.mp3");
        var click = Raylib.LoadSound("Resources/click.mp3");
        var circleScene = new Scene();
        circleScene.AddGameObject(new CircleGameObject(new Vector2(Game.SCREEN_WIDTH / 2f, Game.SCREEN_HEIGHT / 2f)));
        Scenes.Add(circleScene);
        _currentScene = Scenes[0];
        
        float nextBeat = AUDIO_OFFSET;
        bool pause = false;
        
        Raylib.PlayMusicStream(music);
        Game.Time.Start();
        while (!Raylib.WindowShouldClose())
        {
            Raylib.UpdateMusicStream(music);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_P))
            {
                if (pause)
                {
                    Raylib.ResumeMusicStream(music);
                }
                else
                {
                    Raylib.PauseMusicStream(music);
                }
                
                pause = !pause;
            }
            
            var elapsedMilliseconds = Raylib.GetMusicTimePlayed(music) * 1000;
            if (elapsedMilliseconds > nextBeat)
            {
                nextBeat += BEAT_LENGTH_MILLISECONDS;
                UpdateText();
                Raylib.PlaySound(click);
            }
            
            Raylib.DrawText($"{Math.Round(Game.Time.Elapsed.TotalSeconds, 2)}", 10, 0, 20, Color.BLACK);
            Raylib.DrawText($"{Math.Round(elapsedMilliseconds / 1000, 2)}", 10, 30, 20, Color.BLACK);
            
            _currentScene.Draw();
            
            TextGameObject.Draw();

            Raylib.EndDrawing();
        }
        
        Raylib.UnloadMusicStream(music);
        Raylib.UnloadSound(click);
        
        Raylib.CloseAudioDevice();
        
        Raylib.CloseWindow();
    }

    private static void UpdateText()
    {
        int number = int.Parse(TextGameObject.Text) + 1;
        if (number > 4)
        {
            number = 1;
        }
        TextGameObject.SetText(number.ToString());
    }
}