
using System.Security.Cryptography;
using System.Text.Json;


// var randomNumber = new byte[32];
// using RandomNumberGenerator rng = RandomNumberGenerator.Create();

// rng.GetBytes(randomNumber);
// Console.WriteLine(Convert.ToBase64String(randomNumber));

// string json = @"{ ""car"" : { ""Name"" : ""Sonata"" }, ""test"" : ""abc"" }";

// var car = System.Text.Json.JsonDocument.Parse(json).RootElement.GetProperty("car").GetProperty("Name").GetString();

// Console.WriteLine(car);
// Console.WriteLine(json);
// var helloWorld = "Hello World";
// string test = $@"He said to me, "" {helloWorld} "". How are you?";
// Console.WriteLine(test);

//--> C# 언어의 대 원칙 -> 문자열은 큰따옴표(좌, 우) 한쌍으로 묶는다.
string str = "Hello World";
Console.WriteLine(str);

// 문자열에서 골뱅이(@) 기호는 -> verbatim (버`베이르~음) -> 말 그대로 해석하면 '원문대로' 라는 뜻.
// 골뱅이 기호를 사용하면, 문자열에서 이스케이프 의미로의 역슬래시 기호를 사용하지 않아도 되지만
// 문자열을 감싼 한쌍의 큰 따옴표 내부에 또 다른 큰따옴표를 사용할 수는 없다. 컴파일타임 에러 발생.
// 하지만 큰따옴표를 두번 사용하면 (역슬래시 탈출과 동일),
// 골뱅이 치하에서도 문자열 내부에서 큰따옴표를 사용할 수 있다.

// *** 예시 ***//
// C# 뿐만 아니라 대부분의 언어에서
//  \ (역슬래시) 는 탈출문자로 사용되기 때문에, 문자열에서 역슬래시 기호를 문자 그대로의 의미로 사용하려면
// 그 역슬래시 문자의 탈출 의미를 -> 탈출시키는 의미로, 두번 사용해야 한다.
// 단 역슬래시 기호를 사용하지 않고, 골뱅이 기호를 사용하면, 문자열에서 역슬래시 기호를 사용하지 않아도 된다.
// 즉, @ (verbatim) 문자열 리터럴의 탄생 이유 중 하나는,
// 윈도우 운영 체제의 여러 문제점 중 하나인 경로 구분자로 역슬래시를 채택한 것에서 비롯됩니다.
string path = "C:\\Users\\User\\Desktop\\C#\\NewFeature"; // 일반적인 문자열 리터럴, 매우 불편하고 가독성이 떨어짐.
Console.WriteLine(path);
path = @"C:\Users\User\Desktop\C#\NewFeature"; // 핵심, 가독성이 좋고, 역슬래시 기호를 사용하지 않아도 된다.
Console.WriteLine(path);


// 다른 예시로, 말그대로 연산자 @(골뱅이, 버`베^이르음, verbatim, 엣, 앳, at) + json 문자열을 사용할 때,
// 특성상 json 문자열 내부에서 또 다시 큰따옴표를 사용하여야 하는데?
// 큰따옴표를 두번으로 탈출의 의미와 동일하다..
string jsonRaw = @"{ ""car"" : { ""Name"" : ""Sonata"" } , ""test"" : ""abc"" }";
Console.WriteLine($"골뱅이 치하 탈출문자: {jsonRaw}");

// 문자열에서 역슬래시 기호는 -> escape -> '탈출하다' 라는 뜻이다.
string escape = "{ \"car\" : { \"Name\" : \"Sonata\" } , \"test\" : \"abc\" }";
Console.WriteLine($"보편적 탈출문자: {escape}");

// json 문자열은 큰따옴표가 다수 포함되어 있기 때문에, 좌, 우 큰따옴표를 제외한 내부 큰따옴표를 사용할 때는 탈출문자를 사용해야 한다.
// 가장 기본이 되는 탈출 문자는 역슬래시 기호를 사용하여, 큰따옴표를 탈출시킨다.
// 대안 : 탈출문자를 사용하지 않고, 큰 따옴표 3(""" 블라블라 """)개를 사용하여 문자열을 표현하면, 큰따옴표를 탈출시키지 않아도 된다.
// 영어로는 triple quote 라고 한다.
// C# 에서는 큰따옴표 3개를 사용하여 문자열을 표현할 때, 문자열 내부에서 별다른 탈출문자를 사용하지 않아도 된다.
string json = """{ "car" : { "Name" : "Sonata" } , "test" : "abc" }""";
Console.WriteLine(json);

// json 문자열을 파싱하여, json 문자열을 출력하고, car, test 값을 출력하는 예시 ...
var rawString = JsonDocument.Parse(json).RootElement.GetRawText();
Console.WriteLine($"json: {rawString}");
var car = JsonDocument.Parse(json).RootElement.GetProperty("car").GetProperty("Name").GetString();
Console.WriteLine($"car: {car}");
var test = JsonDocument.Parse(json).RootElement.GetProperty("test").GetString();
Console.WriteLine($"test: {test}");

return;

// var x = 3;
// var y = 4;

// unsafe
// {
//     var ptr = &x;
//     Console.WriteLine((IntPtr)ptr);
//     Console.WriteLine(*ptr);
// }
// Swap(ref x, ref y);
// return;

// static void Swap(ref int a, ref int b) // ref int a, b 는 메모리 주소를 전달 하고 있다.
// {
//     /*
//      * static Swap 함수 내부에서 fixed가 필요한 이유는 ref 매개변수의 주소를 가져오기 위함이고,
//      * ref 매개변수는 스택에 저장되지만,
//      * 객체일 경우에는 가비지 컬렉터에 의해 이동될 수 있는 힙에 있는 객체를 참조할 수 있음으로,
//      * fixed 문을 사용하여  해당 변수의 주소를 고정하여 C# 에서 포인터를 안전하게 사용할 수 있기 때문에 사용함.
//      */
//     unsafe
//     {
//         fixed (int* ptr = &a, ptr2 = &b)
//         {
//             Console.Write("ptr: a address: ");
//             Console.WriteLine($"{(IntPtr)ptr:X}");

//             Console.Write("ptr2: b address: ");
//             Console.WriteLine($"{(IntPtr)ptr2:X}");

//             Console.Write("ptr: a value: ");
//             Console.WriteLine(*ptr);
//         }
//         Console.WriteLine($"a: {a}, b: {b}");
//         // int temp = a; // 여기서 a 는 x 의 값을 가지고 있음으로, C# 에서는 ref 키워드를 통해 전달된 변수는 직접 접근할 수 있기 때문에 * 연산자를 사용할 필요가 없음.
//         // a = b;
//         // b = temp;
//         // Console.WriteLine($"inside => a: {a}, b: {b}");
//     }

//     Console.WriteLine($"outside => a: {a}, b: {b}");
//     (a, b) = (b, a); // 구조분해
// }

