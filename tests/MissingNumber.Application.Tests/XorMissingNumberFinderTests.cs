using Xunit;
using MissingNumber.Infrastructure.Services;
using System.Collections.Generic;

namespace MissingNumber.Application.Tests;

public class XorMissingNumberFinderTests
{
    [Fact]
    public void FindsMissingNumber()
    {
        var sut = new XorMissingNumberFinder();
        var numbers = new List<int> { 3, 0, 1 };
        var missing = sut.FindMissing(numbers);
        Assert.Equal(2, missing);
    }
}
