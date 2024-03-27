namespace BootCamp;

public class ExSpan
{
    public void Run()
    {
        First();
        NativeMemory();
        StackAlloc();
        WorkWithSpans();
        RangeSpan();
        Get();
    }

    public void GenericTest()
    {
        int a = 0;
        Func(ref a);
        Test1(23);
        WriteLine($"{a}");
    }

    public void Test1<T>(T data)
    {
        int number = data as dynamic;
        WriteLine(number);
    }

    public void Func<T>(ref T data) where T : struct
    {
        data = (dynamic)4;
    }

    public void Func(ref object data)
    {
        data = 4;
    }

    private void Get()
    {
        const string contents = "Content-Length: 132";
        var length = GetContents(contents.ToCharArray());
        WriteLine($"Content length : {length}");

        const string formatter = "{0,30}";
        const double dbl = 0.111_1111_1111_1111_1111;
        WriteLine(formatter, BitConverter.ToString(BitConverter.GetBytes(dbl)));
        WriteLine();

        const string foo = "Foo";
        WriteLine($"[{foo,10}]");  // [∙∙∙∙∙∙∙Foo]
        WriteLine($"[{foo,5}]");   // [∙∙Foo]
        WriteLine($"[{foo,-5}]");  // [Foo∙∙]
        WriteLine($"[{foo,-10}]"); // [Foo∙∙∙∙∙∙∙]

        const double tip = 52.23;
        WriteLine($"Bill:{tip,8}");
        WriteLine($"Bill:{tip}");
    }

    private int GetContents(ReadOnlySpan<char> span)
    {
        var slice = span[16..];
        return int.Parse(slice);
    }

    private void RangeSpan()
    {
        var array = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        var slice = new Span<int>(array, 2, 5);
        for (int i = 0; i < slice.Length; i++)
        {
            slice[i] *= 2;
        }

        foreach (var item in slice)
        {
            Write($"{item} ");
        }
    }

    private void WorkWithSpans()
    {
        // var o = Convert.ToDateTime("2023-05-22 오전 10:23");
        // var merge = $"{o:yyyyMMddhhmm}";
        // WriteLine(merge);
        // WriteLine(new DateTime(DateTime.Now.Ticks));

        // Create a span over an array
        var array = new byte[100];
        var span = new Span<byte>(array);
        InitializeSpan(span);
        WriteLine($"The over array sum is {ComputeSum(span):N0}");

        // Create an array from native memory
        var native = Marshal.AllocHGlobal(100);
        Span<byte> nativeSpan;
        unsafe
        {
            nativeSpan = new Span<byte>(native.ToPointer(), 100);
        }

        InitializeSpan(nativeSpan);
        WriteLine($"The native memory sum is {ComputeSum(span):N0}");
        Marshal.FreeHGlobal(native);

        // Create a span on the stack
        Span<byte> stackSpan = stackalloc byte[100];
        InitializeSpan(stackSpan);
        WriteLine($"The stack sum is {ComputeSum(span):N0}");
    }

    private void InitializeSpan(Span<byte> span)
    {
        byte val = 0;
        for (int i = 0; i < span.Length; i++)
        {
            span[i] = val++;
        }
    }

    public int ComputeSum(Span<byte> span)
    {
        int sum = 0;
        foreach (var item in span)
        {
            sum += item;
        }
        return sum;
    }

    private void StackAlloc()
    {
        byte data = 0;
        Span<byte> span = stackalloc byte[100];
        for (int i = 0; i < span.Length; i++)
        {
            span[i] = data++;
        }

        int sum = 0;
        foreach (var item in span)
        {
            sum += item;
        }
        WriteLine($"Stack Alloc sum = {sum}");
    }

    private void NativeMemory()
    {
        // Create a span from native memory
        var native = Marshal.AllocHGlobal(100);
        Span<byte> span;
        unsafe
        {
            span = new Span<byte>(native.ToPointer(), 100);
        }
        byte data = 0;
        for (int i = 0; i < span.Length; i++)
        {
            span[i] = data++;
        }

        int sum = 0;
        foreach (var item in span)
        {
            sum += item;
        }
        WriteLine($"native memory sum = {sum}");
        Marshal.FreeHGlobal(native);
    }

    private static void First()
    {
        // Create a span over an array.
        var array = new byte[100];
        var arraySpan = new Span<byte>(array);
        byte data = 0;
        for (int i = 0; i < arraySpan.Length; i++)
        {
            arraySpan[i] = data++;
        }

        int sum = 0;
        foreach (var item in arraySpan)
        {
            sum += item;
        }

        WriteLine($"sum = {sum}");
    }
}
