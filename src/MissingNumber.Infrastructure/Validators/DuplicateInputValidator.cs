using System.Linq;
using System.Collections.Generic;
using MissingNumber.Application.Interfaces;
using MissingNumber.Domain;

namespace MissingNumber.Infrastructure.Validators;

public class DuplicateInputValidator : IInputValidator
{
    public void Validate(IReadOnlyList<int> numbers)
    {
        if (numbers == null) return;
        if (numbers.Count != numbers.Distinct().Count())
            throw new DuplicateValueException("Input contains duplicate values.");
    }
}
