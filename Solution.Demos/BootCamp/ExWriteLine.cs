namespace BootCamp;
public class ExWriteLine
{
    public void Run()
    {
        RunDateTime();
    }
    private void RunDateTime()
    {
        WriteLine(
            "(d) Short date: . . . . . . . {0:d}\n" +
            "(D) Long date:. . . . . . . . {0:D}\n" +
            "(t) Short time: . . . . . . . {0:t}\n" +
            "(T) Long time:. . . . . . . . {0:T}\n" +
            "(f) Full date/short time: . . {0:f}\n" +
            "(F) Full date/long time:. . . {0:F}\n" +
            "(g) General date/short time:. {0:g}\n" +
            "(G) General date/long time: . {0:G}\n" +
            "    (default):. . . . . . . . {0} (default = 'G')\n" +
            "(M) Month:. . . . . . . . . . {0:M}\n" +
            "(R) RFC1123:. . . . . . . . . {0:R}\n" +
            "(s) Sortable: . . . . . . . . {0:s}\n" +
            "(u) Universal sortable: . . . {0:u} (invariant)\n" +
            "(U) Universal full date/time: {0:U}\n" +
            "(Y) Year: . . . . . . . . . . {0:Y}\n",
            DateTime.Now);
    }
}
