namespace Tutor.Throw;

public class DemoA
{

    public void Demo()
    {
        try
        {
            int amount = 45;
            if (amount > 40)
            {
                var ex = new ArgumentOutOfRangeException(nameof(amount), amount, "Amount must be less than 40")
                {
                    HelpLink = "https://vivabm.com",
                    Source = "Demo"
                };

                throw ex;
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Trace = {ex.StackTrace}");
            // Console.WriteLine($"Message = {ex.Message}\n\n");

            Console.WriteLine($"ActualValue => {ex.ActualValue}");


            Console.WriteLine($"ParamName = {ex.ParamName}");

            MethodBase? site = ex.TargetSite;
            Console.WriteLine($"TargetSite = {site}, Name = {site?.Name}");

            Console.WriteLine($"Data = {ex.Data}");
            Console.WriteLine($"InnerException = {ex.InnerException}");
            Console.WriteLine($"HelpLink = {ex.HelpLink}");
            Console.WriteLine($"Source = {ex.Source}");
            Console.WriteLine($"HResult = {ex.HResult:X8}");

            string? stackTrace = ex.StackTrace;
            string[] traces = !string.IsNullOrEmpty(stackTrace)
                ? stackTrace.Split(new string[] { " ", ":line", "at", "in" }, StringSplitOptions.TrimEntries)
                : throw new Exception("-");
            
            Console.WriteLine($"Error Line = {traces[^1]}");

            foreach (var item in traces)
            {
                if (string.IsNullOrEmpty(item)) continue;
                Console.WriteLine($"trace = {item}");
            }

            Console.WriteLine();
            Console.WriteLine($"Inner = {ExceptionMessages(ex)}");
        }
    }

    private async Task<int> ProcessAsync(int input)
    {
        if (input < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(input), "Input must be non-negative.");
        }

        await Task.Delay(500);
        return input;
    }

    public async void DemoExA()
    {
        try
        {
            Task<int> processing = ProcessAsync(-1);
            
            int result = await processing;

            Console.WriteLine($"result = {result}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Processing failed = {ex.Message}");
        }
    }

    public void DemoExB(int number)
    {
        try
        {
            var result = -3 / number;

            Console.WriteLine($"Divided Succeeded = {result}");
        }
        catch (Exception ex)
            when (ex is ArgumentException || ex is DivideByZeroException)
        {
            Console.WriteLine($"Divided Failed = {ex.Message}, Error Line = {ex.StackTrace?.Split(' ')[^1]}");
        }
    }

    public string ExceptionMessages(Exception ex)
    {
        if (ex.InnerException == null)
        {
            return ex.Message;
        }

        return ex.Message + "  " + ExceptionMessages(ex.InnerException);

    }
}

/* 
값	        속성            Description
0x00000000	S_OK	        작업이 성공했습니다.
0x80004001	E_NOTIMPL	    구현되지 않음
0x80004002	E_NOINTERFACE	이러한 인터페이스는 지원되지 않습니다.
0x80004003	E_POINTER	    유효하지 않은 포인터
0x80004004	E_ABORT	        작업이 중단됨
0x80004005	E_FAIL	        지정되지 않은 오류
0x8000FFFF	E_UNEXPECTED	예기치 않은 오류
0x80070005	E_ACCESSDENIED	일반 액세스 거부 오류
0x80070006	E_HANDLE	    유효하지 않은 핸들
0x8007000E	E_OUTOFMEMORY	필요한 메모리를 할당하지 못했습니다.
0x80070057	E_INVALIDARG	하나 이상의 인수가 잘못되었습니다.
*/
