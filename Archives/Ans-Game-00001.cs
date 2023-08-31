namespace CSharp;
class Program
{
    static void StartGame()
    {
        Random rnd = new Random();
        Console.WriteLine(string.Join("", Enumerable.Repeat("-", 40)));
        Console.WriteLine();
        Console.Write("== 게임을 시작하겠습니다! ==\n게임시작 Yes(Y) / 게임거부 No(N) >> ");
        
        // Y, N 만 체크할 때에는 ReadKey 가 효율적임
        // 대소문자 구분할 필요 없으며, 하나의 키 입력만 받기때문
        ConsoleKeyInfo cki = Console.ReadKey();
        if (cki.Key == ConsoleKey.N)
        {
            Console.WriteLine("\n게임종료~");
            Environment.Exit(0); // 어플리케이션 자체를 종료하기
        }

        // 게임 시도 횟수
        int chance = 10;

        const string continueCheck = "기회를 모두 사용하셨습니다.\n다시 하겠습니까?( Yes(Y) / No(N)) ";

        // 랜덤 정답 숫자 만들기
        int computerNum = rnd.Next(1, 101);

        // 일단 최초 입력은 받아야 하기 때문에 do while loop 가 권장됨
        do
        {
            Console.WriteLine($"게임 크래딧  => ( {chance} ) ");

            int userNum; // 사용자 입력 숫자
            dynamic? input; // 입력받기 임시 변수
            bool check = false; // 입력받은 숫자의 정합성 체크 용 임시 변수

            // 1 부터 100 사이 입력 확인 및
            // 숫자입력인지 여부 확인
            // 일단 게임을 하기로 했으니 정확히 입력할 때 까지 백룸에 무섭게 가둬 놓기, 못나감
            do
            {
                Console.Write("1 ~ 100사이의 숫자를 입력해주세요 : ");

                // 응용프로그램 오류를 제거하기 위하여 try parse 권장
                // 즉 일반 문자를 입력시 int.Parse 는 오류와 함께 어플리케이션 뻣어버림 방지 
                check = int.TryParse(input = Console.ReadLine(), out userNum);

                if (!check) // 잘못된 입력 (숫자가 아닐때)
                {
                    Console.WriteLine($"잘못된 입력입니다. => {input}");
                }

                // 숫자 범위 (1 ~ 100 사이)를 넘었을 때
                // 1 부터 100개 를 의미함으로 1 ~ 100 사이에 
                // 사용자의 입력 숫자가 있지 않다면?
                if (!Enumerable.Range(1, 100).Any(x => x == userNum))
                { // 이리로 모심, 
                    check = false;
                    Console.WriteLine($"1 ~ 100 사이의 숫자를 입력하세요 => {input}");
                }

            } while (!check);

            chance--; // 입력이 정확하면 먼저 횟수 차감하기

            if (computerNum == userNum)
            {
                Console.Write("정답입니다!. \n다시 도전 하시겠습니까? (Yes(Y) / No(N)) => ");

                bool tf = false;
                do
                {
                    cki = Console.ReadKey(true);
                    tf = cki.Key != ConsoleKey.Y || cki.Key != ConsoleKey.N;
                    if (!tf) Console.Write("Yes(Y)나 No(N)만 입력해주세요. => ");
                } while (!tf);

                if (cki.Key == ConsoleKey.Y) Charge();
                if (cki.Key == ConsoleKey.N)
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    Environment.Exit(0);
                }
            }

            // 삼항 연산으로 힌트 메시지 초기화
            string hint = computerNum > userNum 
            ? $"(힌트) {userNum} 보다 큰수를 선택하여 보세요"
            : $"(힌트) {userNum} 보다 작은 수를 선택하여 보세요";

            // 한번이라도 도전을 한 후 힌트 주기, 즉 처음엔 힌트 없음
            Console.WriteLine(chance < 10 ? hint : "(힌트) 없음");

            // 횟수 소진 시 게임 지속 여부 확인하기
            if (chance == 0) Charge(true);
            
            // 게임 재도전 시 충전 또는 종료 처리를 nested method 로 하여 가독성 향상
            void Charge(bool tf = false)
            {
                if (tf) // 충전이 소진 되었을 때만 메시지 활성화
                {
                    Console.Write(continueCheck);
                    cki = Console.ReadKey(true);
                    if (cki.Key != ConsoleKey.Y) Environment.Exit(0);
                }

                // 충전을 한번에 드르륵... 하기 보다는
                // 10초에 걸쳐 천천히 충전 느낌을 주는 느낌있는 게임 진행 용
                for (int i = 0; i < 10; i++)
                {
                    Console.Clear(); // 화면 정리
                    // 작대기 10개를 배열로 만들어 놓고
                    // 루프를 1초 마다 돌때 마다 숫자만큼 연결하여 (작대기 + 충전 수량) 보여주기
                    Console.WriteLine($"충전 중 {string.Join("", Enumerable.Repeat("-", 10).Take(i))} {chance = i + 1}");

                    // 1초 딜레이
                    Thread.Sleep(1000);
                }
                // 정답 초기화
                computerNum = rnd.Next(1, 101);

                Console.WriteLine("충전완료! \n즐겜하세요...^^");
            }

        } while (true); // 'N' 키 입력시 Envirent.Exit(0) 로 탈출함
    }
}
