using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Demo_RegEx
{
    public class RexExample
    {
        public void RegexEx1()
        {
            string str = "<P0><![CDATA[]>999]9>99]]></P0><P1><![CDATA[a1(23)4]]></P1> <P2><![CDATA[abcd!!ef]]></P2> <P3><![CDATA[ddddd]]></P3>";

            var pattern = @"<!\s*\[CDATA\s*\[(?<item>(?>[^]]+|](?!]>))*)]]>";

            MatchCollection matchList = Regex.Matches(str, pattern);
            var list = matchList.Cast<Match>().Select(match => match.Groups["item"].Value).ToList();

            foreach (var item in list)
            {
                System.Console.WriteLine(item);
                // afajlsdfjSDKFL_._JASFL;234_0234809284.
            }
        }

        public void RegexEx2()
        {
            string text = "The the quick brown fox  fox jumps over the lazy dog dog.";
            Regex rx = new Regex(@"(\w)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            foreach (Match item in rx.Matches(text))
            {
                System.Console.WriteLine(item.Groups[1].Value);
            }

            rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(text);

            Console.WriteLine($"{matches.Count} matches found in:\n  {text}");

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine($"'{groups["word"].Value}' repeated at positions {groups[0].Index} and {groups[1].Index}");
            }
        }

        public void RegexEx3()
        {

            string pattern = @"(\s|^)Tim(\s|$)"; // 앞에 공백 또는 Tim 으로 시작 하고 Tim 으로 끝나거나 뒤에 공백이 있는 것
            string toSearch = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.txt"));

            // 숫자로 3자리-4자리-4자리 로구성되며 대쉬가 있어도 되고 없어도됨, 대쉬 또는 점
            pattern = @"\(?\d{3}\)?(-|.|\s)?\d{4}(-|.)?\d{4}";
            pattern = @"\d{6}-?\d{7}";
            pattern = @"\w+\.?\w+\.?\w+@\w+\.\w+";
            pattern = @"(\S+)\w+.?\w+.?\w+@\w+.\w+.?\w+.?\w+\b";
            pattern = @"quos\s+";

            // ^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$
            MatchCollection mc = Regex.Matches(toSearch, pattern);

            Console.WriteLine(mc.Count);

            Console.WriteLine("Tim Corey: " + Regex.IsMatch("Tim Corey", pattern));
            Console.WriteLine("Timothy Corey: " + Regex.IsMatch("Timothy Corey", pattern));
            Console.WriteLine("Always Tim: " + Regex.IsMatch("Always Tim", pattern));
            Console.WriteLine("I Am Tim Corey: " + Regex.IsMatch("I Am Tim Corey", pattern));

            // 프리컴파일 속도 점검
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Regex regex = new Regex(pattern, RegexOptions.Compiled); // pre Compiled

            for (int i = 0; i < 100000; i++)
            {
                regex.IsMatch("I Am Tim Corey");
            }
            watch.Stop();
            Console.WriteLine($"Time Elapsed in ms: {watch.ElapsedMilliseconds}");


            Regex rx = new Regex(@"\bwhatever\b");
            rx = new Regex(@"\d+\s*GBP");
            rx = new Regex(@"Console\.Write(Line)");

            string test = "The the quick brown fox  fox jumps over the lazy dog dog and fox or the";
            rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(test);
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine($"{groups["word"].Value} - {groups[0].Index} - {groups[1].Index}");
            }

            Print();
        }

        private static void Print()
        {
            const string words = "(212)-111-1111, (010)-8877-8947, (010) (0123) (239399239293)";
            Regex regex = new Regex(@"(\(\d{3,}\))");

            Match match = regex.Match(words);
            Console.WriteLine();
            Console.WriteLine("Groups");
            foreach (var group in match.Groups)
            {
                Console.WriteLine(group);
            }
        }
    }
}
