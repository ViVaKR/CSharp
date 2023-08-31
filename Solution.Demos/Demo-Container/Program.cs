using System.Runtime.InteropServices;
using Demo_Container;

//! 컬렉션

//? IList : List<T>, Array, ArrayList
//? IDictionary : Hashtable, SortedList, SortedList, Dictonary<Key, Value> 
//? ICollection : Queue<T>, Stack, Stack<T>

// IEnumerable<T> for generic collections  : 고유한 타입, List<T>

// IEnumerable for non generic collections : 다양한 타입, ArrayList



{
    var Longitude = 12.345;
    var age = 34;
    var title = "Hi";

    string message = $$"""
    This is a long message.
    It has {{{Longitude}}}several {{title}}lines.
        Some are indexted {{age}}
            more than others. "quoted text"
    """;
    Console.WriteLine(message);
}

//*** stackalloc ***//
// 스택에 메모리 블록을 할당
// 자동삭제됨으로 명시적으로 해제할 수 없음
// 가비지 수집 비적용, fixed 문을 사용해서 고정하지 않아도 됨
// 스택 할당 메모리로 작업시에는 Span<T> 또는 ReadOnlySpan<T> 권장
{
    int length = 3;
    Span<int> numbers = stackalloc int[length];
    for (int i = 0; i < length; i++)
    {
        numbers[i] = i * 10;
    }

    numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
    var ind = numbers.IndexOfAny(stackalloc[] { 4, 6, 7 });
    Console.WriteLine(ind);
}

// Span
// 좋은 성능
// 읽기전용 (ReadOnlySpan) 완비
// System Array, Stack Array, Heap 대해서도 이용가능
// Indexer 사용가능
// 
{
    var array = new int[] { 0, 1, 2, 3, 4, 5, 6 };
    var span = new Span<int>(array);
    Console.WriteLine(span[1]);
    Console.WriteLine(span.Slice(2)[3]);

    var floatArray = new float[] { 3.14f, 5.25f };
    Span<float> bufferAsFloat = new Span<float>(floatArray);
    span = MemoryMarshal.Cast<float, int>(bufferAsFloat);
}

unsafe
{
    int length = 3;
    int* numbers = stackalloc int[length];

    for (int i = 0; i < length; i++)
    {
        numbers[i] = 1 + 11;
    }

    int* pLength = &length;
    *pLength = 10;

    Console.WriteLine($"Address : {numbers[0]} - {(long)numbers:X} - {(long)pLength:X} - {length} - {*pLength}");

    byte[] bytes = { 1, 2, 3 };
    fixed (byte* pb = bytes)
    {
        Console.WriteLine(pb[1]);
    }

    int[] ss = { 1, 2, 3, 4, };
}

// ?: - 3차 조건부 연산자 
