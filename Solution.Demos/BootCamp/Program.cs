
string[] agus = Environment.GetCommandLineArgs();

int choice = agus.Length > 1 ? Convert.ToInt32(agus[1]) : 1;
if (agus.Length < 2)
{
    Write("실행메뉴 선택 ");
    var tf = int.TryParse(Console.ReadLine(), out choice);
}
Console.WriteLine(Env.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));


switch (choice)
{
    case 1: RunRecord(); break;
    case 2: ToU8(); break;
    case 3: Console.WriteLine(CheckMemberShip("admin")); break;
    case 4 : Console.WriteLine(new Calculate<int>().Mul(12, 5)); break;
    case 5 : new Calculate<int>().Shift(); break;
}

static int CheckMemberShip(ReadOnlySpan<char> c)
{
    if (c is "admin") return 1;
    if (c is "supervisor") return 2;

    int membership = c switch {
        "IT" => 3,
        "HR" => 4,
        _=> 10
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

