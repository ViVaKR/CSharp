namespace BootCamp;

public class TraceLogging
{
    public void Run()
    {
        WriteLine($"{DateTime.Now}");

        // 콘솔에 로깅
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine($"{DateTime.Now} : ConsoleTraceListener");

        // Trace 메서드 사용
        Trace.TraceInformation("My Info");
        Trace.TraceWarning("My Warning");
        Trace.TraceError("My Error");

        // 파일에 로깅
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener("logs.txt"));
        Trace.AutoFlush = true;
        Trace.WriteLine($"{DateTime.Now} : File Log");

        // 콘솔과 파일에 동시 로깅
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new TextWriterTraceListener("trace.txt"));
        Trace.AutoFlush = true;
        Trace.WriteLine($"{DateTime.Now} {MethodBase.GetCurrentMethod()?.Name}");

    }
}
