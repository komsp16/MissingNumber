using Xunit;
using MissingNumber.Infrastructure.Validators;
using MissingNumber.Domain;

namespace MissingNumber.Application.Tests;

public class RangeInputValidatorTests
{
    [Fact]
    public void Passes_WhenValuesInRange()
    {
        var validator = new RangeInputValidator();
        var numbers = new[] { 3, 0, 1 };
        validator.Validate(numbers);
    }

    [Fact]
    public void Throws_WhenValueTooLarge()
    {
        var validator = new RangeInputValidator();
        var numbers = new[] { 5, 0, 1 };
        Assert.Throws<OutOfRangeValueException>(() => validator.Validate(numbers));
    }

    [Fact]
    public void Throws_WhenValueNegative()
    {
        var validator = new RangeInputValidator();
        var numbers = new[] { -1, 0, 1 };
        Assert.Throws<OutOfRangeValueException>(() => validator.Validate(numbers));
    }
}
