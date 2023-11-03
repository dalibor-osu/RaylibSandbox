using System.Diagnostics;

namespace RaylibSandbox;

public class GameTime
{
    private readonly Stopwatch _stopwatch = new();
    public TimeSpan Elapsed => _stopwatch.Elapsed;
    
    public void Start()
    {
        if (_stopwatch.IsRunning)
        {
            throw new Exception("GameTime is already running!");
        }
        _stopwatch.Start();
    }
}