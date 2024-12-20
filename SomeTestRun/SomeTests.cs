using Xunit;

namespace SomeTestRun;

public class SomeTests
{
    private readonly SomeTestRunDependency _dependency;

    public SomeTests(SomeTestRunDependency dependency)
    {
        _dependency = dependency;
    }

    [Fact]
    public async Task SomeTest()
    {
        var result = await _dependency.GetAsync();
        Console.WriteLine(result);
        Assert.Equal("SomeTestRunDependency", result);
    }
}

