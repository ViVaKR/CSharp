using System.Text;
using System.Net.Sockets;
using System.Net;
namespace Lib_TcpClient;
public class TcpClients
{
    public void Connect(string message)
    {
        try
        {
            using TcpClient client = new TcpClient("127.0.0.1", 13000);
            var data = System.Text.Encoding.UTF8.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            Console.WriteLine($"Sent: {message}");
            data = new Byte[1_024];
            var responseData = string.Empty;
            var bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
            Console.WriteLine($"Received: {responseData}");
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine($"ArgumentNullException: {e}");
        }
        catch (SocketException e)
        {
            Console.WriteLine($"SocketException: {e}");
        }

        Console.WriteLine("\n Press Enter to continue...");
        Console.Read();
    }
}
