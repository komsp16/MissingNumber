using System.Collections.Generic;
using MissingNumber.Application.Interfaces;
using MissingNumber.Domain;

namespace MissingNumber.Infrastructure.Validators;

public class RangeInputValidator : IInputValidator
{
    public void Validate(IReadOnlyList<int> numbers)
    {
        if (numbers == null) return;
        int n = numbers.Count;
        foreach (var num in numbers)
            if (num < 0 || num > n)
                throw new OutOfRangeValueException($"Value {num} is out of range. Expected integers in [0..{n}].");
    }
}
