namespace Helper;
using static System.Console;
public class Games
{
    /// <summary>
    /// 야구게임
    /// </summary>
    public void Game011()
    {
        bool isStart = false;
        int strike = 0, ball = 0;
        int round = 0;
        const int lastRound = 2;
        Random r = new Random(Guid.NewGuid().GetHashCode());

        while (true)
        {
            int com1, com2, com3;
            while (true)
            {
                com1 = r.Next(1, 10);
                com2 = r.Next(1, 10);
                com3 = r.Next(1, 10);

                if (com1 == com2 || com1 == com3 || com2 == com3) continue;
                break;
            }
            WriteLine($@"컴퓨터 정답 ({round + 1})회 => {com1}, {com2}, {com3}");
            WriteLine();
            WriteLine($@"라운드 ({round + 1})");

            #region 1번째 숫자
            int input_1;
            while (true)
            {
                Write("첫 번째 숫자를 입력해주세요!(1~9) => ");
                if (int.TryParse(ReadLine(), out input_1))
                {
                    if (input_1 > 9 || input_1 < 1)
                    {
                        WriteLine();
                        WriteLine("범위를 벗어났습니다");
                        continue;
                    }

                    if (com1 == input_1)
                    {
                        strike += 1;
                        break;
                    }
                    if (com2 == input_1 || com3 == input_1) ball += 1;
                }
                else
                {
                    WriteLine("숫자가 아닙니다");
                }
                break;
            }
            #endregion
            #region 2번째 숫자
            int input_2;
            while (true) // 두번째 숫자 입력 
            {
                Write("두번째 숫자를 입력해주세요!(1~9) => ");
                if (int.TryParse(ReadLine(), out input_2))
                {
                    if (input_2 > 9 || input_2 < 1)
                    {
                        WriteLine();
                        WriteLine("범위를 벗어났습니다. 다시 입력해주세요");
                        continue;
                    }

                    if (com2 == input_2)
                    {
                        strike += 1;
                        break;
                    }

                    if (com1 == input_2 || com3 == input_2) ball += 1;
                }
                else
                {
                    WriteLine("숫자가 아닙니다");
                }
                break;
            }
            #endregion 2 번째숫자
            #region 3번째 숫자
            int input_3;
            while (true)
            {
                Write("세번째 숫자 (1~9) => ");
                if (int.TryParse(ReadLine(), out input_3))
                {
                    if (input_3 > 9 || input_3 < 1)
                    {
                        WriteLine();
                        WriteLine("범위를 벗어났습니다");
                        continue;
                    }
                    if (com3 == input_3)
                    {
                        strike += 1;
                        break;
                    }
                    if (com1 == input_3 || com2 == input_3) ball += 1;
                }
                else
                {
                    WriteLine("숫자가 아닙니다");
                    continue;
                }
                WriteLine($@"Strike : {strike}, Ball: {ball}");
                break;
            }
            #endregion
            if (strike == 3)
            {
                isStart = true;
                round = 0;
                WriteLine("★★You Win~~~!★★");
                ReadKey();
            }
            if (round++ == lastRound)
            {
                WriteLine($"({round}) 패배하셨습니다");
                isStart = true;
                round = 0;
                WriteLine();
                ReadKey();
            }
            if (isStart)
            {
                WriteLine(@"재도전 하시겠습니까? Yes(Y) / No(N)");
                var intention = ReadLine();
                switch (intention)
                {
                    case string n when n.ToLower().Equals("yes") || n.ToLower().Equals("y"):
                        round = 0;
                        isStart = false;
                        break;

                    case string n when !n.ToLower().Equals("no") || !n.ToLower().Equals("n"):
                        {
                            WriteLine(@"게임을 종료합니다!");
                            ReadKey();
                            return;
                        }
                }
            }
            strike = 0;
            ball = 0;
        }
    }
    public void Game015()
    {
        // 캐쉬 아이템
        Inven<Cashitem> cash = new Inven<Cashitem>();
        for (int i = 0; i < cash.Titem.Length; i++)
        {
            Cashitem item = new Cashitem { Gold = 1000 + 100 * i, Name = "Cash_" + i };
            cash.Titem[i] = item;
        }
        cash.Func();

        Console.WriteLine();

        // 레어 아이템
        Inven<Rareitem> rare = new Inven<Rareitem>();
        for (int i = 0; i < rare.Titem.Length; i++)
        {
            Rareitem item = new Rareitem { Gold = 100 + 10 * i, Name = "Rare_" + i };
            rare.Titem[i] = item;
        }
        rare.Func();

        // for (int i = 0; i < 30; i++)
        // {
        //     Thread.Sleep(500);
        //     int a = new Random().Next(-5, 10);
        //     Console.WriteLine(a);
        // }
        Console.ReadLine();
    }
}


// Interface
public interface Items
{
    int Gold { get; }
    string Name { get; }
}

public class Cashitem : Items
{
    public int Gold { get; set; }
    public string Name { get; set; } = string.Empty;
}


public class Rareitem : Items
{
    public int Gold { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class Inven<T> where T : Items
{
    public readonly T[] Titem = new T[10];

    public void Func()
    {
        foreach (T t in Titem.AsQueryable().ToList())
        {
            Console.WriteLine($"아이템 {t.Name} 구입가격은 {t.Gold}원 입니다....");
        }
    }
}
