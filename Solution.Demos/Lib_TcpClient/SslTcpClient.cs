using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lib_TcpListener;

public class SslTcpClient
{
    private static X509Certificate2? clientCert;

    public static void RunClient(string serverName, string password, string cert)
    {
        clientCert = new X509Certificate2(cert, password);
        var client = new TcpClient("127.0.0.1", 7755);
        var stream
        = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
        stream.AuthenticateAsClient(serverName, new X509CertificateCollection(new X509Certificate[] { clientCert }), SslProtocols.Tls12, false);
        var message = "Hello, server!";
        var messageBytes = Encoding.UTF8.GetBytes(message);
        stream.Write(messageBytes, 0, messageBytes.Length);
        var buffer = new byte[2048];
        var bytesRead = stream.Read(buffer, 0, buffer.Length);
        var response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Received response: " + response);
        client.Close();
    }

    private static bool ValidateServerCertificate(object? sender, X509Certificate? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
}
