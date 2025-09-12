using Microsoft.Extensions.DependencyInjection;
using MissingNumber.Application.Interfaces;
using MissingNumber.Infrastructure.Services;
using MissingNumber.Infrastructure.Validators;

namespace MissingNumber.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMissingNumberServices(this IServiceCollection services)
    {
        services.AddSingleton<XorMissingNumberFinder>();
        services.AddSingleton<SumMissingNumberFinder>();
        services.AddSingleton<IMissingNumberFinderFactory, MissingNumberFinderFactory>();

        services.AddSingleton<IMissingNumberFinder>(sp => sp.GetRequiredService<XorMissingNumberFinder>());

        services.AddSingleton<IInputParser, CommaSeparatedInputParser>();

        services.AddSingleton<IInputValidator, DuplicateInputValidator>();
        services.AddSingleton<IInputValidator, RangeInputValidator>();

        services.AddSingleton<IValidationService, CompositeValidationService>();

        return services;
    }
}
