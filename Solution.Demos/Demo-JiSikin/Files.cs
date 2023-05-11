namespace Helper;

public class Files
{
    public void DeleteFilesWithFileName(DirectoryInfo targetDir, string[] targetFiles)
    {
        var fileArray = targetDir.GetFiles("*.txt");
        var files = fileArray.ToList();

        if (!files.Any()) return;

        Console.WriteLine("************************");
        Console.WriteLine($"검색시작 : {files.Count}");
        Console.WriteLine("************************");

        foreach (var item in targetFiles)
        {
            Console.Write($"검색 : {item}.txt => ");

            if (files.Any(x => Path.GetFileNameWithoutExtension(x.Name).Equals(item)))
            {
                Console.WriteLine($"찾음 : {item}.txt");
                FileInfo temp = files.Single(x => Path.GetFileNameWithoutExtension(x.Name).Equals(item));
                temp.Delete();
                files.Remove(temp);
                continue;
            }
            Console.WriteLine($"못 찾음 : {item}.txt");
        }

        Console.WriteLine("************************");
        Console.WriteLine($"검색종료 : {files.Count}");
        Console.WriteLine("************************");
    }
}
