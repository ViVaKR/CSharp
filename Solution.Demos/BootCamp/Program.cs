try
{
    string[] agus = Environment.GetCommandLineArgs();
    var menu = new Dictionary<int, string>{
        { 1, "Record" },
        { 2, "U8" },
        { 3, "CheckMemberShip" },
        { 4, "Calculate" },
        { 5, "Shift" },
        { 6, "FileHashMD5" },
        { 7, "Prime Number" },
        { 8, "Greatest Common Denominator" },
        { 1000, "Exit" },
    };

    int choice = agus.Length > 1 ? Convert.ToInt32(agus[1]) : 1;
    if (agus.Length < 2)
    {

        ConsoleKeyInfo cki = default;
        do
        {
            Console.WriteLine();
            Console.WriteLine("\n***** 실행가능한 프로그램 ******\n");

            foreach (var item in menu)
                Console.WriteLine($"{item.Key:0000}. {item.Value} ");

            Write("\n번호선택 >> ");

            while (!Console.KeyAvailable)
                Thread.Sleep(100);

            var tf = int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1: RunRecord(); break;
                case 2: ToU8(); break;
                case 3: WriteLine(CheckMemberShip("admin")); break;
                case 4: WriteLine(new Calculate<int>().Mul(12, 5)); break;
                case 5: new Calculate<int>().Shift(); break;
                case 6: new FileHashMD5().Run(); break;
                case 7: 100.GetPrimeNumber(); break;
                case 8: GreatestCommonDenominator(); break;

                case 1000: return;
            }

            Console.Write("\n계속하시겠습니까? Yes(Y)/No(N) >> ");
            cki = Console.ReadKey(true);
            Console.WriteLine();

        } while (cki.Key != ConsoleKey.N);
    }

    /// <summary>
    /// 최대공약수
    /// </summary>
    static void GreatestCommonDenominator()
    {
        WriteLine("GCD of 12 and 18 is " + 12ul.GreatestCommonDenominator(18ul));
        WriteLine("GCD of 112 and 105 is " + 112ul.GreatestCommonDenominator(105ul));
    }

    static int CheckMemberShip(ReadOnlySpan<char> c)
    {
        if (c is "admin") return 1;
        if (c is "supervisor") return 2;

        int membership = c switch
        {
            "IT" => 3,
            "HR" => 4,
            _ => 10
        };
        return membership;
    }

    static void ToU8()
    {
        ReadOnlySpan<char> strArr = "admin".AsSpan();
        foreach (var item in strArr)
        {
            Console.WriteLine(item);
        }
        ReadOnlySpan<byte> bytes = "안녕"u8;
        Console.WriteLine(Encoding.UTF8.GetString(bytes));
        char[] ch = Encoding.UTF8.GetChars(bytes.ToArray());
        foreach (var item in ch)
        {
            Console.WriteLine(item);
        }

        var kr = Encoding.UTF8.GetBytes("안녕하세요 반갑습니다.");
        ch = Encoding.UTF8.GetChars(kr);
        foreach (var item in ch)
        {
            Console.WriteLine(item);
        }

    }

    /// <summary>
    /// record
    /// </summary>
    static void RunRecord()
    {
        // default
        RecMember member = new RecMember("Viv", 43);
        Console.WriteLine(member.Name);

        // init
        var member2 = new RecMember
        {
            Name = "장길산",
            Age = 27
        };

        Console.WriteLine(member2.Name);
        Console.WriteLine(member2.Age);

        // with
        var member3 = member2 with { Name = "Mark" };
        Console.WriteLine(member3.Name);

        // Equals, ReferenceEquals
        var member10 = new RecMember("Viv", 43);
        Console.WriteLine(member.Equals(member10));
        Console.WriteLine(ReferenceEquals(member, member10));

        RecMember member22 = new Employee
        {
            Id = 1,
            Name = "Viv",
            Age = 55
        };

        WriteLine($"{member22.Age} {member22.Name}");

        // Deconstructor
    }


}
catch (Exception ex)
{
    var line = ex.GetErrorLineNumber();
    Console.WriteLine($"오류발생 ( {line} )");
}
