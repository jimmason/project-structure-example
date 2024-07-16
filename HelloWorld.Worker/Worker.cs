using HelloWorld.Core;

namespace HelloWorld.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var someDomainLogic = new SomeDomainLogic();
        var helloWorld = someDomainLogic.SayHello();
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(helloWorld);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}