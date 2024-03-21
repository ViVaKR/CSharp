namespace Demo_Bits;

public static class Program
{
    public static void Main()
    {
        ExBitConverter bit = new();

        Console.WriteLine($"GetBits(13, 1) = {bit.GetBits(13, 1)}");
        Console.WriteLine($"GetBits(15, 3) = {bit.GetBits(15, 3)}");
        Console.WriteLine();

        Console.Write("int value (-256)\tConvert To Binary => ");
        Console.Write("0b");
        for (int i = 31; i >= 0; i--)
        {
            if ((i + 1) % 8 == 0) Console.Write("_");
            Console.Write(bit.GetBits(-256, i) ? 1 : 0);
        }
        Console.WriteLine();

        Console.Write("int value (-1)\tConvert To Binary => ");
        Console.Write("0b");
        for (int i = 31; i >= 0; i--)
        {
            if ((i + 1) % 8 == 0) Console.Write("_");
            Console.Write(bit.GetBits(-1, i) ? 1 : 0);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Shift Or -> (5 | (1 << 3)");
        Console.WriteLine(Convert.ToString(bit.SetBit(5, 3), 2));
        Console.WriteLine();
        Console.WriteLine("Shift and Not ~(1 << 5)");
        Console.WriteLine();
        bit.MakeBit(~(1 << 5));
        Console.WriteLine("Shift (1 << 5)");
        bit.MakeBit(1 << 5);

        bit.ByteToHex();
        bit.BitOperator();
        bit.ExBitArray();

        // .NET 에서는 문자열을 저장할 때 기본적으로 UTF-16 인코딩 방식을 사용함
        // u8 : 별도의 인코딩 과정 없이 UTF-8 로 인코딩 처리
        bit.ToBase64("ABC"u8.ToArray());
        bit.ToBase64("AB"u8.ToArray());
        bit.ToBase64("안녕하세요 반갑습니다."u8.ToArray());
    }
}
