using Serilog;

namespace RaylibSandbox;

internal static class Program
{
    public static void Main()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .MinimumLevel.Warning()
            .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        
        new Game().StartGame();
    }
}