using System.Diagnostics;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
/*
 * ^    - Start with
 * $    - Ends with
 * []   - Range
 * ()   - Group
 * .    - Single characters once
 * +    - one or more characters in a row
 * ?    - optional preceding character match
 * \    - escape charater
 * \n   - New line
 * \d   - Digit
 * \D   - Non-digit
 * \s   - White space
 * \S   - non-white space
 * \w   - aplhanumeric / underscore character (word chars)
 * \W   - non-word characters
 * {x,y}- Repeat low (x) to high (y) 
 * (x|y)- Alternative - x or y
 * [^x] - Anything but x (where x is whatever character you want)
 */

// Pattern List
string pattern = "Viv";
pattern = "[Vv]iv";
pattern = "^Viv";
pattern = @"\sViv\s"; 
pattern = @"\sViv"; 
pattern = @"(\s|^)Viv(\s|$)"; // Viv 앞에 공백 또는 Viv 로 시작, Viv 뒤에 공백이 있거나 Viv 로 끝남
pattern = @"(\s|^)Viv(\s|$)";

// Test List
// Console.WriteLine("Viv Hello => " + Regex.IsMatch("Viv Hello", pattern, RegexOptions.IgnoreCase));
// Console.WriteLine("VivaKR Hello => " + Regex.IsMatch("VivaKR Hello", pattern));
// Console.WriteLine("Hello Vivakr World => " + Regex.IsMatch("Hello Vivakr World", pattern));
// Console.WriteLine("I am Viv akr World => " + Regex.IsMatch("Hello Viv akr World", pattern));
// Console.WriteLine("I am Viv akr World => " + Regex.IsMatch("HelloViv akr World", pattern));
// Console.WriteLine("I am Viv akr World => " + Regex.IsMatch("I Am Viv KR", pattern));


/* 성능 테스트
var test = new Regex(pattern, RegexOptions.Compiled); // 프리컴파일
Stopwatch watch = new Stopwatch();
watch.Start();
for (int i = 0; i < 100_000; i++)
{
    // Regex.IsMatch("I Am Viv KR", pattern); // 47ms
    test.IsMatch("I Am Viv KR"); // 13ms
}
watch.Stop();
Console.WriteLine($"Time Elapsed in ms: {watch.ElapsedMilliseconds}");
*/
