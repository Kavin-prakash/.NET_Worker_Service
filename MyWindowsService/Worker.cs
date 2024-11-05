namespace MyWindowsService;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly int _intervalInMinutes;


    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        _intervalInMinutes = 1; // Time Interval
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            WriteLog();
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //This method returns task - represent the asynchronous start operation
            await Task.Delay(TimeSpan.FromMinutes(_intervalInMinutes), stoppingToken);
        }
    }

    private void WriteLog()
    {
        string logFilePath = "D:\\Logs\\logs.txt"; // Ensure this path exists or create it
        string logMessage = $"Log entry at {DateTime.Now}\n";
        File.AppendAllText(logFilePath, logMessage);
    }
}

