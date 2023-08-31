namespace BootCamp;

public class TraceLogging
{
    public void Run()
    {
        // CreateTextWriterTraceListener();
        CreateConsoleTraceListener();
    }

    public void CreateConsoleTraceListener()
    {
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new ConsoleTraceListener(true));
        Trace.TraceInformation($"Console Trace Message {DateTime.Now}");
        Trace.AutoFlush = true;
        Trace.Flush();
        for (int i = 0; i < 5; i++)
        {
            Trace.WriteLine($"{i + 1: 000} : Trace ( {MethodBase.GetCurrentMethod()?.Name} )");
            Thread.Sleep(1000);
        }
        Trace.TraceWarning("Trace Warning");
        Trace.TraceError("Trace Error");
    }

    public void CreateTextWriterTraceListener()
    {
        // 콘솔과 파일에 동시 로깅
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener("TextWriterOutput.log", "vivListener"));
        Trace.TraceInformation($"{DateTime.Now} : Message.");
        Trace.Flush();
    }
}
