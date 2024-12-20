using Microsoft.Extensions.Hosting;

namespace SomeTestRun;
internal class SomeBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("SomeBackgroundService started");
        await Task.Delay(5000, stoppingToken);
        Console.WriteLine("SomeBackgroundService stopped");
    }
}
