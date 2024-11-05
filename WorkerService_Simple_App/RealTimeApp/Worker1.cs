
using RealTimeApp;
using RealTimeApp.Models;

public class Worker1 : BackgroundService
{
    private readonly ILogger<Worker1> _logger;

    private readonly RealTimeAppContext _realTimeAppContext;

    public Worker1(ILogger<Worker1> logger, RealTimeAppContext appContext)
    {
        _logger = logger;
        _realTimeAppContext = appContext;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Database Operation is Handled :");
                PerformPostOperation();
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.ToString());
        }
    }


    private void PerformPostOperation()
    {
        var product = new Products()
        {
            Name = "Lenovo",
            Price = 25.5m,
            CreatedDate = DateTime.Now,
        };

        _realTimeAppContext.Add(product);
        _realTimeAppContext.SaveChanges();
    }

    // private void ListOfProducts()
    // {

    //     var getallproducts = _realTimeAppContext.Products.ToList();

    //     _logger.LogInformation($"Totaly = {getallproducts.Count} products");
    // }
}