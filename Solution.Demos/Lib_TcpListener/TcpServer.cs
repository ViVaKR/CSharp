using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Lib_TcpListener;
public class TcpServer
{
    private TcpListener server;
    public TcpServer()
    {
        server = new TcpListener(IPAddress.Loopback, 13000);
    }

    public void Start()
    {
        try
        {
            server.Start();
            Byte[] bytes = new Byte[1_024];
            string? data;

            while (true)
            {
                Console.Write("접속 대기중... ");
                using TcpClient client = server.AcceptTcpClient();
                Console.WriteLine($"연결완료 : {client.Client.RemoteEndPoint}");

                data = null;
                var stream = client.GetStream();
                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine($"수신 : {data}");
                    data = data.ToUpper();
                    byte[] msg = System.Text.Encoding.UTF8.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"송신 : {data}");
                }
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            server.Stop();
        }

        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }
}
