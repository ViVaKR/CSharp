namespace Bits;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        for (int i = 0; i < 4; i++)
        {
            int tf = GetBits(9, i) ? 1 : 0;
            Console.Write($"{tf} ");
        }
        Console.WriteLine();
    }

    static bool GetBits(int num, int index)
    {

        return (num & (1 << index)) != 0;
    }

    static void InputValueDemo()
    {
        // 피 연산자 저장소
        int[] inputs = new int[2];
        // 숫자만 넣었는지 확인용
        bool check = false;

        // 루프 대응용
        string[] prefix = new[] { "첫", "두" };

        // 숫자 2개 확인 후 루프 빠져나가기 용
        int count = 0;
        do
        {
            // 콘솔 지우고
            Console.Clear();
            // 커서 포지션을 좌상에 초기화
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"현재 상태 : {inputs[0]} - {inputs[1]} = {inputs[0] - inputs[1]}");
            Console.Write($"{prefix[count]} 번째 숫자 : ");

            // 숫자확인후 다음으로 넘어가기
            check = int.TryParse(Console.ReadLine(), out inputs[count]);
            // 한칸 뛰기
            Console.WriteLine();
            // 숫자 2개 다 넣었는지 확인하기
            count += check ? 1 : 0;
        } while (count < 2);

        // 출력
        Console.Write($"{inputs[0]} - {inputs[1]} = {inputs[0] - inputs[1]}");
        Console.WriteLine();
    }

}

