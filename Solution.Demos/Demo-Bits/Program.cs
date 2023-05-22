namespace Demo_Bits;

public class Program
{
    public static void Main(string[] args)
    {
        BitConverter bit = new BitConverter();
        bit.GetBits(15, 3);
        

        for (int i = 31; i >= 0; i--)
        {
            Console.Write(bit.GetBits(13, i) ? 1 : 0);
        }
        Console.WriteLine();

        Console.WriteLine(Convert.ToString(bit.SetBit(5, 3), 2));

        Console.WriteLine("--------------------------");

        bit.MakeBit(~(1<< 5));
        bit.MakeBit((1<< 5));
    }
}
