Console.WriteLine("Auto Property vs Field");


var (a, b) = GetTuple();

Console.WriteLine($"{a}, {b}!");

static (string a, string b) GetTuple()
{
    return ("Hello", "World");
}


// Connection string format: User Id=[username];Password=[password];Data Source=[hostname]:[port]/[DB service name];
// OracleConnection con = new OracleConnection("User Id=[Username];Password=[Password];Data Source=localhost:1521/FREEPDB1;");
// con.Open();
// OracleCommand cmd = con.CreateCommand();
// cmd.CommandText = "SELECT \'Hello World!\' FROM dual";

// OracleDataReader reader = cmd.ExecuteReader();
// reader.Read();
// Console.WriteLine(reader.GetString(0));

/*



var person = new Person();
person.Name = "Alice";
person.Age = 30;

public class Person
{
    public string Name; // 단순 필드
    public int Age;     // 단순 필드
}



// 이름을 대문자로 자동 변환해야 한다는 요구사항이 추가되면:
public class Person
{
    private string _name;
    public int Age;

    public string Name
    {
        get => _name;
        set => _name = value.ToUpper(); // 요구사항 반영
    }
}


public class Person
{
    public string Name { get; set; } // 자동 속성
    public int Age { get; set; }    // 자동 속성
}

// 사용 코드
var person = new Person();
person.Name = "Alice";
person.Age = 30;

// 이름을 대문자로 자동 변환해야 한다는 요구사항이 추가되면:
public class Person
{
    private string _name;
    public int Age { get; set; }

    public string Name
    {
        get => _name;
        set => _name = value.ToUpper(); // 요구사항 반영
    }
}

// 필드를 사용한는 코드는 요구사사항 변경에 대응하기 어렵다.
person.Name = "Hello"; // 변경 전
person.Name = "HELLO WORL"; // 변경 후, 모든 코드에서 처리 필요


// 자동 속성을 사용하는 코드에서는 속성의 내부 로직만 변경하면 된다.
public string Name
{
    get => _name;
    set => _name = value.ToUpper();
}




1. 캡슐화(Encapsulation)란?

캡슐화(Encapsulation) 는 객체지향 프로그래밍(OOP)의 중요한 개념 중 하나로, 객체의 내부 상태(데이터)를 외부에서 직접 접근하지 못하도록 보호하고, 필요한 접근만 허용하는 메커니즘입니다. 이를 통해 데이터의 무결성을 유지하고, 외부와 내부의 의존성을 줄일 수 있습니다.

캡슐화의 핵심 요소
	1.	데이터 은닉:
	•	객체 내부의 데이터(필드)는 외부에서 직접 접근하지 못하도록 private으로 선언합니다.
	•	외부에서는 데이터를 직접 수정하거나 읽을 수 없으며, 특정 메서드나 속성을 통해서만 접근이 가능합니다.
	2.	제어된 접근:
	•	데이터를 보호하면서도 필요에 따라 데이터를 읽거나 수정할 수 있도록 **공개 접근자(get)**와 **설정자(set)**를 제공합니다.
	•	접근자와 설정자에 로직을 추가하여 데이터의 유효성을 검증하거나, 데이터 변경에 대한 제어를 할 수 있습니다.

    public class Person
{
    public string Name; // 직접 접근 가능
    public int Age;     // 직접 접근 가능
}

var person = new Person();
person.Name = "Alice"; // 외부에서 직접 데이터 수정
person.Age = -5;       // 잘못된 데이터 입력 허용

public class Person
{
    private string _name; // 데이터 은닉
    private int _age;     // 데이터 은닉

    public string Name
    {
        get => _name; // 읽기 허용
        set => _name = value; // 쓰기 허용
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0) // 유효성 검사
                throw new ArgumentException("Age cannot be negative.");
            _age = value;
        }
    }
}

var person = new Person();
person.Name = "Alice"; // 올바른 데이터 설정
person.Age = 25;       // 올바른 데이터 설정
// person.Age = -5;     // 예외 발생: "Age cannot be negative."

캡슐화를 사용하는 이유
	1.	데이터 보호:
	•	외부에서 직접적으로 데이터(필드)에 접근하지 못하게 하여, 데이터의 무결성을 유지합니다.
	2.	유효성 검사:
	•	set 접근자에 검증 로직을 추가하여 잘못된 값이 들어오는 것을 방지할 수 있습니다.
	3.	코드 변경 유연성:
	•	내부 구현을 변경해도 외부 코드에 영향을 주지 않습니다.
예: 내부 데이터를 필드에서 데이터베이스 호출로 변경해도, get과 set은 동일하게 사용할 수 있습니다.
	4.	제어된 접근 제공:
	•	특정 데이터는 읽기만 가능하도록 하거나, 쓰기를 제한할 수 있습니다.


자동 속성은 C#에서 캡슐화를 간편하게 구현할 수 있는 도구입니다.
    public class Person
{
    public string Name { get; set; } // 자동 속성
    public int Age { get; set; }    // 자동 속성
}

캡슐화는 객체가 스스로 데이터를 관리할 수 있도록 보호하고, 외부와의 의존성을 줄이는 OOP의 핵심 개념입니다. 이를 통해 코드의 안정성, 유지보수성, 유연성을 크게 향상시킬 수 있습니다.


3. 데이터 바인딩이 필요한 경우 (UI Frameworks, WPF, Blazor 등)
UI 개발에서 데이터 바인딩은 속성(Property)을 기반으로 작동합니다. 자동 속성을 사용하면 바인딩이 자동으로 지원되며, 필드를 사용할 경우 추가 작업이 필요합니다.

4. Reflection 및 직렬화 (Serialization) 관련 작업

자동 속성은 Reflection이나 Json.NET, System.Text.Json 같은 라이브러리에서 데이터를 직렬화하거나 역직렬화할 때 자연스럽게 매핑됩니다. 필드는 기본적으로 무시되며, 이를 사용하려면 추가적인 매핑 작업이 필요합니다.

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// JSON 직렬화 및 역직렬화
var json = JsonSerializer.Serialize(new Person { Name = "Alice", Age = 30 });
var person = JsonSerializer.Deserialize<Person>(json);

public class Person
{
    public string Name;
    public int Age;
}

// 필드 매핑이 자동으로 되지 않아 추가 설정이 필요
var json = JsonSerializer.Serialize(new Person { Name = "Alice", Age = 30 }); // 오류 발생 가능

5. 상속 및 데이터 유효성 검사 확장 가능성

속성을 사용하면 getter와 setter에 로직을 추가해 유효성 검사나 이벤트를 확장할 수 있습니다. 반면, 필드는 유효성 검사를 적용하려면 별도의 메서드나 검증 로직을 추가해야 하며, 코드가 복잡해집니다.

// 속성을 사용한 유효성 검사 확장
public class Person
{
    private int _age;

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0)
                throw new ArgumentException("Age cannot be negative.");
            _age = value;
        }
    }
}

// 핃드를 사용한 유효성 검사 확장
// 필드 방식은 객체 지향적이지 않으며, API 호출 방식이 불편해질 수 있습니다.
public class Person
{
    private int _age;

    public void SetAge(int value)
    {
        if (value < 0)
            throw new ArgumentException("Age cannot be negative.");
        _age = value;
    }

    public int GetAge() => _age;
}

6. Thread Safety (스레드 안정성)

자동 속성을 사용하면 lock 구문 등을 적용하기 쉬워 다중 스레드 환경에서 안정성을 보장할 수 있습니다.
private readonly object _lock = new();

public int Counter
{
    get
    {
        lock (_lock)
        {
            return _counter;
        }
    }
    set
    {
        lock (_lock)
        {
            _counter = value;
        }
    }
}
private int _counter;

// 필드를 사용한 경우: 모든 접근 지점(클라이언트)에 lock을 걸어야 함
필드를 다룰 때도 동일한 작업을 할 수 있지만, 모든 접근 지점에서 명시적으로 lock을 걸어야 하므로 실수하기 쉽고, 코드가 분산되어 관리가 어렵습니다.

7. 인터페이스 구현 및 상속

자동 속성을 사용하면 인터페이스의 속성을 간결하게 구현할 수 있습니다.
필드를 사용할 경우 인터페이스의 속성을 구현하려면 추가 작업이 필요합니다.

// 자동 속성을 사용한 인터페이스 구현
public interface IPerson
{
    string Name { get; set; }
    int Age { get; set; }
}

public class Person : IPerson
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// 필드를 사용한 인터페이스 구현
public class Person : IPerson
{
    private string _name;
    private int _age;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int Age
    {
        get => _age;
        set => _age = value;
    }
}

8. 자동 매핑: 공개 속성은 ORM에서 기본적으로 테이블 컬럼에 매핑됩니다.
	2.	유지보수성: 속성을 사용하면 데이터 접근을 캡슐화하여 코드 확장과 유지보수가 용이합니다.
	3.	ORM 호환성: 필드 대신 속성을 사용하면 ORM과의 호환성이 높아집니다.

자동 속성은 ORM과의 연동에서 특히 유리합니다. 필드를 사용할 경우 추가적인 작업이 필요하며,
잘못된 매핑으로 인해 데이터가 테이블에 저장되지 않거나 불러올 수 없는 문제가 발생할 수 있습니다.
ORM을 사용하는 프로젝트에서는 속성을 기본으로 사용하는 것이 가장 안전하고 유지보수에 유리합니다.

( 요약 )

자동 속성은 단순히 필드를 대체하는 도구가 아니라, 데이터 캡슐화, 코드 간결화, 유지보수성, 유연성, 그리고 다양한 프레임워크와의 호환성 면에서 훨씬 강력한 도구입니다.
이 외에도 코드 가독성과 미래 확장 가능성 측면에서 항상 권장됩니다.
 */
