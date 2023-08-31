namespace Demo_Alarm;

public class EventHelper
{
	private EventHandler? alarmEvent;
	public event EventHandler Alarm
	{
		add
		{
			alarmEvent += value;
		}
		remove
		{
			if (alarmEvent != null)
				alarmEvent -= value;
		}
	}

}

