using System;
using System.Runtime.InteropServices;
namespace VarMemory;

// Define a struct with byte fields
// Pack = 1: Align fields on 1-byte boundaries
[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct ByteStruct
{
    public byte a;
    public byte b;
    public byte c;
}

public class DataLayout
{

    public unsafe static void Run()
    {
        ByteStruct byteStruct = new() { a = 125, b = 0x7D, c = 0b01111101 }; // Initialize the struct

        byte* startAddress = (byte*)&byteStruct; // Get the address of the struct
        int n = sizeof(ByteStruct); // Get the size of the struct
        byte* endAddress = startAddress + n; // Calculate the end address

        for (byte* ptr = startAddress; ptr < endAddress; ptr++)
        {
            string variableName = string.Empty;
            if (ptr == &byteStruct.a) variableName = "a";
            else if (ptr == &byteStruct.b) variableName = "b";
            else if (ptr == &byteStruct.c) variableName = "c";

            if (!string.IsNullOrEmpty(variableName))
            {
                Console.WriteLine($"\n{variableName}:");
            }

            Console.WriteLine($"Address: {(long)ptr:X}, Value: {*ptr:X}");
        }
    }
}

/*

C#에서 기본 정렬 방식은 구조체의 멤버들이 자연스러운 경계(natural boundary)에 맞춰 정렬되는 것입니다.
이는 성능 최적화를 위해 사용됩니다.
기본적으로, 구조체의 멤버들은 해당 멤버의 크기에 맞춰 정렬됩니다.
예를 들어, int 타입의 멤버는 4바이트 경계에 맞춰 정렬됩니다.

64비트 시스템에서도 기본 정렬 방식은 4바이트 단위로 정렬될 수 있습니다.
그러나, 구조체의 멤버들이 8바이트 경계에 맞춰 정렬될 수도 있습니다.
이는 구조체의 멤버 타입과 구조체의 크기에 따라 다릅니다.

구조체의 정렬 방식을 제어하려면 StructLayout 특성을 사용할 수 있습니다.
StructLayout 특성은 구조체의 메모리 레이아웃을 제어하는 데 사용됩니다.
Pack 인수를 사용하여 구조체의 멤버들이 특정 바이트 경계에 맞춰 정렬되도록 설정할 수 있습니다.

 */
