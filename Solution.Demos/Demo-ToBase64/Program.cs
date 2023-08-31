using System.Text;
namespace ToBase64;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Encoding...");
        string text = "안녕하세요, 반갑습니다!";
        string base64Text = TextToBase64(text);
        Console.Write("Base64 => ");
        Console.WriteLine(base64Text);
        Console.WriteLine();
        Console.WriteLine("Decoding...");
        Console.Write("Original Text => ");
        Console.WriteLine(Base64ToText(base64Text));
        Console.WriteLine();
    }

    private static string TextToBase64(string source)
    {
        byte[] data = Encoding.UTF8.GetBytes(source);
        return Convert.ToBase64String(data);
    }

    private static string Base64ToText(string source)
    {
        byte[] data = Convert.FromBase64String(source);
        return Encoding.UTF8.GetString(data);
    }
}
