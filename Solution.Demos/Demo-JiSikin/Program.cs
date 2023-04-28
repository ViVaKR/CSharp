using Helper;
Console.Write("메뉴선택 >> ");
Console.WriteLine("1. Money");
Console.WriteLine("2. UDP");

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

    default: return;
}

