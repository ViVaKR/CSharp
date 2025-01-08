Console.WriteLine("=== I Want to Know That Ref Start===");

var x = 3;
var y = 4;

unsafe
{
    var ptr = &x;
    Console.WriteLine((IntPtr)ptr);
    Console.WriteLine(*ptr);
}
Swap(ref x, ref y);
return;

static void Swap(ref int a, ref int b) // ref int a, b 는 메모리 주소를 전달 하고 있다.
{
    /*
     * static Swap 함수 내부에서 fixed가 필요한 이유는 ref 매개변수의 주소를 가져오기 위함이고,
     * ref 매개변수는 스택에 저장되지만,
     * 객체일 경우에는 가비지 컬렉터에 의해 이동될 수 있는 힙에 있는 객체를 참조할 수 있음으로,
     * fixed 문을 사용하여  해당 변수의 주소를 고정하여 C# 에서 포인터를 안전하게 사용할 수 있기 때문에 사용함.
     */
    unsafe
    {
        fixed (int* ptr = &a, ptr2 = &b)
        {
            Console.Write("ptr: a address: ");
            Console.WriteLine($"{(IntPtr)ptr:X}");

            Console.Write("ptr2: b address: ");
            Console.WriteLine($"{(IntPtr)ptr2:X}");

            Console.Write("ptr: a value: ");
            Console.WriteLine(*ptr);
        }
        Console.WriteLine($"a: {a}, b: {b}");
        // int temp = a; // 여기서 a 는 x 의 값을 가지고 있음으로, C# 에서는 ref 키워드를 통해 전달된 변수는 직접 접근할 수 있기 때문에 * 연산자를 사용할 필요가 없음.
        // a = b;
        // b = temp;
        // Console.WriteLine($"inside => a: {a}, b: {b}");
    }

    Console.WriteLine($"outside => a: {a}, b: {b}");
    (a, b) = (b, a); // 구조분해
}

