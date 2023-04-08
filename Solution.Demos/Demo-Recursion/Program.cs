var rec = new Recursion();

// 2진수로 변환
string? b = rec?.DecimalToBinary(253, string.Empty);
Console.WriteLine(b);

// Sum of Natural Numbers, 자연수의 합
Console.WriteLine(rec?.SumOfNaturalNumbers(10));

// Divide & Conquer, 큰 문제를 작은 문제로 나눔


// Binary Search (이진검색)
// 이진검색의 목적 : 배열에서 값을 찾고자 하는 값을 찾는 것
var a = new int[] { -1, 0, 1, 2, 3, 4, 7, 9, 10, 20 };

int? result = rec?.BinarySearch(a, 0, 10, 7);
Console.WriteLine(result);

/// <summary>
/// 재귀함수를 통한 2 진수변화
/// </summary>\
public class Recursion
{
    public int BinarySearch(int[] A, int left, int right, int x)
    {
        if(left > right) return -1;

        int mid = (left + right) / 2;
        
        if (x == A[mid]) return mid;
        
        if (x < A[mid]) return BinarySearch(A, left, mid - 1, x);

        return BinarySearch(A, mid + 1, right, x);
    }

    /// <summary>
    /// 자연수의 합계 구하기
    /// </summary>
    /// <param name="inputNumber"></param>
    /// <returns></returns>
    public int SumOfNaturalNumbers(int inputNumber)
    {
        if (inputNumber <= 1) return inputNumber;
        return SumOfNaturalNumbers(inputNumber - 1) + inputNumber;
    }

    /// <summary>
    /// 2진수 변화
    /// </summary>
    /// <param name="number"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public string? DecimalToBinary(int number, string result)
    {
        if (number == 0) return result;

        result = (number % 2) + result;
        return DecimalToBinary(number / 2, result);
    }
}


