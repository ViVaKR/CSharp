using System.Text;

namespace Libs;

/// <summary>
/// 시저암호
/// </summary>
public class CaesarCipher
{
    public static char CaesarCharCipher(char ch, int key)
    {
        if (!char.IsLetter(ch)) return ch;

        char ul = char.IsUpper(ch) ? 'A' : 'a';

        return Convert.ToChar((ch + key - ul) % 26 + ul);
    }

    /// <summary>
    /// 시저 암호화
    /// </summary>
    /// <param name="plain">평문</param>
    /// <param name="key">암호화할 숫자 키</param>
    /// <returns>암호문</returns>
    public static string CaesarEncipherText(string plain, int key)
    {
        var sb = new StringBuilder();

        foreach (char ch in plain)
            sb.Append(CaesarCharCipher(ch, key));

        return sb.ToString();
    }

    /// <summary>
    /// 시저 복호화
    /// </summary>
    /// <param name="cipher">암호문</param>
    /// <param name="key">암호화 시 사용한 숫자 키</param>
    /// <returns>복호문</returns>
    public static string CaesarDecipherText(string cipher, int key)
        => CaesarEncipherText(cipher, 26 - key);
}


/*
 * == 사용법 ==
 * (암호화 대상 원문)
 * const string orgin = "Hello How are you? Fine thanks and you?";
 * (EnCipher)
 * var encipher = CaesarCipher.CaesarEncipherText(orgin, 3);
 * listBoxControl1.Items.Add(encipher);
 * (DeCipher)
 * var decipher = CaesarCipher.CasesarDecipherText(encipher, 3);
 * listBoxControl1.Items.Add(decipher);
 */
