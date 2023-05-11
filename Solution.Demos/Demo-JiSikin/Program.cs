using Helper;
Console.Write("메뉴선택 >> ");
Console.WriteLine("1. Money");
Console.WriteLine("2. UDP");
Console.WriteLine("3. Ping");
Console.WriteLine("4. 낙제한 학생/점수");
Console.WriteLine("5. 파일 찾기/삭제하기");
Console.WriteLine("6. 인터페이스 1");
Console.WriteLine("7. Reflection Demo");

Console.WriteLine();
Console.Write("실행메뉴 선택 : ");
int choice;
bool check = int.TryParse(Console.ReadLine(), out choice);
Console.WriteLine();
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

            // 파라미터 없는 메서드
            new Action(Print).Invoke();

            // 정적메서드 호출
            System.Reflection.MethodInfo? writeLine = typeof(Console).GetMethod("WriteLine", new Type[] {typeof(string)});
            writeLine?.Invoke(null, new object[] {"Fine Thanks And You?"});
        }
        break;
    default: return;
}

void Print() {
    Console.WriteLine("Hello Demo");
}
