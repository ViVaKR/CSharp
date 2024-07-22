// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

// Console.WriteLine($"Main thread => {Environment.CurrentManagedThreadId}");


// for (int i = 0; i < 5; i++)
// {
/*
ThreadPool.QueueUserWorkItem() 메서드는 비동기 작업을 수행하는데 사용되는 메서드로
사용자가 만든 스레드 풀 스레드에서 작업을 수행하도록 요청하는 메서드이다.
작업을 수행할 메서드를 ThreadPool.QueueUserWorkItem() 메서드의 인자로 전달하면
스레드 풀 스레드가 해당 메서드를 실행한다.

스레드 풀 스레드는 작업을 수행한 후 다시 스레드 풀로 돌아가 대기하므로
백그라운드 스레드와 같은 역할을 수행한다.


작업 완료 시점을 알수 없음.
작업 수행 결과를 얻어 올 수 없음. : 예를 들어 네트워크 요청을 보내고 응답을 받아야 하는 경우 방법이 없음으로 복잡한 작업에는 부적합
취소 / 예외 처리 불가능 : 예를 들어 네트워크가 끊겼을 때, 작업을 취소하거나 예외 처리를 할 수 없음
 */
//     ThreadPool.QueueUserWorkItem((state) => // 스레드 풀을 이용하는 가장 단순한 방법..으로 --> Task를 사용하는 것이 좋다.
//     {
//         Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} started");
//         Thread.Sleep(1000);
//         Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} finished");
//     });
// }
// Console.WriteLine($"Main thread {Environment.CurrentManagedThreadId} finished");



// // Task Parallel Library (TPL) : 하고자 하는 작업을 묶어 둠. 상호 상관관계가 없은 작업들을 묶어서 처리할 때 유리함.
// // 순서를 매길 필요가 없는 작업들을 병렬로 처리할 때 병렬화 기능을 사용하면 좋다.

// // QueueUserWorkItem 과 유사 동작을 수행하는 코드 패턴
// Action action = () =>
// {
//     Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} started");
// };

// Task task = new(action);
// task.Start();
// task.Wait();

// // 또는
// var t = Task.Run(action);


// // (3)

// Task<int> task2 = new(() =>
// {
//     int sum = 0;
//     for (int i = 0; i < 100; i++)
//     {
//         sum += i;
//     }
//     return sum;
// });

// // 스레드 간의 커뮤니케이션을 위해 사용하는 방법
// task2.Start(); //--> 스레드를 큐에 밀어 넣는 단계, Start()를 호출하지 않아도 Task.Run()을 사용하면 자동으로 실행된다.
// task2.Wait(); //--> Task가 완료될 때까지 대기, 완료 시점을 알수 있음.
// Console.WriteLine($"Result : {task2.Result}"); //-->  Task의 결과를 가져옴

// var sum = new Func<int, int>((x) =>
// {
//     int sum = 0;
//     for (int i = 0; i < x; i++)
//     {
//         sum += i;
//     }
//     return sum;

// });

// var t2 = new Task<int>(() => sum(100));
// t2.Start();
// Console.WriteLine($"Result : {await t2}");

// static async Task<int> SumWithCancel(CancellationToken cancel, int n)
// {
//     int sum = 0;
//     for (int i = 0; i < n; i++)
//     {
//         await Task.Delay(500);
//         Console.WriteLine($"In Task Job : {sum} -> (Thread ID:  {Environment.CurrentManagedThreadId})");
//         if (cancel.IsCancellationRequested)
//         {
//             Console.WriteLine("Task Cancelled");
//             // cancel.ThrowIfCancellationRequested();
//             return sum;
//         }
//         sum += i;
//     }
//     return sum;
// }

// Console.WriteLine("Task Start With Cancelled");
// CancellationTokenSource cts = new();
// var t3 = new Task<Task<int>>(() => SumWithCancel(cts.Token, 20), cts.Token);
// t3.Start();
// t3.Wait(); // Task가 완료될 때까지 대기,  UI 스레드에서 사용하면 안됨. 즉, UI 가 멈추게 된다.
// Wait 하면 UI 스레드가 아무것도 안하고 기다리고 있음, 즉, 멈추게 된다. 그러므로 Task.Wait()를 사용하지 않는 것이 좋다.

// Thread.Sleep(2000);
// cts.Cancel(); // 작업 취소

// try
// {
//     Console.WriteLine($"[ Result ] => {t3.Result.Result}");
// }
// catch (AggregateException ex)
// {
//     ex.Handle(x => x is OperationCanceledException);
//     Console.WriteLine("== Task Cancelled ==");
// }

//--> Task 연결 : ContinueWith() 메서드를 사용하여 Task를 연결할 수 있다.
// Wait free, Lock free
// ContinueWith() 메서드는 이전 Task가 완료된 후에 실행할 작업을 지정할 수 있다.
// ContinueWith() 메서드는 Task를 반환하므로 여러 작업을 연결할 수 있다.
// Task<int> task3 = Task.Run(() => Sum(CancellationToken.None, 10));

// UI 스레드 사용 가능, 즉 Task.Wait()를 사용하지 않아도 된다.
// task3 가 완료되면 ContinueWith() 메서드가 실행되므로 UI 스레드가 멈추지 않는다.
// Task cwt = task3.ContinueWith( // 즉, task3 가 완료되면 ContinueWith() 메서드가 실행된다.
//  x => Console.WriteLine($"ContinueWith Result : {x.Result}"));

// static async Task<int> Sum(CancellationToken cancel, int n)
// {
//     int sum = 0;
//     for (int i = 0; i < n; i++)
//     {
//         Console.WriteLine($"In Task Job : {sum} -> (Thread ID:  {Environment.CurrentManagedThreadId})");
//         await Task.Delay(500);
//         if (cancel.IsCancellationRequested)
//         {
//             Console.WriteLine("Task Cancelled");
//             // cancel.ThrowIfCancellationRequested();
//             return sum;
//         }
//         sum += i;
//     }
//     return sum;
// }


//--> Task 연결 2
// 경우에 따라서는 선행 타스크가 항상 성공할 수 없을 때
// TaskContinuationOptions
// OnlyOnCanceled, OnlyOnFaulted, OnlyOnRanToCompletion 등을 사용하여 선행 타스크의 상태에 따라 후속 타스크를 실행할 수 있다.



// CancellationTokenSource cts2 = new();
// cts2.CancelAfter(3000);
// var task4 = Task.Run(() => Sum(cts2.Token, 100), cts2.Token);

// await task4.ContinueWith( // 성공 완료시
//     x => Console.WriteLine($"[ ContinueWith Result ] => {x.Result}"),
//     TaskContinuationOptions.OnlyOnRanToCompletion
// );

// await task4.ContinueWith( // 취소시
//     x => Console.WriteLine($"ContinueWith OnCanceled => {x.Exception?.InnerException}"),
//     TaskContinuationOptions.OnlyOnCanceled
// );

// await task4.ContinueWith( // 실패시
//     x => Console.WriteLine($"ContinueWith OnFaulted => {x.Exception?.InnerException}"),
//     TaskContinuationOptions.OnlyOnFaulted
// );


/* [타스크 병렬화 ] */

// 부모/자식 타스크로 연결,
// TaskCreateionOptions.AttachedToParent 옵션을 사용하여 부모 타스크와 자식 타스크를 연결할 수 있다.

// static int Sum(int a)
// {
//     int sum = 0;
//     for (int i = 0; i < a; i++)
//     {
//         sum += i;
//     }
//     return sum;
// }
// Task<int[]> parent = new(() =>
// {
//     var result = new int[3];
//     new Task(() => result[0] = Sum(10), TaskCreationOptions.AttachedToParent).Start(); // 자식으로 연결
//     new Task(() => result[1] = Sum(20), TaskCreationOptions.AttachedToParent).Start(); // 자식으로 연결
//     new Task(() => result[2] = Sum(30), TaskCreationOptions.AttachedToParent).Start(); // 자식으로 연결
//     return result;
// });

// Task cwt = parent.ContinueWith( // 부모 타스크의 그 하부 타스크가 모두 완료되면 실행
//     x => Array.ForEach(x.Result, Console.WriteLine) // 그 결과를 출력
// );
// parent.Start();

// Console.ReadLine();


// .NET 5.0 이후부터는 Task를 사용하는 것이 좋다.

//? [I/O 동기 메커니즘]
//--> (1) .NET : FileStream, StreamReader, StreamWriter, WebClient, HttpClient
//--> (2) Win32 : User-Mode : ReadFile(...)
//--> (3) Windows Kernel-Mode : IRP (I/O Request Packet), Windoes I/O Subsystem Dispatcher code : ReadFile(...) --> I/O Completion Port

//? [I/O 비동기 메커니즘]
//--> (1) .NET : FileStream, StreamReader, StreamWriter, WebClient, HttpClient
//--> (2) Win32 : User-Mode : ReadFileEx(...)
//--> (3) Windows Kernel-Mode : IRP (I/O Request Packet), The CLR's ThreadPool: Threads can extract completed IRPs form here.
//                              Completion task with result or exception

//? [ 비동기 프로그래밍 패턴 비교 ]
// 1. Sync : 단순함.
// 2. APM : 복잡함, Begin / End, 콜백 지옥
// 3. EAP (Event-based Asynchronous Patter): 이벤트 기반, 작업이 완료될 때 이벤트를 발생시킴., APM 과 동일하게 작업을 시킨 위치와 받는 위치가 다르다는 문제가 있음. 컨텍스트들을 끌고 와야 함.
/*
? eap example

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string url = "http://www.microsoft.com";
        WebClient wc = new WebClient();
        wc.DownloadStringCompleted += (sender, e) => Client_DownloadStringCompleted;
        wc.DownloadStringAsync(new Uri(url));
    }

    void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        //--> 문제점 : 작업을 시킨 위치와 받는 위치가 다르므로, url 변수를 사용할 수 없다.
        Console.WriteLine(e.Result);
    }


 */
//--> 4. TAP (Task-based Asynchronous Pattern) : Task를 사용하여 비동기 작업을 수행하는 패턴, 가장 추천하는 패턴, ReadAsync(), WriteAsync() 등의 메서드를 사용하여 비동기 작업을 수행할 수 있다.
//===========> Task<T> 를 리턴함으로써 작업 완료 시점을 알 수 있고, 작업 수행 결과를 얻어 올 수 있다. 취소 / 예외 처리 가능
/*
? tap example

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        string url = "http://www.microsoft.com";
        HttpClient hc = new HttpClient();
        string result = await hc.GetStringAsync(url);
        Console.WriteLine(result);
    }

 */

// 5. DataFlow : TPL Dataflow, 데이터 흐름을 기반으로 비동기 작업을 수행하는 패턴, 데이터 흐름을 기반으로 작업을 수행하므로 복잡한 작업을 수행할 때 유리함.
// 6. Reactive : Rx, LINQ와 유사한 방식으로 비동기 작업을 수행하는 패턴, 이벤트 스트림을 기반으로 작업을 수행하므로 이벤트 스트림을 다루는 작업을 수행할 때 유리함.
// 7. Actor : Akka.NET, Actor 모델을 기반으로 비동기 작업을 수행하는 패턴, Actor 모델을 기반으로 작업을 수행하므로 분산 시스템을 다루는 작업을 수행할 때 유리함.
// 8. CSP : Go, CSP 모델을 기반으로 비동기 작업을 수행하는 패턴, CSP 모델을 기반으로 작업을 수행하므로 병렬 시스템을 다루는 작업을 수행할 때 유리함.
// 9. CQRS : Command Query Responsibility Segregation, CQRS 패턴을 기반으로 비동기 작업을 수행하는 패턴, CQRS 패턴을 기반으로 작업을 수행하므로 데이터베이스를 다루는 작업을 수행할 때 유리함.
// 10. Event Sourcing : 이벤트 소싱 패턴을 기반으로 비동기 작업을 수행하는 패턴, 이벤트 소싱 패턴을 기반으로 작업을 수행하므로 이벤트를 다루는 작업을 수행할 때 유리함.
// 11. DDD : Domain-Driven Design, 도메인 주도 설계 패턴을 기반으로 비동기 작업을 수행하는 패턴, 도메인 주도 설계 패턴을 기반으로 작업을 수행하므로 도메인을 다루는 작업을 수행할 때 유리함.
// 12. CQRS + ES : CQRS + Event Sourcing, CQRS와 이벤트 소싱 패턴을 함께 사용하여 비동기 작업을 수행하는 패턴, CQRS와 이벤트 소싱 패턴을 함께 사용하여 작업을 수행하므로 데이터베이스와 이벤트를 다루는 작업을 수행할 때 유리함.
// 13. CQRS + ES + DDD : CQRS + Event Sourcing + Domain-Driven Design, CQRS와 이벤트 소싱 패턴, 도메인 주도 설계 패턴을 함께 사용하여 비동기 작업을 수행하는 패턴, CQRS와 이벤트 소싱 패턴, 도메인 주도 설계 패턴을 함께 사용하여 작업을 수행하므로 데이터베이스, 이벤트, 도메인을 다루는 작업을 수행할 때 유리함.


//--> TAP Pattern Example
Console.WriteLine("TAP Pattern Example");
string url = "http://www.microsoft.com";
HttpClient hc = new();
string result = await hc.GetStringAsync(url);
Console.WriteLine(result);


// 또는 뜯어 보면 아래와 같다.
Task<string> t = hc.GetStringAsync(url);
await t.ContinueWith(t => Console.WriteLine(t.Result));


// 각각의 코드를 독립적으로 돌아가게 하는 방법
// 즉, 각각의 코드가 독립적으로 돌아가게 하려면 ConfigureAwait(false)를 사용하면 된다.
var rs1 = await DownloadDemoAsync(url).ConfigureAwait(false); //--> ConfigureAwait(false) : 스레드 컨텍스트를 유지하지 않고, 스레드 풀 스레드에서 계속 실행하도록 함.
var rs2 = await DownloadDemoAsync(url).ConfigureAwait(false);
var rs3 = await DownloadDemoAsync(url).ConfigureAwait(false);
var rs4 = await DownloadDemoAsync(url).ConfigureAwait(false);

static async Task<string> DownloadDemoAsync(string url)
{
    HttpClient hc = new();
    string result = await hc.GetStringAsync(url);
    Console.WriteLine(result);
    return result;
}

// 비동기 코드를 동기 코드처럼 사용하기 위하여 도입된 --> async / await 키워드
// async / await 키워드는 내부적으로는 조금 복잡함.
// 메시지 큐는 await 키워드 앞까지 실행하고, free 한 상태로 다음 UI 스레드를 처리하면서, 처리가 완료 되어 리턴되면, 한방에  await 키워드 뒤의 코드를 실행한다.
// 즉, await 키워드는 메시지 큐에 작업을 넣는 역할을 한다.
