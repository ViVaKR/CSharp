using Helper;
Console.Write("메뉴선택 >> ");
Console.WriteLine("1. Money");
Console.WriteLine("2. UDP");
Console.WriteLine("3. Ping");

int choice;
bool check = int.TryParse(Console.ReadLine(), out choice);

if (!check)
{
    Console.WriteLine("잘못된 선택입니다. ");
    return;
}
Console.Clear();

switch (choice)
{
    case 1:
        {
            Console.WriteLine(30_000_000.34M.ToDollar());
            Console.WriteLine(30000000L.ToWon());
        }
        break;

    case 2:
        {
            Nets nets = new Nets();
            var task = new Task(() => nets.StartUDPServer());
            task.Start();
            // UDP 접속하기
            nets.UdpClient();
            nets.StopAll();
        }
        break;
    case 3:
        {
            await Task.Run(() =>
            {
                string subnet = "172.30.1";
                Console.WriteLine("***** 핑테스트를 시작합니다. *****");
                for (int i = 250; i < 257; i++) // 없는 아이피 포함
                {
                    var ip = $"{subnet}.{i}";
                    ip.Ping();
                }

                var google = $"8.8.8.8";
                google.Ping();

                var dm = "164.124.101.1";
                dm.Ping();

                
            });
        }
        break;

    default: return;
}

