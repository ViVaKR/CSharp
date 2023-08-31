namespace DemoStatic;
public static class A
{
    private static int[] a = Array.Empty<int>();
    private static int[] b = Array.Empty<int>();

    private static int ivalue = 27;

    public static void Struct()
    {
        unsafe
        {
            // 원본
            fixed (int* pi = &ivalue)
            {
                Console.WriteLine($"int address -> {ivalue}, {(long)pi:X}");
            }

            // 값 변경후
            ivalue = 55;
            fixed (int* pi = &ivalue)
            {
                Console.WriteLine($"int address -> {ivalue}, {(long)pi:X}");
            }
        }
    }

    public static void A_1()
    {
        a = new[] { 1, 2, 3 };
        b = a; // 복사
        PrintAddress("1. ");
    }

    public static void A_2()
    {
        a = new[] { 10, 20, 30 };
        PrintAddress("2. ");
    }

    // 참조형식 인스턴스 테스트 출력
    public static void PrintAddress(string prefix)
    {
        Console.WriteLine();

        unsafe
        {
            fixed (int* pa = &a[0]) // array a 시작 주소
            {
                Console.WriteLine($"{prefix} &a[0] address -> {(long)pa}, {(long)pa:X}");
                Console.WriteLine($"{prefix} &a[0] value -> {string.Join(", ", *pa)}");
            }
            fixed (int* pb = &b[0]) // array b 시작주소
            {
                Console.WriteLine($"{prefix} &b[0] address -> {(long)pb}, {(long)pb:X}");
                Console.WriteLine($"{prefix} &b[0] value -> {string.Join(", ", b)}");
            }
        }
        Console.WriteLine();
    }
}

/* 

483456718898

440360202536

                int[] a = new int[] { 1, 2, 3 };

                // &a[0] - Address of the first element
                IntPtr addressOfFirstElement = (IntPtr)pa;
                // &a - Address of the array itself

                Console.WriteLine($"First : {addressOfFirstElement:X}"); // Prints the address of the first element
                Console.WriteLine($"It Self : {}"); // Prints the address of the array itself
 */
