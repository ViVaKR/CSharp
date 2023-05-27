var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices(services => services.AddHostedService<Worker>().AddScoped<IMessageWriter, MessageWriter>());

using var host = builder.Build();

host.Run();

// using IHost host = Host.CreateDefaultBuilder(args).Build();

// Build a config object, using env vars and JSON providers.
// IConfiguration config = new ConfigurationBuilder()
//     .AddJsonFile("appsettings.json")
//     .AddEnvironmentVariables()
//     .Build();

// IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

// Get values from the config given therir key and their target type.
// Settings? setting = config.GetRequiredSection("Settings").Get<Settings>();

// int KeyOne = config.GetValue<int>("KeyOne");
// bool KeyTwo = config.GetValue<bool>("KeyTwo");
// string? KeyThree = config.GetValue<string>("KeyThree:Message");

// string? ipOne = config["IPAddressRange:0"];
// string? ipTwo = config["IPAddressRange:1"];
// string? ipThree = config["IPAddressRange:2"];
// string? versionOne = config["SupportedVersions:v1"];
// string? versionThree = config["SupportedVersions:v3"];

// Write the values Settings Examples
// WriteLine($"KeyOne = {setting?.KeyOne}");
// WriteLine($"KeyTwo = {setting?.KeyTwo}");
// WriteLine($"KeyThree: Message = {setting?.KeyThree?.Message}");

// WriteLine($"KeyOne = {KeyOne}");
// WriteLine($"KeyTwo = {KeyTwo}");
// WriteLine($"KeyThree = {KeyThree}");
// WriteLine($"IPAddressRange:0 = {ipOne}");
// WriteLine($"IPAddressRange:1 = {ipTwo}");
// WriteLine($"IPAddressRange:2 = {ipThree}");
// WriteLine($"SupportedVersions:v1 = {versionOne}");
// WriteLine($"SupportedVersions:v3 = {versionThree}");

// await host.RunAsync();

/*  
try
{
    string[] agus = Env.GetCommandLineArgs();
    var menu = new Dictionary<int, string>{
        { 1, "Record" }, { 2, "U8" }, { 3, "CheckMemberShip" },
        { 4, "Calculate" }, { 5, "Shift" }, { 6, "FileHashMD5" },
        { 7, "Prime Number" }, { 8, "Greatest Common Denominator" }, { 9, "Recursions" },
        { 10, "Bits" }, { 11, "Span<T>" }, { 12, "Console WriteLine" },
        { 13, "Draw Rect" }, { 14, "Bits" }, { 15, "Linked Lists"},
        { 16, "Ref T"}, { 17, "Attribute Demo"}, {18, "Trace Logging"}, { 19, "Inheritance Demo"},
        { 1000, "Exit" },
    };

    int choice = agus.Length > 1 ? Convert.ToInt32(agus[1]) : 1;
    if (agus.Length < 2)
    {
        ConsoleKeyInfo cki = default;
        do
        {
            Clear();
            WriteLine();
            WriteLine("\n***** 실행가능한 프로그램 ******\n");

            foreach (var item in menu)
                WriteLine($"{item.Key:0000}. {item.Value} ");

            Write("\n번호선택 >> ");

            while (!KeyAvailable)
                Thread.Sleep(100);

            var tf = int.TryParse(ReadLine(), out choice);

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
                case 9: // 재귀함수
                    {
                        var rec = new Recursion();
                        // 글자 역순으로 만들기
                        WriteLine(rec.ReverseString("the simple engineer"));
                        WriteLine(rec.ReverseString("hello"));

                        // 회전문
                        WriteLine("KayaK = " + rec.Palindrome("KayaK"));
                        WriteLine("HiEveryoniH = " + rec.Palindrome("HiEveryoniH"));
                        WriteLine("HeltleH = " + rec.Palindrome("HeltleH"));
                        WriteLine("racecar = " + rec.Palindrome("racecar"));

                        // 2진수 변환기 (233 => 11101001)
                        WriteLine("233 = " + rec.NumberToBinary(233, string.Empty));

                        WriteLine($"1 부터 100 까지의 합계 = {rec.Summation(100)}");

                        // 이진탐색
                        var a = new int[] { -1, 0, 1, 2, 3, 4, 7, 9, 10, 20 };
                        // 찾을 수 = 10
                        WriteLine($"0, 10, 7 탐색 : {rec.BinarySearch(a, 0, 9, 10)}");

                        // 피보나치 (최적화되지 않은 방식)
                        WriteLine($"피보나치 30 번째 결과 = {rec.Fibonacci(30)}");

                        // Merge Sort
                        // 배열을 반으로 나눔
                        // 왼쪽 먼저...
                        // 외쪽 반을 다시 반 나눔
                        // 하나의 값이 나올 때 까지 반복
                        // 병합하고 정렬함
                        // 오른쪽
                        // 왼쪽과 같은 방식으로 진행하며 
                        // 병합하고 정렬
                        var data = new int[] { -5, 20, 4, 1, 3, 0, -2, 7, 10, 9 };
                        rec.MergeSort(data, 0, data.Length - 1);
                        WriteLine("Stop");
                        WriteLine($"data = {string.Join(", ", data)}");

                    }
                    break;
                case 10:
                    {
                        const uint a = 0b_0010_1111;
                        string result = Convert.ToString(a, toBase: 10);
                        WriteLine($"result = {result}");
                        var span = new ReadOnlySpan<char>(new char[] { 'a', 'b' });
                        WriteLine($"span = {span}");
                    }
                    break;
                case 11: new ExSpan().Run(); break;
                case 12: new ExWriteLine().Run(); break;
                case 13: new ExWriteLine().DrawRect(); break;
                case 14: Demo_Bits.Program.Main(); break;
                case 15: new ExLinkedList().MakeNode(); break;
                case 16: new ExSpan().GenericTest(); break;
                case 17: new TestTrigger().Run(); break;
                case 18: new TraceLogging().Run(); break;
                case 19: new DemoInheritance().Run(); break; // 지식인 답변
                case 1000: return;
            }

            Write("\n계속하시겠습니까? Yes(Y)/No(N) >> ");
            cki = ReadKey(true);
            WriteLine();
            Thread.Sleep(10);
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

        return c switch
        {
            "IT" => 3,
            "HR" => 4,
            _ => 10
        };
    }

    static void ToU8()
    {
        foreach (var item in "admin".AsSpan())
        {
            WriteLine(item);
        }
        ReadOnlySpan<byte> bytes = "안녕"u8;
        WriteLine(Encoding.UTF8.GetString(bytes));
        char[] ch = Encoding.UTF8.GetChars(bytes.ToArray());
        foreach (var item in ch)
        {
            WriteLine(item);
        }

        var kr = Encoding.UTF8.GetBytes("안녕하세요 반갑습니다.");
        ch = Encoding.UTF8.GetChars(kr);
        foreach (var item in ch)
        {
            WriteLine(item);
        }

    }

    /// <summary>
    /// record
    /// </summary>
    static void RunRecord()
    {
        // default
        RecMember member = new("Viv", 43);
        WriteLine(member.Name);

        // init
        var member2 = new RecMember
        {
            Name = "장길산",
            Age = 27
        };
        WriteLine(member2.Name);
        WriteLine(member2.Age);

        // with
        var member3 = member2 with { Name = "Mark" };
        WriteLine(member3.Name);

        // Equals, ReferenceEquals
        var member10 = new RecMember("Viv", 43);
        WriteLine(member.Equals(member10));
        WriteLine(ReferenceEquals(member, member10));

        RecMember member22 = new Employee
        {
            Id = 1,
            Name = "Viv",
            Age = 55
        };

        WriteLine($"{member22.Age} {member22.Name}");
    }
}
catch (Exception ex)
{
    var line = ex.GetErrorLineNumber();
    WriteLine($"오류발생 ( {line} )\n{ex.Message}");
}

*/
