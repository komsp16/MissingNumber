using Xunit;
using MissingNumber.Infrastructure.Services;
using MissingNumber.Domain;

namespace MissingNumber.Application.Tests;

public class CommaSeparatedInputParserTests
{
    [Fact]
    public void Parses_CommaSeparatedValues()
    {
        var parser = new CommaSeparatedInputParser();
        var result = parser.Parse("3,0,1");
        Assert.Equal(new[] { 3, 0, 1 }, result);
    }

    [Fact]
    public void Parses_SpaceSeparatedValues()
    {
        var parser = new CommaSeparatedInputParser();
        var result = parser.Parse("4 2 1");
        Assert.Equal(new[] { 4, 2, 1 }, result);
    }

    [Fact]
    public void ReturnsEmptyList_WhenInputEmpty()
    {
        var parser = new CommaSeparatedInputParser();
        var result = parser.Parse("") ;
        Assert.Empty(result);
    }

    [Fact]
    public void ThrowsInvalidInputException_ForNonInteger()
    {
        var parser = new CommaSeparatedInputParser();
        Assert.Throws<InvalidInputException>(() => parser.Parse("3,a,1"));
    }
}
