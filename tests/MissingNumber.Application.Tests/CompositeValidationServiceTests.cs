using Xunit;
using MissingNumber.Infrastructure.Validators;
using MissingNumber.Application.Interfaces;
using MissingNumber.Domain;
using System.Collections.Generic;

namespace MissingNumber.Application.Tests;

public class CompositeValidationServiceTests
{
    [Fact]
    public void RunsAllValidators_WhenValid()
    {
        var v1 = new AlwaysPassValidator();
        var v2 = new AlwaysPassValidator();
        var service = new CompositeValidationService(new IInputValidator[] { v1, v2 });

        service.Validate(new List<int> { 0, 1, 2 });
    }

    [Fact]
    public void Throws_WhenOneValidatorFails()
    {
        var v1 = new AlwaysPassValidator();
        var v2 = new AlwaysFailValidator();
        var service = new CompositeValidationService(new IInputValidator[] { v1, v2 });

        Assert.Throws<InvalidInputException>(() => service.Validate(new List<int> { 0, 1 }));
    }

    private class AlwaysPassValidator : IInputValidator
    {
        public void Validate(IReadOnlyList<int> numbers) { }
    }

    private class AlwaysFailValidator : IInputValidator
    {
        public void Validate(IReadOnlyList<int> numbers)
            => throw new InvalidInputException("Validation failed.");
    }
}
