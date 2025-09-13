using System;
using System.Threading.Tasks;
using MissingNumber.Application;
using MissingNumber.Application.Interfaces;

namespace MissingNumber.ConsoleApp;

public class ConsoleRunner
{
    private readonly IInputParser _parser;
    private readonly IValidationService _validator;
    private readonly IMissingNumberFinderFactory _factory;

    public ConsoleRunner(IInputParser parser, IValidationService validator, IMissingNumberFinderFactory factory)
    {
        _parser = parser;
        _validator = validator;
        _factory = factory;
    }

    public Task<int> Run(string[] args)
    {
        try
        {
            string input;
            AlgorithmType algorithm = AlgorithmType.Xor; // default

            if (args != null && args.Length > 0)
            {
                input = args[0];
                if (args.Length > 1 && Enum.TryParse<AlgorithmType>(args[1], true, out var parsedAlgo))
                {
                    algorithm = parsedAlgo;
                }
            }
            else
            {
                input = PromptForInput();
                //algorithm = PromptForAlgorithm(); // Uncomment if you want to prompt for algorithm - KISS
            }

            var numbers = _parser.Parse(input);
            _validator.Validate(numbers);
            Console.WriteLine($"Input: [{string.Join(", ", numbers)}]");

            var finder = _factory.Create(algorithm);
            var missing = finder.FindMissing(numbers);

            //Console.WriteLine($"Algorithm: {algorithm}"); // Uncomment if you want to display the algorithm used - KISS
            Console.WriteLine($"Output: {missing}");
   

            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return Task.FromResult(1);
        }
    }

    private static string PromptForInput()
    {
        Console.WriteLine("Enter numbers (comma/space separated) in a range from 0 to n. Example: '3,0,1'");
        return Console.ReadLine() ?? string.Empty;
    }

    private static AlgorithmType PromptForAlgorithm()
    {
        Console.WriteLine("Choose algorithm (Xor / Sum). Default: Xor");
        var input = Console.ReadLine();
        return Enum.TryParse<AlgorithmType>(input, true, out var algo) ? algo : AlgorithmType.Xor;
    }
}
