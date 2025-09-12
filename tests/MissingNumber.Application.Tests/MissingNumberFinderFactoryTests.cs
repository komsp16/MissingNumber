using Xunit;
using MissingNumber.Application;
using MissingNumber.Infrastructure.Services;

namespace MissingNumber.Application.Tests;

public class MissingNumberFinderFactoryTests
{
    [Fact]
    public void CreatesXorFinder()
    {
        var factory = new MissingNumberFinderFactory(new XorMissingNumberFinder(), new SumMissingNumberFinder());
        var finder = factory.Create(MissingNumber.Application.AlgorithmType.Xor);

        var result = finder.FindMissing(new[] { 3, 0, 1 });
        Assert.Equal(2, result);
    }

    [Fact]
    public void CreatesSumFinder()
    {
        var factory = new MissingNumberFinderFactory(new XorMissingNumberFinder(), new SumMissingNumberFinder());
        var finder = factory.Create(MissingNumber.Application.AlgorithmType.Sum);

        var result = finder.FindMissing(new[] { 3, 0, 1 });
        Assert.Equal(2, result);
    }
}
