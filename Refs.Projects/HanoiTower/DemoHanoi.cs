namespace HanoiTower;

public class DemoHanoi
{
    public void Hanoi(int n, char from, char temp, char to)
    {
        if (n == 1)
        {
            Console.WriteLine($"{from} -> {to}");
            return; // 재귀 종료 조건
        }

        Hanoi(n - 1, from, to, temp);
        Console.WriteLine($"{from} -> {to}");
        Hanoi(n - 1, temp, from, to);
    }
}
