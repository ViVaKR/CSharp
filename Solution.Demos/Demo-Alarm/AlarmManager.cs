using System.Threading;
using System.Timers;

namespace Demo_Alarm;

public class AlarmManager
{
	public System.Timers.Timer? Arm { get; set; }

	public void Run()
	{
		Arm = new System.Timers.Timer(2000);
		Arm.Elapsed += OnTimerEvent;
		Arm.AutoReset = true;
		Arm.Enabled = true;
	}

	private void OnTimerEvent(object? sender, ElapsedEventArgs e)
	{
		Console.WriteLine($"- {e.SignalTime:HH:mm:ss.fff}");
	}
}
