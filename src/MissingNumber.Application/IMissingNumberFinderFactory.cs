using MissingNumber.Application.Interfaces;

namespace MissingNumber.Application.Interfaces;

public interface IMissingNumberFinderFactory
{
    IMissingNumberFinder Create(MissingNumber.Application.AlgorithmType type);
}
