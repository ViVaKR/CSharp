using System.Numerics;
using System.Text.RegularExpressions;
using BigIntManager;


// 문의에 대한 답변 테스트 코드
string  numberString = "10A";
Console.WriteLine($"Orgin\t\t=>\t{numberString}");
Console.WriteLine($"Converted\t=>\t{numberString.ToBigInt()}");
Console.WriteLine();

numberString = "25B";
Console.WriteLine($"Orgin\t\t=>\t{numberString}");
Console.WriteLine($"Converted\t=>\t{numberString.ToBigInt()}");
Console.WriteLine();

numberString = "1.2A";
Console.WriteLine($"Orgin\t\t=>\t{numberString}");
Console.WriteLine($"Converted\t=>\t{numberString.ToBigInt()}");
Console.WriteLine();

numberString = "1.24A";
Console.WriteLine($"Orgin\t\t=>\t{numberString}");
Console.WriteLine($"Converted\t=>\t{numberString.ToBigInt()}");
Console.WriteLine();

numberString = "478B";
Console.WriteLine($"Orgin\t\t=>\t{numberString}");
Console.WriteLine($"Converted\t=>\t{numberString.ToBigInt()}");
Console.WriteLine();

numberString = "5.25C";
Console.WriteLine($"Orgin\t\t=>\t{numberString}");
Console.WriteLine($"Converted\t=>\t{numberString.ToBigInt()}");
Console.WriteLine();


// 엄청나게 큰수로 테스트 해보기
// A 부터 Z 까지 접미사 붙이며 1000 ^ index + 1 Pow 연산 확인용
BigInteger bigIntFromDouble = new BigInteger(179032.6541);
numberString = "1234567898765432.34562323423424234234";
for (char c = 'A'; c <= 'Z'; c++)
{
    var str = $"{numberString}{c.ToString()}";
    Console.WriteLine($"Orgin\t\t=>\t{str}");
    Console.WriteLine($"Converted\t=>\t{str.ToBigInt()}");
    Console.WriteLine();
}


