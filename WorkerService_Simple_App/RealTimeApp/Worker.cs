using RealTimeApp.Models;
using System.IO;
namespace RealTimeApp;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    private readonly RealTimeAppContext _realTimeAppContext;

    public Worker(ILogger<Worker> logger, RealTimeAppContext realTimeAppContext)
    {
        _logger = logger;
        _realTimeAppContext = realTimeAppContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                // _logger.LogInformation("Manipulation Operation is started :");
                // PerformPostOperation();
                // ListOfProducts();
                MonitorDatabaseLogs();
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            _logger.LogInformation("Manipulation Operation is Stoped :");

        }
    }

    private void MonitorDatabaseLogs()
    {
        // Using System.Io namespace

        string filePath = "D:\\Logs\\RealTimeApp(DatabaseLogs).txt";

        string logMessage = $" Productdbwindowservice Database Log entry at {DateTime.Now}\n";

        File.AppendAllText(filePath, logMessage);

    }



    // private void PerformPostOperation()
    // {
    //     var product = new Products()
    //     {
    //         Name = "Lenovo",
    //         Price = 25.5m,
    //         CreatedDate = DateTime.Now,
    //     };

    //     _realTimeAppContext.Add(product);
    //     _realTimeAppContext.SaveChanges();
    // }

    // private void ListOfProducts()
    // {

    //     var getallproducts = _realTimeAppContext.Products.ToList();

    //     _logger.LogInformation($"Totaly = {getallproducts.Count} products");
    // }
}
