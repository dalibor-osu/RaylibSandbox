using Serilog;

namespace RaylibSandbox;

internal static class Program
{
    public static void Main()
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Warning()
#endif
            .WriteTo.Console()
            .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        
        new Game().StartGame();
    }
}