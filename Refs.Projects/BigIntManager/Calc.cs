using System.Numerics;
using System.Text;

namespace BigIntManager;
public static class Calc
{
    // 기본 자릿수
    const int digit = 1000; // A 부터 Z 까지 단계별로 Pow 연산용

    // 알파벳 대문자 목록 구성 초기화
    private static List<char> charList
    = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList();

    /// <summary>
    /// 확장 메서드
    /// 소숫점 이하 자릿수 무제한
    /// 호출 사용 -> "숫자+알파벳 문자열".ToBigInt();
    /// </summary>
    /// <param name="num">알파벳이 포함된 매우 소숫점 수</param>
    /// <returns></returns>
    public static BigInteger ToBigInt(this string num)
    {
        if (string.IsNullOrEmpty(num)) return 0;

        // 끝에 포함된 문자 추출 (A  ~ Z)
        var tailChar = num.ToCharArray()[^1];
        var numberCharArray = num.ToCharArray()[..^1];

        // 소숫점이 없으면 배열 널 처리
        string[]? numArray = num.Any(x => x == '.') ? num.Split(new char[] { '.' }) : null;

        // 끝에 붙은 문자 문자 처리
        var item = charList.FirstOrDefault(x => x == tailChar);

        // 접미사로 붙은 문자의 인덱스가져오기 
        var index = charList.IndexOf(item) + 1;

        // 문자가 없으면 그대로 반환
        if(index < 0) return BigInteger.Parse(num);

        BigInteger overZero = 0;

        // 소수점이 있을 때
        if (numArray != null)
        {
            bool tf = BigInteger.TryParse(numArray[0], out overZero);
            if (!tf) return 0;
            var underZero = BigInteger.Parse(numArray[1][..^1]); // 0 이하 큰수
            var tail = $"{(underZero * BigInteger.Pow(digit, index + 1) / 10)}";

            // (예): A 일경우 -> index -> 1 이므로 -> 1_000 3자리에서 -> 소숫점이므로 -1 -> 2가 됨)
            var lessThanZero = tail[..(index + digit.ToString().Length - 1)];
            return BigInteger.Parse($"{overZero}{lessThanZero}");
        }

        // 소수점 없는 정수일 경우
        var onlyOverZero = $"{BigInteger.Parse(num.ToCharArray()[..^1]) * BigInteger.Pow(digit, index )}";
        return BigInteger.Parse($"{onlyOverZero}");

    }
}
