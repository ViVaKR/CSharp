using System.Text;
internal class Program
{
    private static void Main(string[] args)
    {
        var s = new PegStatus(Peg.Start);
        var e = new PegStatus(Peg.End);
        var t = new PegStatus(Peg.Temp);
        const int n = 4;
        var dic = new Dictionary<Peg, PegStatus>
        {
            {Peg.Start, s},
            {Peg.Temp, t},
            {Peg.End, e}
        };
        var hanoi = new TowerOfHanoi(dic, n);
        Console.WriteLine();
        Console.ReadLine();
    }
}

public class TowerOfHanoi
{
    public Dictionary<Peg, PegStatus> pegs;
    private long count = 0;
    
    public TowerOfHanoi(Dictionary<Peg, PegStatus> dic, int n)
    {
        pegs = dic;
        for (int i = n - 1; i >= 0; i--)
        {
            pegs[Peg.Start].Current.Add(i + 1);
        }

        MoveTowers(n, pegs[Peg.Start], pegs[Peg.End], pegs[Peg.Temp]);
    }
    
    public void MoveTowers(int n, PegStatus startPeg, PegStatus endPeg, PegStatus tempPeg)
    {
        if (n > 0)
        {
            MoveTowers(n - 1, startPeg, tempPeg, endPeg);
            Console.WriteLine($"({++count:000}) -> {(int)startPeg.Peg:00} To {(int)endPeg.Peg:00}");
            MoveTowers(n - 1, tempPeg, endPeg, startPeg);
        }
    }
}

public class PegStatus
{
    public Peg Peg { get; set; }
    public List<int> Current { get; set; }

    public PegStatus(Peg peg)
    {
        Peg = peg;
        Current = new List<int>();
    }
}

public enum Peg
{
    Start = 1,
    Temp = 2,
    End = 3
}
