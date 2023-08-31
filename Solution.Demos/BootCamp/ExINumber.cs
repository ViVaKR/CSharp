using System.Numerics;

namespace BootCamp;
public class Calculate<T> where T : INumber<T>
{
    public T Add(T a, T b) => a + b;
    public T Sub(T a, T b) => a + b;
    public T Div(T a, T b) => a + b;
    public T Mul(T a, T b) => a + b;

    public void Shift()
    {
        int i = -1;
        string s = Convert.ToString(i, 2);
        Write($"{s} ");
        WriteLine($"{i}");
        for (int k = 1; k < s.Length; k++)
        {
            int t = i << k;
            WriteLine($"{Convert.ToString(t, 2)} {Convert.ToInt32(t)}");
        }

        i = 2147483647;
        s = Convert.ToString(i, 2);
        Write($"{s.PadLeft(32, '0')} ");
        WriteLine($"{i}");
        for (int k = 1; k <= s.Length; k++)
        {
            int t = i >> k;
            Write($"{Convert.ToString(t, 2).PadLeft(32, '0')} ");
            WriteLine($"{Convert.ToInt32(t)}");
        }
    }
}
