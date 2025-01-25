using System.Text;
using VarMemory;

Console.OutputEncoding = Encoding.UTF8;
Demo();
unsafe static void Demo()
{
    byte a = 125;
    byte b = 0x7D;
    byte c = 0b01111101;

    byte* startAddress = &c;

    int n = 12;
    byte* endAddress = startAddress + n;
    Console.WriteLine("\n(1) Memory range (default, \x1b[035m4byte\x1b[0m):");

    for (byte* ptr = startAddress; ptr < endAddress; ptr++)
    {
        string variableName = "";
        if (ptr == &a) variableName = "a";
        else if (ptr == &b) variableName = "b";
        else if (ptr == &c) variableName = "c";

        if (!string.IsNullOrEmpty(variableName))
        {
            Console.WriteLine($"\nbyte {variableName}:");
        }

        Console.WriteLine($"Address: {(long)ptr:X}, Value: {*ptr:X}");
    }
}

Console.WriteLine("\n(2) Memory range (natural boundary, \x1b[035m1byte\x1b[0m):");
DataLayout.Run();
