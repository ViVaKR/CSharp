namespace DependencyInjection;
public class Worker : BackgroundService
{
    // private readonly IMessageWriter _writer;
    // public Worker(IMessageWriter writer) => _writer = writer;
    private readonly ILogger<Worker> _logger;

    public Worker (ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // _writer.Writer($"Worker running at: {DateTimeOffset.Now}");
            _logger.LogInformation("Worker running at: ( {day} )", DateTimeOffset.Now);
            await Task.Delay(1_000, stoppingToken);
        }
    }
}
