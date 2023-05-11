namespace Helper;

public class ChildA : IDemo
{
    // ChildA 고유맴버
    public int Id { get; set; }

    // 구현시 변경실행됨
    // public void DemoFunc() => Console.WriteLine("I am ChildA");

    public void Print(string message) {

        Console.WriteLine(message);
    }
}
