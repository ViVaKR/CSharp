

namespace DependencyInjection;
public class LoggingMessageWriter : IMessageWriter
{
    private readonly ILogger<LoggingMessageWriter> _logger;

    public LoggingMessageWriter (ILogger<LoggingMessageWriter> logger)
    {
        _logger = logger;
    }

    public void Writer(string message)
    {
        _logger.LogInformation("Info: {Msg}", message);
    }
}
