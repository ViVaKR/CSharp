namespace HashCode;

public static class HashDirectory
{
    // Display the byte array in a readable format.
    public static void PrintByteArray(byte[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]:X2}");
            if ((i % 4) == 3) Console.Write(" ");
        }
        Console.WriteLine();
    }

    public static void GetHashCodeFiles(string directory)
    {
        // hash code
        if (!Directory.Exists(directory)) return;

        var dir = new DirectoryInfo(directory);
        FileInfo[] files = dir.GetFiles();

        // Initialize a SHA256, 384, 512 hash object.
        using System.Security.Cryptography.SHA512 sha = System.Security.Cryptography.SHA512.Create();
        // Compute and print the hash values for each file in directory.
        foreach (FileInfo fi in files)
        {
            using FileStream fs = fi.Open(FileMode.Open);
            try
            {
                fs.Position = 0;
                byte[] hashValue = sha.ComputeHash(fs);
                Console.Write($"{fi.Name}:\t");
                PrintByteArray(hashValue);
            }
            catch (IOException e)
            {
                Console.WriteLine($"I/O Exception: {e.Message}");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Access Exception: {e.Message}");
            }
        }
    }
}
