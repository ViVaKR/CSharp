namespace Demo_WebServer;

public class Program
{
    static void Main(string[] args)
    {
        var server = new SimpleWebServer();
        server.Start();
    }
}

