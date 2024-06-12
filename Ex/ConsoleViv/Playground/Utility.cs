using System.Net;

namespace ConsoleViv;

public static class Utility
{
    static readonly HttpClient client = new();

    public static async Task GetExternalIp()
    {
        try
        {
            using HttpResponseMessage response = await client.GetAsync("https://api.ipify.org");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Exception caught.\n{ex.Message}");
        }
    }

}
