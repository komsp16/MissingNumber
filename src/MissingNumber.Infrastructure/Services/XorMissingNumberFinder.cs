using System.Collections.Generic;
using MissingNumber.Application.Interfaces;

namespace MissingNumber.Infrastructure.Services;

public class XorMissingNumberFinder : IMissingNumberFinder
{
    public int FindMissing(IReadOnlyList<int> numbers)
    {
        int n = numbers.Count;
        int xor = 0;
        for (int i = 0; i <= n; i++) xor ^= i;
        foreach (var num in numbers) xor ^= num;
        return xor;
    }
}
