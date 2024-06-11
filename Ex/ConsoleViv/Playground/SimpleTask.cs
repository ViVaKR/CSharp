namespace ConsoleViv;

public class SimpleTask
{
    public static async Task RunAsyncA()
    {
        // 선행 작업
        await Task.Delay(1000); // (선행 작업) 5초
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\u26A9 첫번째 오초대기 ... \u26BE ... 선행작업 완료!");
        Console.ResetColor();
    }

    public static Task RunB()
    {
        Task.Delay(1000); // (후행 작업) 1초
        // 후행 작업
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\u26A9 두번째 용서없이 ... \u26BD ... 후행작업 완료!");
        Console.ResetColor();
        return Task.CompletedTask;
    }

    public static void Add(ref int a, int b, out int sum)
    {
        a += b; // ref a 는 이미 값이 있음을 전체로 하고, 다만 그것을 읽고 수정할 수 있다는 의미, 할당 안하고 여기까지 올 수 없음.
        sum = a + b; // out sum 은 값이 설정되어 있지 않다는 것을 전제로 하기에, 메서드를 빠져나가기 전에 sum에 꼭 값을 꼭 할당해야 함, 그냥은 나갈 수 없음.(컴파일 에러 발생 )
    }
}
