using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
