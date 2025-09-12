using System;
using System.Linq;
using System.Collections.Generic;
using MissingNumber.Application.Interfaces;
using MissingNumber.Domain;

namespace MissingNumber.Infrastructure.Services;

public class CommaSeparatedInputParser : IInputParser
{
    public IReadOnlyList<int> Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return Array.Empty<int>();

        var tokens = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var list = tokens.Select(t =>
        {
            if (!int.TryParse(t, out var v))
                throw new InvalidInputException($"Invalid integer token: '{t}'");
            return v;
        }).ToList();

        return list;
    }
}
