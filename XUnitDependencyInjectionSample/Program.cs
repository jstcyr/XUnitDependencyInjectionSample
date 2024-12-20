using System.Reflection;
using Xunit.Runners;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var semaphore = new SemaphoreSlim(0);
        await RunTest(typeof(SomeTestRun.Startup).Assembly);
        await semaphore.WaitAsync();

        Console.WriteLine("All tests done");

        async Task RunTest(Assembly assembly)
        {
            var runner = AssemblyRunner.WithoutAppDomain(assembly.Location);
            runner.OnExecutionComplete = async info =>
            {
                await Task.Delay(10000);
                semaphore.Release();
                Console.WriteLine($"Execution completed for Assembly: {assembly.FullName}");
            };
            runner.Start();

            while (runner.Status != AssemblyRunnerStatus.Idle)
            {
                await Task.Delay(100);
            }

            Console.WriteLine($"Done test run for Assembly: {assembly.FullName}");
            runner.Dispose();
            Console.WriteLine($"Disposed runner for Assembly: {assembly.FullName}");
        }
    }
}