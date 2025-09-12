using System.Collections.Generic;

namespace MissingNumber.Application.Interfaces;

public interface IMissingNumberFinder
{
    int FindMissing(IReadOnlyList<int> numbers);
}

public interface IInputParser
{
    IReadOnlyList<int> Parse(string input);
}

public interface IInputValidator
{
    void Validate(IReadOnlyList<int> numbers);
}

public interface IValidationService
{
    void Validate(IReadOnlyList<int> numbers);
}
