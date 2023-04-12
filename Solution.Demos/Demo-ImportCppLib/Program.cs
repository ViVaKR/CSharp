
using System.Runtime.InteropServices;

namespace Demo_ImportCppLib;
class Program
{
    [DllImport("Resources/Libs/demo.dylib")]
    public static extern int demo(int arg1, string arg2);
    static void Main(string[] args)
    {
        Console.WriteLine($"Hello, World! {demo(12, "Hello World")}");

        Arr arr = new Arr
        {
            Value = new int[] {
                1, 2, 3, 4, 5, 6
            }
        };
        
        Console.WriteLine(arr.Value[0]);
    }
}
