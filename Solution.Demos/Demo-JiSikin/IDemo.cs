namespace Helper;

interface IDemo
{
    // 인터페이스 기본 멤버 (Default Member)
    // 상속 후 구현하지 않으면 
    // 본 메서드 자동 실행됨
    void DemoFunc() => Console.WriteLine("I am IDemo");
}
