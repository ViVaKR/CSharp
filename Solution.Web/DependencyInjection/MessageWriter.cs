namespace DependencyInjection;
public class MessageWriter : IMessageWriter
{
    public void Writer(string message)
    {
        Console.WriteLine($"MessageWriter.Write(message: {message})");
    }
}
