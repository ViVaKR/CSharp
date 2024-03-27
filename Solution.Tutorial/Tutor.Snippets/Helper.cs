using System.Globalization;
using System.Net;

namespace Tutor.Snippets;

public static class Helper
{
    /// <summary>
    /// unicode string convert to special Charater
    /// </summary>
    /// <param name="unicode"></param>
    public static void ToSpacialChar(this string? unicode)
    {
        unicode ??= "25A0";
        char c = Convert.ToChar(int.Parse(unicode, NumberStyles.HexNumber));
        Console.WriteLine($"\n0x{unicode} = {c}");
    }
}
