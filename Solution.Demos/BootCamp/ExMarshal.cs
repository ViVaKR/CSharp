
namespace BootCamp;
public class ExMarshal
{
    public struct Point
    {
        public int x, y;

    }

    public void Run()
    {
        WriteLine($"Char Size = {Marshal.SystemDefaultCharSize}");
        WriteLine($"struct Point Size = {Marshal.SizeOf(typeof(Point))}");
        Point p = new();
        WriteLine($"class Demo Size = {Marshal.SizeOf(p)}");

        const string t = "Hello World";
        WriteLine($"class Demo Size = {Marshal.SizeOf(t)}");
    }
}
