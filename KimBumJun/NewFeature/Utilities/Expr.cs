namespace NewFeature.Utilities;

public class Expr
{
    // 이동 메서드
    // 입력된 키 코드에 따라 이동 하는 정적 메서드
    public static async Task MoveAsync(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.W:
                Console.WriteLine("-> 위로 이동");
                break;
            case KeyCode.A:
                Console.WriteLine("-> 좌로 이동");
                break;
            case KeyCode.S:
                Console.WriteLine("-> 아래로 이동");
                break;
            case KeyCode.D:
                Console.WriteLine("-> 우로 이동");
                break;
            case KeyCode.F:
                Console.WriteLine("-> 공격");
                break;
            default:
                Console.WriteLine("-> Unknown");
                break;
        }
        await Task.CompletedTask;
    }
}
// Path: NewFeature/Utilities/KeyCode.cs
public enum KeyCode : int
{
    W = 1,
    A = 2,
    S = 3,
    D = 4,
    F = 5
}
