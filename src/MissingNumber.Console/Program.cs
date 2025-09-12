using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MissingNumber.Infrastructure;
using MissingNumber.ConsoleApp;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddMissingNumberServices();
        services.AddSingleton<ConsoleRunner>();
    })
    .Build();

var runner = host.Services.GetRequiredService<ConsoleRunner>();
var exitCode = await runner.Run(args);
Environment.Exit(exitCode);
