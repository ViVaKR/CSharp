using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lib_TcpClient;
public class SslTcpServer
{
    private static X509Certificate2? serverCert;

    public static void RunServer(string cert, string password)
    {
        serverCert = new X509Certificate2(cert, password);
        var endpoint = new IPEndPoint(IPAddress.Any, 7755);
        var listener = new TcpListener(endpoint);
        listener.Start();
        Console.WriteLine("Server started.");
        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected......");
            var stream = new SslStream(client.GetStream(), false);
            stream.AuthenticateAsServer(serverCert, false, SslProtocols.Tls12, true);
            var buffer = new byte[2048];
            var bytesRead = stream.Read(buffer, 0, buffer.Length);
            var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received message: " + message);
            var responseMessage = $"( {DateTime.Now} ) - Server response";
            var responseBytes = Encoding.UTF8.GetBytes(responseMessage);
            stream.Write(responseBytes, 0, responseBytes.Length);
        }
    }

    public static void CheckCert()
    {
        SslTcpServer.RunServer("./localhost.pfx", "123456");

        var certificate = new X509Certificate("./localhost.pfx", "123456");
        Console.WriteLine(certificate.GetPublicKeyString());

        X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
        store.Open(OpenFlags.ReadOnly);
        var certificates = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, "CN=localhost", false);
        store.Close();

        if (certificates.Count == 0)
        {
            Console.WriteLine("Server certificate not found...");
            return;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine();
            var cert = certificates[0];
            Console.WriteLine(cert.GetPublicKeyString());
        }
        Console.WriteLine();
        Console.WriteLine();
        X509Certificate2 c = new X509Certificate2("./localhost.pfx", "123456");
        Console.WriteLine(c.GetPublicKeyString());

    }
}

