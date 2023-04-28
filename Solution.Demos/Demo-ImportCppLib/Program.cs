
using System.Runtime.InteropServices;

namespace Demo_ImportCppLib;
class Program
{
    [DllImport("Resources/Libs/demo.dylib")]
    public virtual static extern  int demo(int arg1, string arg2);
    static void Main(string[] args)
    {
        Console.WriteLine($"Hi! {demo(3, "Hello World")}");

        Arr arr = new Arr
        {
            Value = new int[] {
                1, 2, 3, 4, 5, 6
            }
        };

        Console.WriteLine(arr.Value[0]);
    }
}

public class DemoA
{
    [DllImport("Resources/Libs/demo.dylib")]
    public static virtual extern int demo(int arg1, string arg2);
    public virtual int Hello { get; set; }

    public new string Message;
    public Demos()
    {
        Message = demo(3, "Hi Everyone");

    }
}
