
using System.Runtime.InteropServices;

namespace Demo_ImportCppLib;
class Program
{
    [DllImport("Resources/Libs/demo.dylib")]
    public static extern int demo(int arg1, string arg2);
    static void Main(string[] args)
    {
        Console.WriteLine($"Hello, World! {demo(12, "Hello World")}");
    }
}
