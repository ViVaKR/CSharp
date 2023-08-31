using System;
using System.Buffers;

namespace BootCamp;

public class ExIntPtr
{
    public void PointerTest()
    {
        unsafe
        {
            byte[] bytes = { 254, 1, 3 };
            fixed (byte* pointerToFirst = bytes)
            {
                Write($"bytes = {(long)pointerToFirst:X}");
            }

            WriteLine();

            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            fixed (int* toFirst = &numbers[0], toLast = &numbers[^1])
            {
                WriteLine($"{*toFirst}, {(long)toFirst:X}, {toLast - toFirst}, {(long)toLast:X}, {*toLast}");
            }

            Span<int> interior = numbers.AsSpan()[1..^1];
            fixed (int* p = interior)
            {
                for (int i = 0; i < interior.Length; i++)
                {
                    WriteLine($"{i} => {p[i]}");
                }
            }
        }

        IMemoryOwner<char> owner = MemoryPool<char>.Shared.Rent();
        WriteLine("Enter a number");
        try
        {
            string? s = ReadLine();
            if (s is null) return;
            var value = int.Parse(s);
            var memory = owner.Memory;
            WriteInt32ToBuffer(value, memory);
            DisplayBufferToConsole(owner.Memory[..value.ToString().Length]);
        }
        catch (FormatException)
        {
            WriteLine("You did not enter a valid number");
        }
        catch (OverflowException)
        {
            WriteLine($"You entered a number less than = {int.MinValue:N0} or greater than {int.MaxValue:N0}");
        }
        finally
        {
            owner?.Dispose();
            MemoryDemo();
            SpanDemo();
            MarhsalDemo();
            IntPrtDemo();
        }
    }

    public void MemoryDemo()
    {
        Memory<char> memory = new char[64];
        WriteLine("Enter a number");
        var s = ReadLine();
        if (s is null) return;
        var value = int.Parse(s);
        WriteToBuffer(value, memory);
        DisplayBufferToConsole(memory);
    }

    public void WriteInt32ToBuffer(int value, Memory<char> buffer)
    {
        var strValue = value.ToString();
        var span = buffer.Span;
        for (int i = 0; i < strValue.Length; i++)
        {
            span[i] = strValue[i];
        }
    }

    public void IntPrtDemo()
    {
        //! 관리되지 않는 메모리 블록에 대한 포인터.
        //! 메모리 주소 및 윈도우 OS 핸들값을 보관하는 용도.
        //! 핸들은 윈도우 OS 가 특정 자원에 대한 식별자 값.

        long ia = 123456789;
        long ib = 987654321;
        unsafe
        {
            IntPtr p1 = new(&ia);
            IntPtr p2 = new(&ib);

            WriteLine($"p1 = {ia} - {p1:X}");
            WriteLine($"p2 = {ib} - {p2:X}");
        }
    }

    public void MarhsalDemo()
    {
        //! Marshal Class : 메모리할당, 복사 하는 클래스.
        //! Win32 응용프로그램과 .Net 응용프로그램을 연결시킴.

        const string stringA = "I seem to be turn around!";
        int copylen = stringA.Length;

        //- Allocate HGlobal memory for source and destination strings
        IntPtr sptr = Marshal.StringToHGlobalAnsi(stringA);
        IntPtr dptr = Marshal.AllocHGlobal(copylen + 1);

        unsafe
        {
            byte* src = (byte*)sptr.ToPointer();
            byte* dst = (byte*)dptr.ToPointer();
            if (copylen > 0)
            {
                //> set the source pointer to the end of the string
                //> to do a reverse copy.
                // 소스 포인터를 문자열의 끝으로 설정 역 복사를 수행합니다.
                src += copylen - 1;
                while (copylen-- > 0)
                {
                    *dst++ = *src--;
                }
                *dst = 0;
            }
        }
        var stringB = Marshal.PtrToStringAnsi(dptr);
        WriteLine($"Original: {stringA}");
        WriteLine($"Reversed: {stringB}");

        Marshal.FreeHGlobal(dptr);
        Marshal.FreeHGlobal(sptr);
    }

    public void SpanDemo()
    {
        const int length = 5;
        unsafe
        {
            int* nums = stackalloc int[length];
            for (int i = 0; i < length; i++)
            {
                nums[i] = i * 100;
            }

            for (int i = 0; i < length; i++)
            {
                WriteLine($"{i} = {*(nums + i)}");
            }
        }

        Span<int> numbers = stackalloc int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i;
        }

        WriteLine($"a = {string.Join(", ", numbers.ToArray())}");

        //- 메모리 참조형식으로 원본과 객체가 같은 값을 반영함.
        WriteLine("== 참조형식 ==");
        var buffer = new byte[10];
        Span<byte> bytes = buffer;
        Span<byte> slice = bytes.Slice(5, 2);
        slice[0] = 100;
        slice[1] = 200;
        WriteLine($"{string.Join(", ", buffer.ToArray())}");

        bytes[2] = 44;
        bytes[3] = 45;
        WriteLine($"{string.Join(", ", buffer.ToArray())}");
    }

    public void WriteToBuffer(int value, Memory<char> buffer)
    {
        var strValue = value.ToString();
        strValue.AsSpan().CopyTo(buffer[..strValue.Length].Span);
    }

    public void DisplayBufferToConsole(Memory<char> buffer)
    => WriteLine($"Contents of the buffer:  = {buffer}");
}

/* Marshal
    - Marshal.StringToHGlobalAnsi
    - Marshal.AllocHGlobal
        > 관리되지 않은 문자열이 차지하는 것과 동일한 바이트 수를 할당
    - Marshal.ReadByte(IntPtr, Int32)
        > 관리되는 포인터에서 오프셋에서 바이트를 읽음. 오프셋은 루프에 따라 증가.
    - Marshal.WriteByte(IntPtr, Int32, Byte)
        > 비관리형 메모리 블록의 시작 주소와 정의된 멤모리 오프셋 주소에 바이트를 씀.
    - Marshal.PtrToStringAnsi
    - FreeHGlobal
        > 관리되지 않는 메모리 블록에 할당된 메모리를 헤제함
*/

/*
    - int* p : 정수에 대한 포인터
    - int** p : 정수에 대한 포인터를 가리키는 포인터
    - int*[] p : 정수에 대한 포인터의 1차원 배열
    - char* p : 문자에 대한 포인터
    - void* p : 알수 없는 형식에 대한 포인터
    - fixed statement : 해당 주소를 찾을 수 있도록 임시로 변수를 고정함
*/

/* fixed statement
 - 가비지 수집기가 이동 가능한 변수를 재배치하지 못하게 하고
 - 해당 변수에 대한 포인터를 선언함
 - 주소는 변경되지 않음
 - 선언된 포인터는 읽기 전용이며 수정할 수 없음
 - 선언된 포인터는 해당 fixed 문 내에서만 사용가능함
*/

/* 
    - Struct
        > Struct 는 Stack, Heap 에 할당될 수 있으며, 
        > 스택에 할당되어 있는 값 형식을 힙 영역에 할 당 할 때에는 박싱되어 메모리에 할당되고, 
        > 반대 언박싱 될 시에는 GC 개입으로 성능이 저하되므로 높은 성능을 위해 때로는 힙 할당 없이 스택에 할당가능
        > 이때 지원되는 타입이 ref struct 이며, ref struct 는 반드시 스택에만 할당 되도록 할 수 있는 타입 
        > (ex) `ref struct Point { }`, 이렇게 정의한 구조체는 오직 스택에만 존재할 수 있음
        > 때문에 클래스의 맴버변수로 사용이 불가능 하고 로컬변수와 메서드이 메게 변수로만 사용이 가능함
        > 읽기 전용의 `readonly ref struct` 를 지원

    - Span<T> : 
        > `ref struct` 타입의 구조체
        > 힙 영역 할당의 박싱작업은 불가능
        > 스택에만 존재할 수 있음
        > stacklloc 키워드를 이용하여 안전하게 Span<T> 로 사용할 수 있음

    - 가상메모리 : 
        > 힙(Heap) : 관리 힙, 가비지 콜렉션의 관리 대상
        > 스택(Stack) 
*/
