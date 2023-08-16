using System.Net;
using System.Net.NetworkInformation;

namespace Tutor.Snippets;

public class WebHelper
{
    public static readonly HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
    };

    public static readonly HttpClient textOrKr = new()
    {
        BaseAddress = new Uri("http://text.or.kr")
    };

    public static async Task GetAsync(HttpClient httpClient)
    {
        using HttpResponseMessage response = await httpClient.GetAsync("todos/3");

        var result = response.EnsureSuccessStatusCode();

        Console.WriteLine($"\nResponse = {result.StatusCode}");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{jsonResponse}\n");
    }

    public async static Task GetPublicIpaddress(HttpClient httpClient)
    {
        using HttpResponseMessage responseMessage = await textOrKr.GetAsync("api/getuserip");

        var result = responseMessage.EnsureSuccessStatusCode();

        if (result.StatusCode != HttpStatusCode.OK)
        {
            Console.WriteLine($"Status Code : {result.StatusCode}");
            return;
        }

        var response = await responseMessage.Content.ReadAsStringAsync();

        Console.WriteLine($"Publid IP = {response}\n");
        await Task.Delay(50);
    }

    public static Task<bool> CheckInternetConnected(string url)
    {
        return Task.Run(() =>
        {
            try
            {
                var ping = new Ping();
                var buffer = new byte[32];
                const int timeout = 1_000;
                var options = new PingOptions();
                var reply = ping.Send(url, timeout, buffer, options);
                var ttl = reply?.Options?.Ttl;

                /* Default TTL (Destination, 목적지)
                    (1) Linux = 64
                    (2) Windows = 128
                    (3) Cisco = 256
                */
                Console.WriteLine($"ttl = {ttl}");
                return reply?.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        });
    }
}


/* 
HTTP            API
GET	            HttpClient.GetAsync
GET	            HttpClient.GetByteArrayAsync
GET	            HttpClient.GetStreamAsync
GET	            HttpClient.GetStringAsync
POST	        HttpClient.PostAsync
PUT	            HttpClient.PutAsync
PATCH	        HttpClient.PatchAsync
DELETE	        HttpClient.DeleteAsync
USERSPECIFIED	HttpClient.SendAsync

 */
