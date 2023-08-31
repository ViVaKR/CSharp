namespace BootCamp;

public class A
{
    public string? Messages { get; set; }

    public void SendMail()
    {
        Console.WriteLine($"전체메일 발송 중 :  {Messages}");
    }
}

public class B : A
{
    public B()
    {
        Messages = "Send Mail From B";
    }
}

public class C : A
{
    public C()
    {
        Messages = "Send Mail From C";
    }
}

public class D : A
{
    public D()
    {
        Messages = "Send Mail From D";
    }
}

public class DemoInheritance
{
    public void Run()
    {
        // A 타입 클래스 인스턴스 목록
        var list = new List<A>
        {
            new B(),
            new C(),
            new D()
        };

        foreach (var item in list)
        {
            item.SendMail();
        }
    }
}
