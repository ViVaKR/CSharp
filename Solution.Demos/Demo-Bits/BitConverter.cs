namespace Demo_Bits;

public class BitConverter
{
    public bool GetBits(int num, int index)
    {
        return (num & (1 << index)) != 0;
    }

    public int SetBit(int num, int index)
    {
        return (num | (1 << index));
    }

    public void MakeBit(long i)
    {

        Console.WriteLine(Convert.ToString(i, 16));
        Console.WriteLine(Convert.ToString(i, 2));
        Console.WriteLine(i);
    }
}
