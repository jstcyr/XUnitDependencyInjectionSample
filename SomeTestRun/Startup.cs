using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SomeTestRun;
public static class Startup
{
    public static IHostBuilder CreateHostBuilder()
        => Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<SomeTestRunDependency>();
            services.AddHostedService<SomeBackgroundService>();
        });
}
