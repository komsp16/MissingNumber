using System.Collections.Generic;
using MissingNumber.Application.Interfaces;

namespace MissingNumber.Infrastructure.Validators;

public class CompositeValidationService : IValidationService
{
    private readonly IEnumerable<IInputValidator> _validators;

    public CompositeValidationService(IEnumerable<IInputValidator> validators)
    {
        _validators = validators;
    }

    public void Validate(IReadOnlyList<int> numbers)
    {
        foreach (var v in _validators) v.Validate(numbers);
    }
}
