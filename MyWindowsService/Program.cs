using MyWindowsService;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

// Register service instance for dependency injection
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
