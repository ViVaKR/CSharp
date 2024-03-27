using System.Security.Cryptography;

namespace HashCode;

public class Program
{
    static void Main()
    {
        string pathDir = @"F:\Temp\T4";

        HashDirectory.GetHashCodeFiles(pathDir);

        var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        Console.WriteLine(token);

        Console.WriteLine(token.Length);
    }
}

// bce5b19babca720c0d23594c60dfd3424d6678239d04f04c27e251c2cb8f64a3
