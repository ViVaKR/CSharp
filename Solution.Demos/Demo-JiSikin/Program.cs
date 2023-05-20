using Helper;
using Lib_TcpListener;
using Lib_TcpClient;
using Libs;

var pretty = string.Join(string.Empty, Enumerable.Repeat("-", 80));

var menus = new List<string>{
    "Exit", "Money", "UDP",
    "Ping", "Student",
    "Files", "Interface",
    "Reflection", "Switch",
    "TcpServer", "TcpClient",
    "CSV", "CaesarCipher",
    "Check Internet", "Get html",
    "야구게임", "게임 인벤토리"
};

int choice;
bool check = false;
do
{
    Console.WriteLine(pretty);
    Console.WriteLine("MENU".PadLeft(40));
    Console.WriteLine(pretty);
    int i = 0;
    foreach (var menu in menus)
    {
        var text = $"{i:000}. {menu}".PadRight(30);
        if ((i + 1) % 3 == 1)
            Console.WriteLine(text);
        else
            Console.Write(text);

        i++;
    }
    Console.WriteLine();
    Console.WriteLine(pretty);
    Console.WriteLine();
    Console.Write("실행메뉴 선택 >>> ");

    check = int.TryParse(Console.ReadLine(), out choice);
    Console.WriteLine();
    if (!check)
    {
        Console.WriteLine("잘못된 선택입니다. ");
        Console.Clear();
    }

} while (!check);


switch (choice)
{
    case 0:
        {
            Environment.Exit(0);
        }
        return;
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

    case 4:
        {
            Student[] students = new Student[]
            {
                new Student ("김태희", new int[] { 89, 90, 45, 77 }),
                new Student ("정우성", new int[] { 92, 66, 88, 33 }),
                new Student ("고현정", new int[] { 85, 95, 73, 82 }),
                new Student ("이문세", new int[] { 77, 20, 66, 84 }),
                new Student ("강호동", new int[] { 37, 70, 43, 65 })
            };

            // 성적 배열에서 다시 한번 더 필터링하는 단계가 필요합니다.
            // (1) 5개 성적 중 60점 미만이 있는 학생을 추출하여
            // (2) 학생 이름과 낙제한 성적을 콤마로 분리하여 프린팅하기
            var loser = students.Where(x => x.Score.Any(w => w < 60)).Select(s => new
            {
                낙제생명 = s.Name,
                낙제점수 = s.Score.Where(w => w < 60).ToArray()
            });

            // 배열을 문자열로 합쳐서 출력하기
            foreach (var st in loser)
                Console.WriteLine($"- 낙제생: {st.낙제생명}\t- 낙제 점수: {string.Join(", ", st.낙제점수)}");
        }
        break;

    case 5:
        {
            string targetDir = "./files";
            string[] targetFiles = { "b", "c", "f", "g", "k", "z", "j", "l", "m" };
            var di = new DirectoryInfo(targetDir);

            for (char i = 'a'; i <= 'z'; i++)
            {
                if (i % 2 == 1)
                {
                    var file = Path.Combine(targetDir, $"{i}.txt");
                    var fi = new FileInfo(file);
                    if (!fi.Exists) fi.Create();
                }

            }
            Console.ReadLine();

            Files files = new Files();
            files.DeleteFilesWithFileName(di, targetFiles);
        }
        break;

    case 6:
        {
            IDemo idemo = new ChildA();
            idemo.DemoFunc();
        }
        break;

    case 7: // Method Invoke
        {
            // Reflection To Call 
            //! Reflection : 인스턴스를 동적으로 할당하거나
            //! 메서드, 필드, 속성 등을 동적으로 호출 할 수 있는 기능을 통칭함
            // 실행중인 코드에 대한 정보를 가져오고 조작하는 기능을 제공하는 API
            // 컴파일된 코드이 형식(Type), 멤버(Member) 등에 대한 정보를 검사하고 수정
            // 형식(Type) 정보 가져오기 : 이름, 어셈블리, 메서드, 속성, 필드, 이벤트,
            // 객체 생성
            // 메서드, 속성, 필드, 이벤트 등의 정보 가져오기
            // 어셈블리 정보 가져오기
            // 런타임 시간에 코드를 검사하고 실행가기 때문에 성능상의 문제 발생가능
            // 캐싱 등의 방법으로 성능 최적화 필요 
            Type t = typeof(ChildA);
            var m = t.GetMethod("Print");
            if (m == null) return;
            var getParameters = m.GetParameters();
            var setParameters = getParameters.Length == 0 ? null : new object[] { "안녕하세요 반갑습니다." };
            var instance = Activator.CreateInstance(t);
            if (instance == null) return;
            m.Invoke(instance, setParameters);

            // 파라미터가 있는 메서드
            Action<string> print = Console.WriteLine;
            print.Invoke("Hello World");
            new Action<string>(Console.WriteLine).Invoke("Find Thanks And You");

            // 정적메서드 호출
            System.Reflection.MethodInfo? writeLine = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            writeLine?.Invoke(null, new object[] { "Fine Thanks And You?" });
        }
        break;
    case 8:
        {
            var grade = new DemoSwitch();
            grade.GetGrade();
        }
        break;

    case 9:
        {
            // TcpServer server = new();
            // server.Start();
            SslTcpServer.RunServer("./localhost.pfx", "123456");
        }
        break;

    case 10:
        {
            // TcpClients client = new();
            // client.Connect(DateTime.Now.ToLongDateString());
            SslTcpClient.RunClient("localhost", "123456", "./localhost.pfx");
        }
        break;

    case 11: // 지식인 답변용
        {
            var readCsv = new ReadCsv();
            readCsv.Run();
        }
        break;

    case 12: // CaesarCipher
        {
            var plain = "Hello World";
            var keyNumber = 15;

            var cipher = CaesarCipher.CaesarEncipherText(plain, keyNumber);
            Console.WriteLine(cipher);

            var decipher = CaesarCipher.CaesarDecipherText(cipher, keyNumber);
            Console.WriteLine(decipher);


        }
        break;

    case 13: // 인터넷 연결확인
        {
            var tf = Utility.IsInternetConnected();
            Console.WriteLine(tf ? "인터넷 연결 정상" : "인터넷 연결 없음");

            TimeSpan timeSpan = new TimeSpan(13, 53, 44);
            Console.WriteLine(timeSpan.TimeFormat());

            Console.WriteLine($"{Utility.GetWebPage("http://ip.text.or.kr")}");
        }
        break;

    case 14: // Get Html 
        {
            Console.Write("웹 주소를 입력하세요 >> ");
            string url = Console.ReadLine() ?? "http://ip.text.or.kr";

            Console.WriteLine($"{Utility.GetWebPage(url)}");
        }
        break;

    case 15: // 야구게임
        {
            var game = new Games();
            game.Game011();
        }
        break;

    case 16: // 인벤토리
        {
            var game = new Games();
            game.Game015();
        }
        break;
}
