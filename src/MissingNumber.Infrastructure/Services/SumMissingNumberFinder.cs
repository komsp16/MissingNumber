using System.Collections.Generic;
using MissingNumber.Application.Interfaces;

namespace MissingNumber.Infrastructure.Services;

public class SumMissingNumberFinder : IMissingNumberFinder
{
    public int FindMissing(IReadOnlyList<int> numbers)
    {
        int n = numbers.Count;
        long expected = (long)n * (n + 1) / 2;
        long actual = 0;
        foreach (var num in numbers) actual += num;
        return (int)(expected - actual);
    }
}
