using Xunit;
using MissingNumber.Infrastructure.Services;
using MissingNumber.Infrastructure.Validators;
using MissingNumber.Application.Interfaces;
using MissingNumber.Application;
using MissingNumber.Domain;

namespace MissingNumber.Application.Tests;

public class IntegrationPipelineTests
{
    private readonly IInputParser _parser;
    private readonly IValidationService _validator;
    private readonly IMissingNumberFinderFactory _factory;

    public IntegrationPipelineTests()
    {
        _parser = new CommaSeparatedInputParser();
        var validators = new IInputValidator[]
        {
            new DuplicateInputValidator(),
            new RangeInputValidator()
        };
        _validator = new CompositeValidationService(validators);

        _factory = new MissingNumberFinderFactory(
            new XorMissingNumberFinder(),
            new SumMissingNumberFinder()
        );
    }

    [Theory]
    [InlineData("3,0,1", 2)]
    [InlineData("0,1,2", 3)]
    [InlineData("1,2,3", 0)]
    public void FullPipeline_FindsMissingNumber_WithBothAlgorithms(string input, int expectedMissing)
    {
        var numbers = _parser.Parse(input);
        _validator.Validate(numbers);

        var xorFinder = _factory.Create(MissingNumber.Application.AlgorithmType.Xor);
        Assert.Equal(expectedMissing, xorFinder.FindMissing(numbers));

        var sumFinder = _factory.Create(MissingNumber.Application.AlgorithmType.Sum);
        Assert.Equal(expectedMissing, sumFinder.FindMissing(numbers));
    }

    [Fact]
    public void FullPipeline_ThrowsForDuplicate()
    {
        string input = "1,2,2";
        var numbers = _parser.Parse(input);
        Assert.Throws<MissingNumber.Domain.DuplicateValueException>(() => _validator.Validate(numbers));
    }

    [Fact]
    public void FullPipeline_ThrowsForOutOfRange()
    {
        string input = "5,0,1";
        var numbers = _parser.Parse(input);
        Assert.Throws<MissingNumber.Domain.OutOfRangeValueException>(() => _validator.Validate(numbers));
    }

    [Fact]
    public void FullPipeline_ThrowsForInvalidToken()
    {
        string input = "3,a,1";
        Assert.Throws<MissingNumber.Domain.InvalidInputException>(() => _parser.Parse(input));
    }
}
