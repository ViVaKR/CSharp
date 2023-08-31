namespace BootCamp;
public class DynamicCompile
{
    private readonly string code;
    public DynamicCompile()
    {
        code = @"""
using System;

namespace DynamicCompile;
public class Program
{
    public static void Main()
    {
        int sum = 0;
        for (int i = 1; i <= 100; i++)
        {
            sum += i;
        }
        Console.WriteLine(sum);
    }
}
""";
    }

    public void Run()
    {
        // 컴파일러 객체
    }
}
