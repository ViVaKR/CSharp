namespace Namespace;

public static class DemoStatic
{
    // 배열 원본
    public static int[] a;

    // 배열 복사 대상
    public static int[] b;

    public static void Main()
    {
        a = new[] { 1, 2, 3, 4, 5 };
        b = a; // Shallow Copy (배열 얕은복사)

        TestStatic();
    }
    //- hello
    

    /// <summary>
    /// View Memory State
    /// </summary>
    public static void TestStatic()
    {
        Console.WriteLine();

        //* [ 원본 배열 ]
        unsafe
        {
            // 배열의 첫번째 요소의 주소 (배열의 첫번째 값 주소저장)
            fixed (int* p = &a[0])
                Console.WriteLine($"1. 원본 배열 a 첫번째 요소 주소지 : {(long)p:X}");

            // 배열 자체 포인터 (배열 자체의 주소를 저장)
            fixed (int* p = a)
                Console.WriteLine($"1. 원본 배열 a 자체 주소지 : {(long)&p:X}, 값 *(p + 1) => {*(p + 1)}");
        }

        Console.WriteLine();

        //* [ 배열 복사 (얕은, Shellow Copy)]
        unsafe
        {
            fixed (int* p = &b[0]) // 배열의 첫번째 요소의 주소 (배열의 첫번째 값 주소저장)
                Console.WriteLine($"2. 복사 배열 b 첫번째 요소 주소지 : {(long)p:X}");

            fixed (int* p = b) // 배열 자체 포인터 (배열 자체의 주소를 저장)
                Console.WriteLine($"2. 복사 배열 b 자체 주소지 : {(long)&p:X}, 값 *(p + 1) => {*(p + 1)}");
        }

        Console.WriteLine();

        //* [ 배열 동일 변수 새로운 인스턴스 ]
        unsafe
        {
            a = new[] { 10, 20, 30, 40, 50 };

            // 배열의 첫번째 요소의 주소 (배열의 첫번째 값 주소저장)
            fixed (int* p = &a[0])
                Console.WriteLine($"3. 신규 배열 a 첫번째 요소 주소지 : {(long)p:X}");

            // 배열 자체 포인터 (배열 자체의 주소를 저장)
            fixed (int* p = a)
                Console.WriteLine($"3. 신규 배열 a 자체 주소지 : {(long)&p:X}, 값 *(p + 1) => {*(p + 1)}");
        }
        Console.WriteLine();
    }
}
