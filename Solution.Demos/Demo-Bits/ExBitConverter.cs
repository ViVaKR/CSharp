using System.Collections;
using System.Text;

namespace Demo_Bits;

public class ExBitConverter
{
    public bool GetBits(int num, int index)
    {
        return (num & (1 << index)) != 0;
    }

    public int SetBit(int num, int index)
    {
        return num | (1 << index);
    }

    public void MakeBit(long i)
    {
        Console.Write("0b_");
        Console.WriteLine(Convert.ToString(i, 2).PadLeft(64, '0'));
    }

    public void ByteToHex()
    {
        const byte b1 = 192;
        const byte b2 = 92;
        const byte b3 = 77;
        const byte b4 = 254;
        const byte b5 = 28;
        const byte b6 = 34;
        const byte b7 = 128;
        Console.WriteLine($"{b1} = {b1:X}");
        Console.WriteLine($"{b2} = {b2:X}");
        Console.WriteLine($"{b3} = {b3:X}");
        Console.WriteLine($"{b4} = {b4:X}");
        Console.WriteLine($"{b5} = {b5:X}");
        Console.WriteLine($"{b6} = {b6:X}");
        Console.WriteLine($"{b7} = {b7:X}");
        byte[] bytes = new byte[] { 128, 34, 28, 254, 77, 92, 192 };
        string hex = string.Concat(Array.ConvertAll(bytes, x => x.ToString("X2")));
        Console.WriteLine($"{string.Join(", ", bytes)}");
        Console.WriteLine(hex);

        hex = BitConverter.ToString(bytes);
        Console.WriteLine($"BitConverter.ToString(bytes) = {hex}");

        Console.WriteLine($"Hex 한문자 ( {b1:X} )를 바이트로 변환");
        Console.WriteLine($"{b1:X} = {Convert.ToByte($"{b1:X}", 16)}");

        const byte b10 = 0x11;
        string bs10 = Convert.ToString(b10, toBase: 2);
        Console.WriteLine($"{b10} = {bs10.PadLeft(8, '0')}");

        const int j = 1234567;
        string b20 = Convert.ToString(j, toBase: 2).PadLeft(32, '0');
        Console.WriteLine($"{j} = {b20} ");

        byte[] intBytes = BitConverter.GetBytes(j);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(intBytes);
        }
        byte[] result = intBytes;
        var js = BitConverter.ToString(result);

        Console.WriteLine($"{j} = {js} {Convert.ToString(j, toBase: 16).PadLeft(8, '0')}");
    }

    public void BitOperator()
    {
        const byte x = 0b_0110_1010;
        const byte y = 0b_1100_0011;
        Console.WriteLine();
        Console.WriteLine($"{x} = {Convert.ToString(x, toBase: 2).PadLeft(8, '0')}");
        Console.WriteLine($"{y} = {Convert.ToString(y, toBase: 2).PadLeft(8, '0')}");

        Console.WriteLine($"{x} & {y} = {Convert.ToString(x & y, toBase: 2).PadLeft(8, '0')}");
        Console.WriteLine($"{x} | {y} = {Convert.ToString(x | y, toBase: 2).PadLeft(8, '0')}");


        Console.WriteLine($"{x} << 2 = {Convert.ToString(x << 2, toBase: 2).PadLeft(8, '0')} ({x << 2})");
        Console.WriteLine($"{x} >> 2 = {Convert.ToString(x >> 2, toBase: 2).PadLeft(8, '0')} ({x >> 2})");

        Console.WriteLine($"{x} ^ {y} = {Convert.ToString(x ^ y, toBase: 2).PadLeft(8, '0')}");
        Console.WriteLine($"~({x} ^ {y}) = {Convert.ToString(~(x ^ y), toBase: 2).PadLeft(8, '0')}");
    }

    public void ExBitArray()
    {
        BitArray ba1 = new(8);
        ba1.Set(0, true);
        ba1.Set(1, false);
        ba1.Set(2, true);
        ba1.Set(5, true);

        BitArray ba2 = new(8);
        ba2.Set(2, true);
        ba2.Set(3, true);
        ba2.Set(5, true);
        ba2.Set(7, true);

        PrintBits(ba1, "ba1\t");
        PrintBits(ba2, "ba2\t");
        PrintBits(ba1.And(ba2), "ba1 and ba2");
        PrintBits(ba1.Or(ba2), "ba1 or ba2");

        PrintBits(ba1.Not(), "ba1.Not()");
        PrintBits(ba1.Xor(ba2), "ba1 xor ba2");
    }

    private void PrintBits(BitArray bits, string title)
    {
        Console.Write($"{title}\t:\t");

        for (int i = 0; i < bits.Length; i++)
        {
            Console.Write(bits.Get(i) ? '1' : '0');
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Base64 Encoding
    /// </summary>
    /// <param name="bytes"></param>
    public void ToBase64(byte[] bytes)
    {
        string base64 = Convert.ToBase64String(bytes);
        Console.WriteLine($"{string.Join(", ", bytes)} = {base64} - {Encoding.UTF8.GetString(bytes)}");

        FromBase64(base64);
    }

    /// <summary>
    /// Base64 Decoding
    /// </summary>
    /// <param name="base64"></param>
    public void FromBase64(string base64){
        byte[] bytes = Convert.FromBase64String(base64);
        Console.WriteLine($"{base64} = {Encoding.UTF8.GetString(bytes)}");
    }
}

/* 

! [ 접두사 ] !
- 2진수 : 0b    (0b_01100_1011)
- 8진수 : 0     (0147)
- 16진수: 0x    (0xFE)

! [ base64 ] !
- 바이너리 데이터를 아스키 문자열로 표현하는 인코딩 방식
- 영문 대문자 (A ~ Z)    : 26
- 영문 소문자 (a ~ z)    : 26
- 숫자 (0 ~ 9)          : 10
- 추가 `+`, `/`         : 2
- 
- 총 64개의 인코딩 문자 6비트의 공간만 필요함 : 2 ^ 6비트 =  2 * 2 * 2 * 2 * 2 * 2 = 64
- 한개의 아스키 문자(8비트), base64 문자(6비트) 의 최소 공배수 = 24비트 (3바이트) 이므로 4개의 base64 인코딩 값을 표현할 수 있음
- (예) : `ABC` 3개의 바이트는 6비트 씩 나누어 4개의 base64 인코딩 문자로 변경
- 만약 문자바이트가 3의 배수가 아니면 padding 과정을 거침
 */
