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
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught.\n{ex.Message}");
        }
    }

    public static async Task Sum()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i} + {i} = {i + i}");
            await Task.Delay(100);
        }
    }

    public static async Task Multiply()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i} * {i} = {i * i}");
            await Task.Delay(100);
        }
    }

    public static async Task Subtract()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i} - {i} = {i - i}");
            await Task.Delay(100);
        }

    }
}
