

using Bank;

BankAccount ba = new("Kim Bum Jun", 358_000);

ba.Creit(100_000);
ba.Debit(50_000);
Console.WriteLine($"Customer: {ba.CustomerName}, Balance: {ba.Balance:N2}");

HelloWorld.SayHello();


using var sw = new StringWriter();
var orginalOut = Console.Out; // 기존 콘솔 출력을 백업
Console.SetOut(sw); // 콘솔 출력을 StringWriter로 변경
Console.WriteLine("Hi, Everyone"); // 콘솔 출력
var result = sw.ToString().Trim(); // StringWriter의 내용을 가져옴
Console.SetOut(orginalOut); // 콘솔 출력을 원래대로 복원
Console.WriteLine(result); // 콘솔 출력


var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "log.txt");

using var stream = new StreamWriter(logFilePath);
Console.SetOut(stream);
Console.WriteLine("Logging some information to a file");


/*
--> log
using var sw = new StringWriter();
var originalOut = Console.Out;
Console.SetOut(sw);

// 로그 기록
Console.WriteLine("Logging some information");

var logContent = sw.ToString().Trim();
Console.SetOut(originalOut);

// 로그 내용을 파일에 저장
File.WriteAllText("log.txt", logContent);
 */
