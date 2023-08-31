namespace BootCamp;
public class ExWriteLine
{
    private int top;
    private int left;

    public ExWriteLine()
    {
        top = 0;
        left = 0;
    }

    public void Run()
    {
        NumberFormat();
        RunDateTime();
        GetCursorPosition();
        ErrorOutput("Demo Error Text");
        StandardInput();
    }

    public void DrawRect()
    {
        Clear();
        top = CursorTop;
        left = CursorLeft;
        // Draw the left side of a 5x5 rectangle, from top to bottom.
        WriteAt("+", 0, 0);
        WriteAt("|", 0, 1);
        WriteAt("|", 0, 2);
        WriteAt("|", 0, 3);
        WriteAt("+", 0, 4);

        // Draw the bottom side, from left to right.
        WriteAt("-", 1, 4); // shortcut: WriteAt("---", 1, 4)
        WriteAt("-", 2, 4); // ...
        WriteAt("-", 3, 4); // ...
        WriteAt("+", 4, 4);

        // Draw the right side, from bottom to top.
        WriteAt("|", 4, 3);
        WriteAt("|", 4, 2);
        WriteAt("|", 4, 1);
        WriteAt("+", 4, 0);

        // Draw the top side, from right to left.
        WriteAt("-", 3, 0); // shortcut: WriteAt("---", 1, 0)
        WriteAt("-", 2, 0); // ...
        WriteAt("-", 1, 0); // ...
                            //
        WriteAt("All done!", 0, 6);
        WriteLine();
    }

    private void WriteAt(string s, int x, int y)
    {
        try
        {
            SetCursorPosition(left + x, top + y);
            Write(s);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Clear();
            Write(ex.Message);
        }
    }

    private void NumberFormat()
    {
        WriteLine("Number Format ");
        WriteLine(
            "(C) Currency: . . . . . . . . {0:C}\n" +
            "(D) Decimal:. . . . . . . . . {0:D}\n" +
            "(E) Scientific: . . . . . . . {1:E}\n" +
            "(F) Fixed point:. . . . . . . {1:F}\n" +
            "(G) General:. . . . . . . . . {0:G}\n" +
            "    (default):. . . . . . . . {0} (default = 'G')\n" +
            "(N) Number: . . . . . . . . . {0:N}\n" +
            "(P) Percent:. . . . . . . . . {1:P}\n" +
            "(R) Round-trip: . . . . . . . {1:R}\n" +
            "(X) Hexadecimal:. . . . . . . {0:X}\n",
            -123, -123.45f);
    }

    private void RunDateTime()
    {
        WriteLine("DateTime");
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

    private void GetCursorPosition()
    {
        var (Left, Top) = Console.GetCursorPosition();
        WriteLine($"pos.Left = {Left}, pos.Top = {Top}");
    }

    private void ErrorOutput(string error)
    {
        SetError(new StreamWriter("./error.txt", true));
        Error.WriteLine(error);
        Error.Close();
        var standardError = new StreamWriter(OpenStandardError()) { AutoFlush = true };
        SetError(standardError);
        WriteLine("\nError information written to error.txt");
    }

    private void StandardInput()
    {
        Write("Input >> ");
        Stream stream = OpenStandardInput();
        byte[] bytes = new byte[100];
        int length = stream.Read(bytes, 0, 100);

        char[] chars = Encoding.UTF8.GetChars(bytes, 0, length);
        WriteLine($"chars = {new string(chars)}");
    }
}
