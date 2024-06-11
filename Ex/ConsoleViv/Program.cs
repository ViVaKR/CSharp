
using ConsoleViv;

// Caller
await SimpleTask.RunAsyncA().ContinueWith(x =>
{
    SimpleTask.RunB();

}, TaskContinuationOptions.OnlyOnRanToCompletion);

Console.Clear();
Console.WriteLine("[ ref vs out 차이점 ]");

int a = 10; // ref 는 초기화 필요
int b = 5;
int sum;    // out 은 초기화 불 필요
SimpleTask.Add(ref a, b, out sum); // Call by reference
Console.WriteLine($"{sum} = {a} + {b}"); // 15


