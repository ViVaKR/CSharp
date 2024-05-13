using System.Collections.Generic;

namespace BM;

public enum Grab { Black, Gray, White };
public enum Apple { Red, Green, Blue, Magenta, };

public class DemoA
{
    public IEnumerable<T>? Hello<T>(T value) where T : IEnumerable<T>
    {
        var hashSetValue = value as HashSet<T>;
        return hashSetValue;
    }
}
