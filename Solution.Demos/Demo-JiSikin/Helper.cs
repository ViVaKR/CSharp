namespace Helper;

using System.Globalization;

public static class Helper
{
    public static string ToDollar(this decimal money)
    {
        CultureInfo dollar = new CultureInfo("en-US");
        return string.Format(dollar, "{0:c}", money);
    }
    public static string ToWon(this long money)
    {
        CultureInfo won = new CultureInfo("ko-KR");
        return string.Format(won, "{0:c}", money);
    }
}
