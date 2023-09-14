namespace J_Actions;
public static class MainApp
{
    public static void Move(int x, int y)
    {
        Console.WriteLine($"Move({x}, {y})");
    }

    public static void Resize(int x, int y)
    {
        Console.WriteLine($"Resize({x}, {y})");
    }
}
