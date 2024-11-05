using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealTimeApp;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<RealTimeAppContext>();
builder.Services.AddHostedService<Worker>();
builder.Services.AddHostedService<Worker1>();

var host = builder.Build();
host.Run();

