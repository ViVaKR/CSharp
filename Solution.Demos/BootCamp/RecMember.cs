
namespace BootCamp;
/// <summary>
/// Immutable 불변속성
/// init : 처음 객체 초기화시만 속성 변경가능 키워드
/// with
/// Equals, ReferenceEquals
/// </summary>
/// <value></value>
public record RecMember
{
    public string Name { get; init; }

    public int Age { get; init; }

    public RecMember() : this(string.Empty, 0) { }

    public RecMember(string name, int age) => (Name, Age) = (name, age);

    public void Deconstructor(out string name, out int age)
    => (name, age) = (Name, Age);
}

public record Employee : RecMember
{
    public int Id { get; set; }
}
