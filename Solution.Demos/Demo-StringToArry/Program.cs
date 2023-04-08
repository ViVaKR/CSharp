using System.Text.RegularExpressions;
namespace Demo_StringToArry;
public class Program
{

    public static void Main(string[] args)
    {
        var line = string.Join("", Enumerable.Repeat("-", 100));

        string inStr = "내가 그의 이름을 불러주기 전에는 그는 다만 하나의 몸짓에 지나지 않았다.\n";
        inStr += "내가 그의 이름을 불러주었을 때, 그는 내게로 와 꽃이 되었다.\n";
        inStr += "내가 그의 이름을 불러준 것처럼 나의 이 빛깔과 향기에 알맞는 누가 나의 이름을 불러다오.\n";
        inStr += "그에게로 가서 나도 그의 꽃이 되고 싶다.\n";
        inStr += "우리들은 모두 무엇이 되고 싶다.\n";
        inStr += "나는 너에게 너는 나에게 잊혀지지 않는 하나의 눈짓이 되고 싶다.";

        // (추가 문의 사항) 문자열(Word) 단위가 아닌 문자(sentence)로 출력하기
        // inStr 의 sentence 를 문자(charater array) 만들기를 진행합니다.

        // 원본
        Console.WriteLine("=== 원본 ===");
        Console.WriteLine(line);
        Console.WriteLine(inStr);
        Console.WriteLine();

        // 먼저 위 문장에서 모든 화이트스페이스 제거 하기 입니다. : Regular Expresstion -> `\s+`
        // 화이트스페이스 : Space, Tab, Line Feed, Form Feed, Carriage Return, Line TabUlation
        Console.WriteLine("=== 화이트스페이스 제거 ===");
        var removed = Regex.Replace(inStr, @"\s+", string.Empty);
        Console.WriteLine(removed);
        Console.WriteLine();
        
        // 문자 배열생성 후 정렬
        Console.WriteLine("=== 문자 배열생성 후 정렬 ===");
        var charArray = removed.ToCharArray();
        Array.Sort(charArray);
        Console.WriteLine(string.Join(string.Empty, charArray));
        Console.WriteLine(line);
        
        // 문자 단위로 그룹화 후 새로운 객체 생성 `{ 문자, 갯수 }`
        var groupChar = charArray.GroupBy(g => g).Select(s => new
        {
            문자 = s.Key,
            갯수 = s.Count()
        }).OrderByDescending(o=>o.갯수).ToList();
        Console.WriteLine();
        // 많은 갯수 부터 역방향으로 전체 출력하기
        Console.WriteLine("=== 많은 갯수 부터 역방향으로 전체 출력하기 ===");
        foreach (var ch in groupChar)
        {
            Console.WriteLine($"{ch.문자} - {ch.갯수}");
        }
        
        // 상위 5개 출력하기
        Console.WriteLine("=== 상위 5개 출력하기 ===");
        foreach (var ch in groupChar.Take(5))
        {
            Console.WriteLine($"{ch.문자} - {ch.갯수}");
        }
        Console.WriteLine(line);
    }
}

/* 출력결과 

=== 원본 ===
----------------------------------------------------------------------------------------------------
내가 그의 이름을 불러주기 전에는 그는 다만 하나의 몸짓에 지나지 않았다.
내가 그의 이름을 불러주었을 때, 그는 내게로 와 꽃이 되었다.
내가 그의 이름을 불러준 것처럼 나의 이 빛깔과 향기에 알맞는 누가 나의 이름을 불러다오.
그에게로 가서 나도 그의 꽃이 되고 싶다.
우리들은 모두 무엇이 되고 싶다.
나는 너에게 너는 나에게 잊혀지지 않는 하나의 눈짓이 되고 싶다.

=== 화이트스페이스 제거 ===
내가그의이름을불러주기전에는그는다만하나의몸짓에지나지않았다.내가그의이름을불러주었을때,그는내게로와꽃이되었다.내가그의이름을불러준것처럼나의이빛깔과향기에알맞는누가나의이름을불러다오.그에게로가서나도그의꽃이되고싶다.우리들은모두무엇이되고싶다.나는너에게너는나에게잊혀지지않는하나의눈짓이되고싶다.

=== 문자 배열생성 후 정렬 ===
,......가가가가가것게게게게고고고과그그그그그그그기기깔꽃꽃나나나나나나나나내내내내너너누눈는는는는는는는다다다다다다다도되되되되두들때러러러러럼로로름름름름리만맞모몸무불불불불빛서싶싶싶않않알았엇었었에에에에에에오와우은을을을을을의의의의의의의의이이이이이이이이이잊전주주준지지지지짓짓처하하향혀
----------------------------------------------------------------------------------------------------

=== 많은 갯수 부터 역방향으로 전체 출력하기 ===
이 - 9
나 - 8
의 - 8
그 - 7
는 - 7
다 - 7
. - 6
에 - 6
가 - 5
을 - 5
게 - 4
내 - 4
되 - 4
러 - 4
름 - 4
불 - 4
지 - 4
고 - 3
싶 - 3
기 - 2
꽃 - 2
너 - 2
로 - 2
않 - 2
었 - 2
주 - 2
짓 - 2
하 - 2
, - 1
것 - 1
과 - 1
깔 - 1
누 - 1
눈 - 1
도 - 1
두 - 1
들 - 1
때 - 1
럼 - 1
리 - 1
만 - 1
맞 - 1
모 - 1
몸 - 1
무 - 1
빛 - 1
서 - 1
알 - 1
았 - 1
엇 - 1
오 - 1
와 - 1
우 - 1
은 - 1
잊 - 1
전 - 1
준 - 1
처 - 1
향 - 1
혀 - 1
=== 상위 5개 출력하기 ===
이 - 9
나 - 8
의 - 8
그 - 7
는 - 7
----------------------------------------------------------------------------------------------------
*/
