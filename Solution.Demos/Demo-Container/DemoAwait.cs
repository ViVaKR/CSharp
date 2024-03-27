namespace Demo_Container;
public class DemoAwait
{
    private async Task DownloadDocsAsync()
    {

        Console.WriteLine($"{nameof(DownloadDocsAsync)} : About to start downloading.");

        var client = new HttpClient();
        byte[] content = await client.GetByteArrayAsync("https://learn.microsoft.com/en-US");
        Console.WriteLine($"Finished downloading. {content.Length}");
    }
}
