using NewFeature.Utilities;
using System.Net.WebSockets;

// 상수 정의
const int TOTAL_SIZE = 80 * 1024 + 253;  // 10MB + 253B (잔여 크기를 설정함으로 해서 잘 처리되는지 하는 테스트 포인트 매우 중요)
const int CHUNK_SIZE = 8 * 1024;          // 8KB
const int BUFFER_SIZE = TOTAL_SIZE;       // 전체 버퍼 크기를 10MB로 설정

// SendData 객체 생성 (전체 크기만큼의 버퍼로 초기화)
var sendData = new SendData(BUFFER_SIZE);

// 테스트용 데이터 생성
var testData = new byte[TOTAL_SIZE];
new Random().NextBytes(testData);  // 랜덤 데이터로 채우기

// 청크 단위로 전송
int remainingBytes = TOTAL_SIZE;
int currentPosition = 0;
int chunkCount = 0;

while (remainingBytes > 0)
{
    // 현재 청크 크기 계산 (마지막 청크는 남은 크기만큼)
    int currentChunkSize = Math.Min(CHUNK_SIZE, remainingBytes);

    try
    {
        // 현재 청크 만큼의 데이터 세그먼트 얻기
        var segment = sendData.GetSegmentAndAdvance(currentChunkSize);

        // 실제로는 여기서 데이터 전송 작업을 수행
        Buffer.BlockCopy(testData, currentPosition, segment.Array!, segment.Offset, currentChunkSize);

        // 상태 업데이트
        chunkCount++;
        currentPosition += currentChunkSize;
        remainingBytes -= currentChunkSize;

        // 진행상황 출력
        // chunks : 조각, 단위, 블록, 구간
        // 보편적으로 이러한 맥락에서는 전송단위 또는 블럭이라는 용어를 사용하는 것이 좋다.
        Console.WriteLine($"전송단위 {chunkCount,2:N0}: Sent {currentChunkSize,8:N0} bytes. " +
                        $"위치 {currentPosition,6:N0}/{TOTAL_SIZE,6:N0} " +
                        $"({currentPosition * 100.0 / TOTAL_SIZE,8:F2}%)");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        break;
    }
}


Console.WriteLine($"\n전송완료: {currentPosition:N0} 바이트, {chunkCount}회 분할 전송 완료");



// (예 1, Task 분해) Task 를 반환하는 비동기 메서드 호출
Task task = FakeAsyncOperation(); // Task를 반환받음.
await task; // Task를 벗겨냄, 또는 완료를 기다림
// await task 는 작업을 기다린다라는 의미,
// await task;  는 단순히 void 처럼 무의미한 구문이 아니며,
// 작업의 완료를 보장.
// 작업중 발생한 예외를 캐치하고 처리할 수 있음.
// 비동기 의름과 컨텍스트 전환을 지원함.

// (추가) aync void Method() 는 보편적으로 이벤트 핸들러에서만 사용되며,
// (추가)이벤트 핸들러는 반환값을 가질 수 없고,
// Task 를 반환하지 않음으로 이벤트 핸들러를 제외하면?
// 다른 비동기 메서드는 보편적으로 Task 또는 Task<T> 를 반환하는 비동기 메서드를 사용해야 함.
static Task FakeAsyncOperation()
{
    Task rs = new(() =>
    {
        Console.WriteLine("FakeAsyncOperation Start");
        Thread.Sleep(1000);
        Console.WriteLine("FakeAsyncOperation End");
    });
    return rs;
}



// (예 2, Task 통합 형식) 이미 (껍질 Task 를 완전히 벗겨된) 완료된 Task 를 반환함, 보편적인 방법 축약 형태
await DoSomethingAsync(); // 완료를 기다림, 리터값이 없는 Task결과를 기다리는 비동기 메서드 호출 한다는 의미.
//
static async Task DoSomethingAsync()
{
    Task rs = new(() =>
    {
        Console.WriteLine("FakeAsyncOperation Start");
        Thread.Sleep(1000);
        Console.WriteLine("FakeAsyncOperation End");
    });
    await rs; // Task.CompletedTask; 로 대체 가능, 즉 여기서 타스크가 모두 완료되어 물로 환원되는 모양세..
}

/*
await task;는 Task를 벗겨내어 완료 상태를 보장하는 동작으로 이해할 수 있습니다

코드 동작 흐름 분석

1. Task 생성
	•	FakeAsyncOperation()은 이미 완료된 Task를 반환합니다.

Task task = FakeAsyncOperation();

내부적으로 Task.CompletedTask를 반환하므로, task는 완료된 상태입니다.

2. Task 대기
	•	await task;는 작업 완료를 기다리는 동작을 수행합니다.
	•	Task가 이미 완료된 상태라면, await는 즉시 반환됩니다.
	•	아직 완료되지 않은 상태라면, 비동기적으로 완료를 기다립니다.
	•	여기서 await의 역할:
	•	Task를 벗겨내어 해당 작업이 완료되었음을 보장합니다.
	•	작업이 완료되지 않은 경우, 비동기적으로 대기하다가 완료 시 실행을 재개합니다.
	•	예외가 발생한 경우, await를 통해 호출자에게 예외를 던집니다.

3. DoSomething() 메서드
	•	DoSomething()은 await Task.CompletedTask;를 사용하여 완료된 작업을 기다립니다.
	•	이는 비동기 메서드의 구조를 유지하기 위해 사용됩니다.

static async Task DoSomething()
{
    await Task.CompletedTask;
}

await task;의 의미

await task;는 작업(Task)의 완료를 보장하는 동작으로 이해할 수 있습니다.
	1.	작업 완료 보장
	•	await는 작업(Task)이 완료되었는지 확인하고, 완료되지 않았다면 비동기적으로 대기합니다.
	•	이미 완료된 Task라면 즉시 반환됩니다.
	2.	예외 전달
	•	작업 중 예외가 발생했으면, await는 그 예외를 호출자에게 던집니다.
	•	Task.IsFaulted 또는 Task.Exception에 포함된 예외를 확인하지 않아도 됩니다.
	3.	컨텍스트 전환
	•	await는 호출 컨텍스트(SynchronizationContext 또는 TaskScheduler)를 보존하고, 작업 완료 후 적절한 컨텍스트에서 실행을 재개합니다.

결론

await task;는 Task를 벗겨내어 완료 상태로 만들어주는 작업으로 볼 수 있습니다.
	•	Task가 완료되었는지 확인하고, 완료되지 않았다면 대기하는 동작입니다.
	•	결과 값이 없는 경우(Task 타입)에는 단순히 작업 완료만 기다리며, 결과 값이 있는 경우(Task<T> 타입)에는 그 값을 반환합니다.
	•	이는 동기적으로 처리하지 않고, 비동기적인 작업 흐름을 유지하기 위한 핵심 역할을 합니다.


 */

/*
위와 같은 맥락으로
Task task = FakeAsyncOperation();
await task;
// 이미 완료된 Task 를 반환함.
static async Task DoSomething()
{
    await Task.CompletedTask;
}
위 코드에서 await task; 는 Task 를 벗겨내어 완료 형식으로 만들어내는 것으로 이해하면 되는가?

 */



// (예 3.) Task<T>를 반환하는 비동기 메서드 호출
Task<int> result = Ex_Task_T_Asynce(); // 일단 Task<int> 반환을 반환 받음.
int value = await result; // Task<int>에서 Task 를 벗겨내고 int 추출하기
Console.WriteLine($"Task<int> Result: {value}"); // 출력: Task<int> Result: 42

static Task<int> Ex_Task_T_Asynce()
{
    return new Task<int>(() => 42); // 타스크를 생성하고 반환
    // 또는
    // 완료된 형식의 -> return Task.FromResult(42);
}

/*
--> 예 3 설명
await 키워드는 Task<T>에서 Task 를 벗겨내고 T를 도출하는 역할을 수행한다고 설명할 수 있습니다.

코드 동작 흐름
	1.	Ex_Task_T_Asynce() 호출:
	•	Task.FromResult(42)를 반환합니다. 이 메서드는 즉시 완료된 Task<int>를 생성하여 반환합니다.
	•	여기서 Task<int>는 결과 값으로 42를 포함하고 있습니다.
	2.	Task<int> result = Ex_Task_T_Asynce();
	•	result 변수에는 Task<int> 객체가 저장됩니다.
	3.	int value = await result;
	•	await는 result가 포함하고 있는 T 타입(즉, int)의 결과 값을 추출합니다.
	•	await는 Task가 완료될 때까지 기다리고, 완료되면 Task.Result 속성에 담긴 값을 반환합니다.
	•	여기서 result는 이미 완료된 Task이므로 즉시 값(42)을 반환합니다.
	4.	Console.WriteLine($"Task<int> Result: {value}");
	•	추출된 value 값(42)을 출력합니다.

await의 역할

await는 비동기 작업(Task<T>)에서 다음 두 가지 역할을 수행합니다:
	1.	작업 완료 대기
	•	await는 Task가 완료될 때까지 비동기적으로 기다립니다.
	•	완료되지 않았다면, 호출된 메서드의 실행을 중단하고 제어를 호출자에게 반환합니다.
	•	작업이 완료되면 실행을 재개합니다.
	2.	결과 값 추출
	•	Task<T>에서 T 타입의 결과 값을 추출합니다.
	•	내부적으로 Task.Result 속성을 사용해 결과를 가져옵니다.
	•	결과 값이 없으면(Task 타입인 경우) 단순히 작업 완료를 기다립니다.

요약

await는 Task<T>에서 T를 추출하는 역할을 합니다. 이를 “Task를 벗겨내고 결과 값을 도출한다”라고 이해할 수 있습니다.

위 코드는 다음과 같이 동작을 설명할 수 있습니다:
	1.	Task<int>로부터 작업 완료를 기다립니다.
	2.	완료되면 int 값(42)을 추출합니다.
	3.	value 변수에 저장된 값은 42입니다.

추가 예시

다음 코드를 보면 await의 역할이 더 명확해집니다:

Task<string> resultTask = Task.FromResult("Hello, world!");
string message = await resultTask;
Console.WriteLine(message); // 출력: Hello, world!

여기서도 await는 Task<string>에서 string 값을 추출하는 역할을 합니다.
 */



// 결론


/*
// --> 예시코드
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting program...");

        // 비동기 작업 수행
        await PerformAsyncOperation();

        Console.WriteLine("Program completed.");
    }

    static async Task PerformAsyncOperation()
    {
        Console.WriteLine("Performing async operation...");
        await Task.Delay(2000); // 2초 대기
        Console.WriteLine("Async operation completed.");
    }
}

 */


/*
C#에서 async Task Main()은 비동기 프로그래밍 패턴에 맞는 진입점 메서드로, 다음과 같은 의미를 가집니다:

1. 비동기 코드 실행의 진입점
	•	async Task Main()은 프로그램의 시작점으로, 비동기 코드를 실행할 수 있도록 설계된 메서드입니다.
	•	기존의 동기적인 static void Main()이나 static int Main()과 달리, 비동기 작업의 완료를 기다릴 수 있습니다.
	•	이 메서드에서 await 키워드를 사용하여 비동기 작업을 수행하고 완료될 때까지 기다리는 로직을 구현할 수 있습니다.

2. Task 반환의 의미
	•	Main 메서드가 Task를 반환하면, 프로그램은 이 Task가 완료될 때까지 실행을 유지합니다.
	•	async Task Main()은 비동기 작업이 완료될 때까지 대기하며, 프로그램이 조기에 종료되지 않도록 보장합니다.

3. 예외 처리와 종료 코드
	•	비동기 Main 메서드에서 발생한 예외는 기본적으로 **AggregateException**으로 감싸지지 않고 호출 스택 상위로 전달됩니다.
	•	프로그램 종료 코드는 Task의 상태에 따라 설정됩니다:
	•	정상 종료: 0
	•	예외 발생: 비정상 종료 코드(1)

4. 예제

using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting program...");

        // 비동기 작업 수행
        await PerformAsyncOperation();

        Console.WriteLine("Program completed.");
    }

    static async Task PerformAsyncOperation()
    {
        Console.WriteLine("Performing async operation...");
        await Task.Delay(2000); // 2초 대기
        Console.WriteLine("Async operation completed.");
    }
}

실행 흐름:
	1.	Main 메서드가 호출되고, await 키워드로 인해 비동기 작업이 대기됩니다.
	2.	PerformAsyncOperation에서 2초 대기 후 작업이 완료됩니다.
	3.	작업이 완료되면 Main 메서드의 나머지 코드가 실행됩니다.

5. 주요 특징 요약

특징	설명
비동기 작업 지원	비동기 코드 실행을 지원하며, 비동기 작업의 완료를 기다릴 수 있습니다.
Task 반환	작업이 완료될 때까지 프로그램이 실행 상태를 유지합니다.
예외 처리	비동기 작업 중 발생한 예외는 호출 스택 상위로 전달됩니다.
프로그램 종료 코드 설정	작업 상태에 따라 정상/비정상 종료 코드를 설정합니다.

결론

async Task Main()은 비동기 프로그래밍의 진입점으로, 프로그램이 비동기 작업을 수행하고 안정적으로 완료될 수 있도록 지원합니다. C#에서 현대적인 비동기 프로그램을 작성할 때 가장 적합한 메인 메서드 형식입니다.

 */
