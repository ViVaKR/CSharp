using System.Threading;

namespace Demo_ElephantToRefrige;
public class Program
{
    static void Main(string[] args)
    {
        var person = new Person("공대생");
        bool isSuccess = false;
        for (int i = 0; i < 2; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine(!person.Status ? $"{person.Name}은 코끼리를 냉장고에 넣는 임무를 시작합니다..." : $"{person.Name}은 코끼리를 냉장고에서 꺼내려고 합니다.");
            Console.WriteLine();
            isSuccess = person.PutElephantInTheFrdge();
            Console.WriteLine();
            Thread.Sleep(1000);
        }
        Thread.Sleep(2000);
        if (isSuccess) Console.WriteLine($"오늘도 {person.Name}은 매우 보람찬 하루를 보냈습니다.!");
    }
}

public class Person
{
    public Elephant Elephant { get; set; }
    public Refrige Refrige { get; set; }
    public bool Status { get; set; }
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
        Elephant = new Elephant();
        Refrige = new Refrige();
        Status = false;
    }

    public bool PutElephantInTheFrdge()
    {
        return Execute(Status = (!Elephant.IsEnter ? true : false));
    }

    public bool Execute(bool execType)
    {
        Refrige.SetDoor(!Refrige.IsOpen);
        Thread.Sleep(2000);
        Elephant.SetElephant(execType);
        Thread.Sleep(2000);
        Refrige.SetDoor(false);

        return true;
    }
}

public class Elephant
{
    public bool IsEnter { get; set; }
    public Elephant()
    {
        IsEnter = false;
    }

    public bool SetElephant(bool isEnter)
    {
        Thread.Sleep(1000);
        IsEnter = isEnter;
        Console.WriteLine(IsEnter ? "코끼리를 냉장고에 넣는다." : "코끼리를 냉장고에서 꺼낸다.");
        return true;
    }
}

public class Refrige
{
    public bool IsOpen { get; set; }

    public Refrige()
    {
        IsOpen = false;
    }

    public void SetDoor(bool isOpen)
    {
        Thread.Sleep(1000);
        IsOpen = isOpen;
        Console.WriteLine(IsOpen ? "냉장고 문을 연다." : "냉장고 문을 닫는다");
    }
}

// https://github.com/ViVaKR/CSharp/blob/7393e02980aca4483cfe5c0bf2da6f71cd3ca029/Solution.Demos/Demo-ElephantToRefrige/Program.cs
