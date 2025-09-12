using Xunit;
using MissingNumber.Infrastructure.Validators;
using MissingNumber.Domain;

namespace MissingNumber.Application.Tests;

public class DuplicateInputValidatorTests
{
    [Fact]
    public void Passes_WhenNoDuplicates()
    {
        var validator = new DuplicateInputValidator();
        var numbers = new[] { 3, 0, 1 };
        validator.Validate(numbers);
    }

    [Fact]
    public void Throws_WhenDuplicatesExist()
    {
        var validator = new DuplicateInputValidator();
        var numbers = new[] { 1, 2, 2 };
        Assert.Throws<DuplicateValueException>(() => validator.Validate(numbers));
    }
}
