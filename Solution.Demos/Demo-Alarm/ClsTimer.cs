namespace Demo_Alarm;

public class ClsTimer
{
	public override string ToString()
	{
		var str = DateTime.Now.ToString();
		int? index = str.IndexOf(" ");
		return str[(int)(index + 1)..];
	}
}
