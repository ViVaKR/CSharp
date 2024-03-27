
internal class Program
{
    private static async Task Main(string[] args)
    {
        // (1) 트리거...
        await Task.Run(TenSecondsAsync)
        .ContinueWith(x=> Console.WriteLine("Game Over!!!"));
    }

    private static int maxHealth = 3;

    /// <summary>
    /// (3) 10초 마다 피통 1썩 깎기
    /// </summary>
    /// <returns></returns>
    public static async Task TenSecondsAsync()
    {
        Console.WriteLine($"Max Health => ( {maxHealth} )");
        
        while (maxHealth > 0)
        {
            await Task.Run(() => EverySecondAsync());
            _= Task.Delay(10_000);
            Console.WriteLine($"Current Health => ( {--maxHealth} )");
        }
    }

    /// <summary>
    /// (2) 매초 프린팅해 보기 서비스
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    private static async Task EverySecondAsync(int count = 0)
    {
        while (count < 10)
        {
            await Task.Delay(1_000);
            Console.WriteLine($"{++count} seconds\t{string.Join(string.Empty, Enumerable.Repeat("*", count))}");
        }
    }
}
