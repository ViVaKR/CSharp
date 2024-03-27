

using Quartz;

namespace Demo_Alarm;
public class Job : IJob
{

	public Task Execute(IJobExecutionContext context)
	{
		Console.WriteLine(context.JobDetail.Description);
		return new Task(()=> Console.WriteLine(context.FireInstanceId));
	}
}
