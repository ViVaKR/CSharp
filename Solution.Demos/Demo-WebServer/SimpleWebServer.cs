using System.Net;
using System.Text;

namespace Demo_WebServer;

public class SimpleWebServer
{
    private const int PORT = 12345;
    
    private HttpListener listener = new HttpListener();
    
    public void Start()
    {
        listener.Prefixes.Add($@"http://*:{PORT}/");

        listener.Start();

        Console.WriteLine($@"Listening on port {PORT}..");

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest req = context.Request;
            
            Console.WriteLine($"Received request for {req.RemoteEndPoint.Address}, {req.Url}");

            using HttpListenerResponse resp = context.Response;
            resp.Headers.Set("Content-Type", "text/plain");

            var respData = $"{RespData(req)}";
            
            var buffer = Encoding.UTF8.GetBytes(respData);
            resp.ContentLength64 = buffer.Length;

            using Stream stream = resp.OutputStream;
            stream.Write(buffer, 0, buffer.Length);
        }
    }
    
    // Return Remote Endpoint
    public static string RespData(HttpListenerRequest request)
    {
        var address = request.RemoteEndPoint.Address;
        var port = request.RemoteEndPoint.Port;
        return $"{address}, {port}";
    }
}

