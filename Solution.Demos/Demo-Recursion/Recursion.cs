namespace Demo_Recursion;

/// <summary>
/// 재귀함수 모음
/// </summary>\
public class Recursion
{
    /// <summary>
    /// 병합정렬
    /// </summary>
    /// <param name="data">배열 데이터</param>
    /// <param name="start">시작 인덱스</param>
    /// <param name="end">마지막 인덱스</param>
    public void MergeSort(int[] data, int start, int end)
    {
        if (start < end)
        {
            int mid = (start + end) / 2;
            MergeSort(data, start, mid);
            MergeSort(data, mid + 1, end);
            Merge(data, start, mid, end);
        }
    }

    public void Merge(int[] data, int start, int mid, int end)
    {
        // build temp array to avoid modifying the original contents
        int[] temp = new int[end - start + 1];
        int i = start, j = mid + 1, k = 0;

        // While both sub-array have values,
        // then try and merge then in sorted order
        while (i <= mid && j <= end)
        {
            if (data[i] <= data[j])
            {
                temp[k++] = data[i++];
            }
            else
            {
                temp[k++] = data[j++];
            }
        }

        // Add the rest of the values from the left sub-array into the result
        while (i <= mid)
        {
            temp[k] = data[i];
            k++; i++;
        }

        // Add the rest of the values from the sub-array into the result
        while (j <= end)
        {
            temp[k] = data[j];
            k++; j++;
        }

        for (i = start; i <= end; i++)
        {
            data[i] = temp[i - start];
        }
    }

    /* 피보나치 수열 : 첫 번째 항과 두 번째 항이 모두 1이고 그 이후의 항은 각 항이 앞의 두 항의 합인 수열
    1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903, 2971215073, 4807526976, 7778742049, 12586269025, 20365011074, 32951280099, 53316291173, 86267571272, 139583862445, 225851433717, 365435296162, 591286729879, 956722026041, 1548008755920, 2504730781961, 4052739537881, 6557470319842, 10610209857723, 17167680177565, 27777889035288, 44945569212853, 72723458248141, 117668927460994, 190392385709135, 308061313170129, 498453698879264, 806515012049393, 1304968710928657, 2111483722978050, 3416452433906707, 5527936156884757, 8944388590791464, 14472324747676221, 23416713338467685, 37889038086143906, 61305751424611591, 99194789510755497, 160500540935367088, 259695320446122585, 420195861381489673, 6798911818
     */

    /// <summary>
    /// 피보나치 수열 (최적화 되지 않은 방식)
    /// 중복된 호출이 다수 발생하는 문제점이 있음
    /// 최적화 -> 메모이제이션, Merge Sort.
    /// </summary>
    /// <param name="n">최종 수</param>
    /// <returns>수열의 합</returns>
    public long Fibonacci(long n)
    {
        if (n == 0 || n == 1) return n;
        else return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    /// <summary>
    /// 1 부터 input 까지 더하기
    /// </summary>
    /// <param name="input">최대수</param>
    /// <returns> 1 부터 input 까지의 합계</returns>
    public int Summation(int input)
    {
        if (input <= 1) return input;
        return input + Summation(input - 1);
    }

    /// <summary>
    /// 2진수 변환기
    /// </summary>
    /// <param name="number">10진수</param>
    /// <returns>2진수</returns>
    public string NumberToBinary(int number, string binary)
    {
        if (number == 0) return binary;

        binary = (number % 2).ToString() + binary;

        return NumberToBinary(number / 2, binary);

        // 233 / 2 = 116    rem = 1
        // 116 / 2 = 58     rem = 0
        // 58 / 2 = 29      rem = 0
        // 29 / 2 = 14      rem = 1
        // 14 / 2 = 7       rem = 0
        // 7 / 2 = 3        rem = 1
        // 3 / 2 = 1        rem = 1
        // 1 / 2 = 0        rem = 1

        //! (233) => 1 1 1 0 1 0 0 1
    }


    /// <summary>
    /// 앞뒤로 같은 문장 여부 판단 (회전문)
    /// 앞뒤에서 중앙으로 축소해들어감
    /// </summary>
    /// <param name="input">kayak</param>
    public bool Palindrome(string input)
    {
        // base-case / stopping condition
        if (input.Length == 0 || input.Length == 1)
            return true;

        // Do some work to shrink the problem space.
        Console.WriteLine(input[0] + " " + input[^1]);
        if (input[0] == input[^1])
            return Palindrome(input[1..^1]);

        // Additional base-case to handle non-palindromes
        return false;
    }

    /// <summary>
    /// String Reversal
    /// </summary>
    /// <param name="input">the simple engineer</param>
    /// <returns>reenigne elpmis eht</returns>
    public string ReverseString(string input)
    {
        // What is the base case?
        // When can I no longer continue?
        // 빈문자열이 때가 가장 작은 단위 이므로 기본으로 함.
        if (string.IsNullOrEmpty(input)) return string.Empty;

        // What is the samllest amount of work I can do in each iteration?
        // Between each invocation, what's the small "unit" I can reverse?
        // -> 전체 문장 중에서 앞문자를 제외하면서 호출 + 앞문자를 뒤에 붙임
        //     ( Shrinks the problem space )       ( Smallest unit of work to contribute )
        return ReverseString(input.Substring(1)) + input[0];

        //? ( Call Stack )

        // (5) | ReverseString("") + "o" |  o           (6)
        // (4) | ReverseString("o") + "l" |  ol         (7)
        // (3) | ReverseString("lo") + "l" |  oll       (8)
        // (2) | ReverseString("llo") + "e" |  olle     (9)
        // (1) | ReverseString("ello") + "h" |  olleh   (10)

        //! input: "hello",  Call -> ReverseString("hello");
    }

    public int RecursionA(int num)
    {
        if (num == 10) return 10;
        return RecursionA(num + 1);
    }

    /// <summary>
    /// 이진탐색
    /// </summary>
    /// <param name="A">배열</param>
    /// <param name="left">찾을 첫번째 인덱스</param>
    /// <param name="right">찾을 마지막 인덱스</param>
    /// <param name="x">찾을 값</param>
    /// <returns>찾은 인덱스번호</returns>
    public int BinarySearch(int[] A, int left, int right, int x)
    {
        // 종료조건 : 시작인덱스가 마지막 인덱스 보다 클때
        // 즉 없을 때
        if (left > right) return -1;

        // 배열을 반으로 나눔
        int mid = (left + right) / 2;

        // 찾을 값과 배열의 중앙값을 비교
        if (x == A[mid]) return mid;

        // 찾을 값이 중간보다 작으면 중앙 왼쪽에 있음을 의미
        // 배열을 우측 인덱스을 하나씩 줄이면서 재귀
        if (x < A[mid]) return BinarySearch(A, left, mid - 1, x);

        // 찾을 값이 크면 중앙 오른쪽에 있음을 의미
        // 배열의 좌측 인덱스를 하나씩 늘리면서 재귀
        return BinarySearch(A, mid + 1, right, x);
    }

    /// <summary>
    /// 자연수의 합계 구하기
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public int SumOfNumbers(int number)
    {
        if (number <= 1) return number;
        return SumOfNumbers(number - 1) + number;
    }

    /// <summary>
    /// 2진수 변화
    /// </summary>
    /// <param name="number"></param>
    /// <param name="result"></param>
    /// <returns>number 의 2진수</returns>
    public string? DecimalToBinary(int number, string result)
    {
        if (number == 0) return result;

        result = (number % 2) + result;
        return DecimalToBinary(number / 2, result);
    }
}
