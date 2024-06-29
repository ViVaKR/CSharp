
namespace FileWacherCamp;

public class VivWatcher
{
    public static void Run()
    {
        List<string> targets = [ // Multi Directories...
            "/Users/vivakr/Temp/watch/a1",
            "/Users/vivakr/Temp/watch/a2",
            "/Users/vivakr/Temp/watch/a3",
            "/Users/vivakr/Temp/watch/a4",
        ];
        foreach (string path in targets) Watch(path);
        Console.WriteLine("Press (q) to quit the sample.");
        while (Console.Read() != 'q') ;
    }

    private static void Watch(string path)
    {
        FileSystemWatcher watcher = new()
        {
            Path = path,
            NotifyFilter = NotifyFilters.Attributes
                           | NotifyFilters.CreationTime
                           | NotifyFilters.DirectoryName
                           | NotifyFilters.FileName
                           | NotifyFilters.LastAccess
                           | NotifyFilters.LastWrite
                           | NotifyFilters.Security
                           | NotifyFilters.Size,
            Filter = "*"
        };

        watcher.Changed += FileChanged;
        watcher.Created += FileChanged;
        watcher.Deleted += FileChanged;
        watcher.Renamed += FileRenamed;
        watcher.Error += OnError;

        watcher.EnableRaisingEvents = true;
    }

    private static void OnError(object sender, ErrorEventArgs e) => Errors(e.GetException());

    private static void Errors(Exception? ex)
    {
        if (ex != null)
        {
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"Stacktrace: {ex.StackTrace}");
            Errors(ex.InnerException);
        }
    }

    private static void FileRenamed(object sender, RenamedEventArgs e)
    {
        if (sender is not FileSystemWatcher watch) return;
        Console.WriteLine($"({e.ChangeType}) {DateTime.Now} {watch.Path}/{e.OldName} --> {e.Name}");
    }

    private static void FileChanged(object sender, FileSystemEventArgs e)
    {
        if (sender is not FileSystemWatcher watch) return;
        Console.WriteLine($"({e.ChangeType}) {DateTime.Now} {watch.Path} --> {e.Name}");
    }
}
