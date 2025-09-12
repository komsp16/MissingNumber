using MissingNumber.Application;
using MissingNumber.Application.Interfaces;

namespace MissingNumber.Infrastructure.Services;

public class MissingNumberFinderFactory : IMissingNumberFinderFactory
{
    private readonly XorMissingNumberFinder _xorFinder;
    private readonly SumMissingNumberFinder _sumFinder;

    public MissingNumberFinderFactory(
        XorMissingNumberFinder xorFinder,
        SumMissingNumberFinder sumFinder)
    {
        _xorFinder = xorFinder;
        _sumFinder = sumFinder;
    }

    public IMissingNumberFinder Create(MissingNumber.Application.AlgorithmType type) =>
        type switch
        {
            MissingNumber.Application.AlgorithmType.Xor => _xorFinder,
            MissingNumber.Application.AlgorithmType.Sum => _sumFinder,
            _ => _xorFinder
        };
}
