using System.Collections;
using System.Diagnostics;

namespace ConsoleViv.Playground;

public class Generics
{
    public void Efficiency()
    {
        // generic list
        List<int> listGeneric = [5, 9, 1, 4];

        // non-generic list
        ArrayList listNonGeneric = [5, 9, 1, 4];

        Stopwatch s = Stopwatch.StartNew();
        listGeneric.Sort();
        s.Stop();

        Console.WriteLine($"Generic Sort: {listGeneric} \n Time taken {s.Elapsed.TotalMilliseconds} ms");

        // timer for non-generic list sort
        Stopwatch s2 = Stopwatch.StartNew();
        listNonGeneric.Sort();
        s2.Stop();
        Console.WriteLine($"Non-Generic Sort: {listNonGeneric} \n Time taken {s2.Elapsed.TotalMilliseconds} ms");
    }
}
