namespace SomeTestRun;
public class SomeTestRunDependency
{
    public async Task<string> GetAsync()
    {
        await Task.Delay(1000);
        return "SomeTestRunDependency";
    }
}
