namespace BootCamp.Libs;

public static class Helper
{
    /// <summary>
    /// 오류번호 찾기
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <returns></returns>
    public static int GetErrorLineNumber(this Exception ex)
    {
        // Get stack trace for the exception with source file information
        var st = new StackTrace(ex, true);
        // Get the top stack frame
        var frame = st.GetFrame(0);
        // Get the line number from the stack frame
        return frame?.GetFileLineNumber() ?? -1;
    }

    /// <summary>
    /// 소수 구하기
    /// 1보다 큰 자연수 중 1과 자기 자진만을 약수로 가지는 수
    /// </summary>
    /// <param name="number">최대 수</param>
    public static void GetPrimeNumber(this int number)
    {
        WriteLine($"2 ~ {number} 소수 (에라토스테네스의 체)");
        var isPrime = new bool[number + 1];
        isPrime[0] = false;
        isPrime[1] = false;
        Array.Fill(isPrime, true);
        // 어떤수 i 가 소수가 아니라면, i = a x b 형태로 곱해짐
        // 이때 a와 b 둘 중 하나는 반드시√i 이하
        // (ex: 36의 약수 쌍 -> 1 * 36, 2 * 8, 3 * 12, 4 * 9, 6 * 6)
        for (int i = 2; i * i <= number; i++)
        {

            if (isPrime[i])
            {
                // i 의 배수들을 싹 다 소수에서 적출
                for (int j = 2; j * j <= i; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }
        for (var i = 2; i <= number; i++)
            if (isPrime[i]) Console.WriteLine($"소수: {i}");
    }

    /// <summary>
    /// 최대공약수 구하기
    /// </summary>
    /// <param name="a"></param>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static ulong GreatestCommonDenominator(this ulong left, ulong right)
    {
        // 두수 중에 하나가 0이 될대 까지 반복해서
        // mod 연산을 함 (큰수를 작은수로 ... )
        // 둘중 작은수가 먼저 0 이되면 루프를 빠져나가고..
        while (left != 0 && right != 0)
        {
            if (left > right)
                left %= right;
            else
                right %= left;
        }
        // 12 가 먼저 0 이되고 18은 6인 상태에서 이곳으로 옴
        // a = 0000
        // b = 0110
        // 해서,
        // 두개 수를 or 비트 연산을 하면
        // 결과 => 0110 (6) 됨..
        // 즉, 두개중 0 이 아닌 최대 숫자(최대공약수)가 검출됨
        return left | right;
    }
}
