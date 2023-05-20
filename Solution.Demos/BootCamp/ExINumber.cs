using System.Numerics;

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
        Console.Write($"{s} ");
        Console.WriteLine($"{i}");
        for (int k = 1; k < s.Length; k++)
        {
            int t = i << k;
            Console.WriteLine($"{Convert.ToString(t, 2)} {Convert.ToInt32(t)}");
        }

        i = 2147483647;
        s = Convert.ToString(i, 2);
        Console.Write($"{s.PadLeft(32, '0')} ");
        Console.WriteLine($"{i}");
        for (int k = 1; k <= s.Length; k++)
        {
            int t = i >> k;
            Console.Write($"{Convert.ToString(t, 2).PadLeft(32, '0')} ");
            Console.WriteLine($"{Convert.ToInt32(t)}");
        }
    }

}
