
namespace Helper;

public class DemoSwitch
{
    // (1) Start
    public void GetGrade()
    {
        ConsoleKeyInfo cki = default;   // 하나의 키만 입력 받기
        bool repeat = default;          // 재수강 여부
        bool check = false;             // 잘못된 점수 입력 확인용
        do
        {
            // 재 수강 여부 확인
            Console.WriteLine();
            Console.Write($"재수강 여부? Yes(Y) / No(N) : ");
            cki = Console.ReadKey(false);
            repeat = cki.Key == ConsoleKey.Y; // 대소문자 무관
            Console.WriteLine();

            // 학생의 점수 입력 받기
            Console.Write($"\n점수를 입력하세요 (0 ~ 100) >> ");

            // 입력한 값이 정수값인지 확인하기 (정수가 아니면 무한 루핑)
            check = int.TryParse(Console.ReadLine(), out int score);

            if (check) // 점수를 재대로 입력했을 시 (즉, 숫자가 아닌 문자 입력시 스킵됨)
            {
                // 최종 학점출력
                Console.WriteLine
                ($"귀하의 점수는 ( {score} ) 으로\n" +
                $"학점은 ( {MakeGrade(Convert.ToInt32(Math.Truncate(score / 10.0) * 10), repeat)} ) 입니다.");
            }
            // 한칸 뛰기 모양내기
            Console.WriteLine();

            // 학점 관리 지속여부 확인하기
            Console.Write("계속 입력하시겠습니까? (Yes(Y) / No(N)) >> ");
            cki = Console.ReadKey();

        } while (cki.Key == ConsoleKey.Y); // N 키 입력시 빠져나감

        Console.WriteLine();
        Console.WriteLine("학점관리를 종료합니다.");
    }

    // (2) 학점 만들기 전용 함수
    private string MakeGrade(int score, bool repeat) => (score) switch
    {
        90  => !repeat ? "A" : "B+",  // 90 점 이상 중 재수강: "B+", 일반수강: "A"
        80 => "B",                      // 80 이상 90 이하
        70 => "C",                      // 70 이상 80 이하
        60 => "D",                      // 60 이상 70 이하
        _ => "F"
    };
}
