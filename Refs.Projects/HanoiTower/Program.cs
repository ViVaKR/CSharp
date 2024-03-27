using System.Numerics;
using HanoiTower;

internal class Program
{
    // 시작 포인트...
    private static void Main()
    {
        // 1. 콜 스택 (1)
        Run(1);
    }

    static void Run(int choice)
    {
        switch (choice)
        {
            // 2. 콜 스택 (2)
            case 1: RunHanoi(); break; // 하노이 타워

            case 2: RunDifferentiation(); break; // 미분
            case 3: // 이진탐색
                {
                    // 이진 탐색
                    int[] arr = { 1, 2, 3, 4, 6, 7, 8, 11, 14, 15, 16, 18, 19 };
                    Array.Sort(arr);
                    int result = SearchValue(arr, 0, arr.Length - 1, 14);
                    Console.WriteLine(result == -1 ? "not found" : $"index: {result}, value: {arr[result]}");
                    for (int i = 3; i < 10; i++)
                    {
                        BigInteger factorial = Factorial(i);
                        Console.WriteLine($"{factorial:N0} - 자릿수 => ( {factorial.ToString().Length} )");
                    }
                }
                break;
            case 4: Console.WriteLine($"피보나치 : {Fibonachi(40)}"); break;
            case 5:
                {
                    string[] words = new string[]
                    {
                                    // index from start    index from end
                        "The",      // 0                   ^9
                        "quick",    // 1                   ^8
                        "brown",    // 2                   ^7
                        "fox",      // 3                   ^6
                        "jumps",    // 4                   ^5
                        "over",     // 5                   ^4
                        "the",      // 6                   ^3
                        "lazy",     // 7                   ^2
                        "dog"       // 8                   ^1
                    };              // 9 (or words.Length) ^0
                    Index the = ^3;
                    Console.WriteLine(words[the]);
                    Range range = 1..4;
                    var text = words[range];
                    foreach (var item in text)
                    {
                        Console.WriteLine(item);
                    }

                    int[] numbers = Enumerable.Range(0, 100).ToArray();
                    int x = 12;
                    int y = 25;
                    int z = 36;
                    int k = numbers.Length / 2;

                    Console.WriteLine($"{numbers[^x]} == {numbers[numbers.Length - x]}");
                    Span<int> x_y = numbers.AsSpan()[x..y];
                    Span<int> y_z = numbers.AsSpan()[y..z];

                    Console.WriteLine($"numbers[x..y] is {x_y[0]} through {x_y[^1]}, numbers[y..z] is {y_z[0]} through {y_z[^1]}");

                    Console.WriteLine(string.Join(",", numbers[..k]));
                    Console.WriteLine(string.Join(",", numbers[k..]));
                }
                break;
            case 6: // 파일 탐색
                {
                    (long, int) tuple = GetFileSize(@"/Users/vivakr/Temp/TypeScript/Snippets");
                    Console.WriteLine($"{Math.Round((double)tuple.Item1 / 1000):N1} KB - {tuple.Item2}");
                };
                break;
            case 7:
                {
                    int[] array = { 5, 3, 6, 9, 3, 1, 7, 2 };

                    Span<int> sarr = new(new[] { 5, 3, 6, 9, 3, 1, 7, 2 });
                }; break;
            case 8:
                {

                }
                break;
            default: break;
        }
    }

    static long size = 0;
    static int count = 0;
    static (long, int) GetFileSize(string dir)
    {

        DirectoryInfo di = new(dir);
        FileInfo[] fis = di.GetFiles();

        count += fis.Length;

        foreach (var file in fis)
        {
            size += file.Length;
        }

        DirectoryInfo[] subDir = di.GetDirectories();
        count += subDir.Length;
        foreach (var directory in subDir)
        {
            GetFileSize(directory.FullName);
        }
        return (size, count);
    }

    /* Merge Sort 
        * Split it into two parts
        * Sort the left part
        * Sort the right part
        * Join Parts into a sorted array
    */

    // static Span<int> MergeSort(Span<int> arr)
    // {
    //     if(arr.Length <= 1) return arr;

    //     int mid = arr.Length / 2;
    //     Span<int> left = arr[..mid];
    //     Span<int> right = arr[mid..];
    //     left = MergeSort(left);
    //     right = MergeSort(left);

    //     return 
    // }

    static readonly BigInteger[] fibs = new BigInteger[1024];
    /// <summary>
    /// 피보나치 (동적프로그래밍의 대표적 사례)
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns> <summary>
    static BigInteger Fibonachi(int number)
    {
        if (fibs[number] != 0) return fibs[number]; // 계산한 적이 있다면

        return
        (number == 1 || number == 2)
        ? fibs[number] = 1
        : fibs[number] = Fibonachi(number - 1) + Fibonachi(number - 2);
    }

    /// <summary>
    /// 팩토리얼
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    static BigInteger Factorial(int number)
    {
        // 5 * 4 * 3 * 2 * 1 = 120; 
        return number == 1 ? 1 : number * Factorial(number - 1);

    }

    /// <summary>
    /// Binary Search
    /// </summary>
    /// <param name="array"></param>
    /// <param name="startIdx"></param>
    /// <param name="endIdx"></param>
    /// <param name="search"></param>
    /// <returns></returns>
    static int SearchValue(int[] array, int startIdx, int endIdx, int search)
    {
        if (startIdx > endIdx) return -1;
        int mid = (startIdx + endIdx) / 2;
        if (array[mid] == search) return mid;
        if (array[mid] > search)
        {
            return SearchValue(array, startIdx, mid - 1, search);
        }
        else
        {
            return SearchValue(array, mid + 1, endIdx, search);
        }
    }

    // 미분할 함수를 정의합니다. 이 예시에서는 f(x) = x^2입니다.
    static double Function(double x)
    {
        return x * x;
    }

    // 수치 미분을 수행하는 함수를 정의합니다.
    static double NumericalDifferentiation(Func<double, double> function, double x, double h)
    {
        double derivative = (function(x + h) - function(x)) / h;
        return derivative;
    }

    static void RunDifferentiation()
    {
        double x = 9; // 미분을 수행할 점 x
        double h = 0.0001; // 작은 변화량

        double derivative = NumericalDifferentiation(Function, x, h);

        Console.WriteLine($"f'({x}) = {derivative}");
    }

    static void RunHanoi()
    {
        // 판 3종 (A, B, C) 초기화
        var start = new Pile(PileType.Start); // A
        var end = new Pile(PileType.End); // B
        var temp = new Pile(PileType.Temp); // C

        Console.Clear();

        Console.Write("판의 갯수를 넣어주세요: ");

        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        // 판 묶음 딕셔너리 구성
        var dic = new Dictionary<PileType, Pile>
        {
            {PileType.Start, start},
            {PileType.Temp, temp},
            {PileType.End, end}
        };

        // 3. 콜스택 (3)
        _ = new TowerOfHanoi(dic, n);
    }


}


/* 
    - 상수 : O(1)
    - For Loop : O(N)
    - Nested For Loop : O(N^2)
    - 이진탐색 : O(log N), 2^n = 32 What is ?n -> (5) <- 2 * 2 * 2 * 2 * 2 = 32
    ? 이진탐색과 같은 점 -> 2로 몇번을 나누어야 1이 나오는가 (로그 밑 2 = 32)
    ! 32 / 2 = 16
    ! 16 / 2 = 8
    ! 8 / 2 = 4
    ! 4 / 2 = 2
    ! 2 / 2 = 1

 */

/* 
    1. Source
    2. Auxiliary
    3. Destination
    
    * 기본 호출
    * 재귀 호출
 */

/* 
    1. push : to add an element on top of the stack
    2. pop : to remove the element on top of the stack
    3. peek : to get the value of the element on top of the stack
    4. isEmpty : to check if the stack is empty
    5. isFull : to check if the stack is full
 */
