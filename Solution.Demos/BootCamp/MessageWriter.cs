namespace BootCamp;

public interface IMessageWriter
{
    void Write(string message);
}

public class MessageWriter :IMessageWriter
{
    public void Write(string message)
    {
        WriteLine($"MessageWriter.Write(message: {message})");
    }
}

public class Worker : BackgroundService
{
    private readonly MessageWriter _writer = new();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _writer.Write($"Worker running at: {DateTimeOffset.Now}");
            await Task.Delay(1000, stoppingToken);
        }
    }
}
