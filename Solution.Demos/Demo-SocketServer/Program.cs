namespace Demo_SocketServer;
public class Program
{
    public static void Main(String[] args)
    {
        new AsynchronousSocketListener().StartListening();
    }
}
