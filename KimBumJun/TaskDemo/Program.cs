var result = await DoWorkAsync(1_000.0D);
var check = result.GetType() == typeof(Double);
char c = check ? '\u0024' : '\u20A9'; // $ or ₩
Console.WriteLine($"{c} {result:N2}");

/// <summary>
/// 원금 P에 대한 이자를 계산하는 함수
/// </summary>
static async Task<T> DoWorkAsync<T>(T p) where T : IConvertible
{
    var P = Convert.ToDouble(p); // 원금
    double E = Math.E; // Euler's number, 2.718281828459045, 자연로그의 밑
    double t = 2.0; // 년수 (2년)
    var r = 0.05; // interest rate, 이자율
    var A = P * Math.Pow(E, (r * t)); // A = P * e^(rt)
    await Task.Delay(1000);
    return (T)Convert.ChangeType(A, typeof(T));
}
