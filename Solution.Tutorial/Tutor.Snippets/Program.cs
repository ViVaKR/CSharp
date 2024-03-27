using Tutor.Snippets;

var menus = new Dictionary<int, string>
{
    { 1, "SpacialChar" },
    { 2, "HttpClient Json Demo" },
    { 3, "Get Public IP" },
    { 4, "Ping Test" },
    { 100, "종료 (Q)" },
};

ConsoleKeyInfo? cki = default(ConsoleKeyInfo);
do
{
    foreach (var item in menus)
    {
        Console.WriteLine($"{item.Key}. {item.Value}");
    }

    Console.Write("메뉴 선택 => ");
    cki = Console.ReadKey();

    if (cki == null) break;

    await RunAsync(Convert.ToChar(cki?.Key)).ContinueWith(x =>
    {
        Console.WriteLine("=====================");
    });

} while (cki?.Key != ConsoleKey.Q);

Console.WriteLine("코드 조각 테스트 종료...");

static async Task RunAsync(char menu)
{
    Console.WriteLine();
    switch (menu)
    {
        case '1':
            {
                Console.Write("변환할 유니코드 => ");
                var code = Console.ReadLine();
                code?.ToString().ToSpacialChar();

            }; break;
        case '2':
            {
                await Task.Run(() => WebHelper.GetAsync(WebHelper.sharedClient));

            }; break;

        case '3':
            {
                await Task.Run(() => WebHelper.GetPublicIpaddress(WebHelper.textOrKr));

            }; break;

        case '4':
            {
                Console.Write("Ping Test IP: ");
                var input = Console.ReadLine();
                var rs = await Task.Run(() => WebHelper.CheckInternetConnected(input?.ToString() ?? "164.124.101.2"));

                Console.WriteLine($"Check = {rs}");

            }; break;

            // using (var collection = new InstalledFontCollection())
    }
}
