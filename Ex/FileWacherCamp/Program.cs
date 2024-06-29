using FileWacherCamp;

var name = Console.ReadLine();
Console.WriteLine(name);

// VivWatcher.Run();
uint a = 0xFABCDE45;

Console.WriteLine(a);




//------------       0xFF          0xFF          0xFF          0xFC
//------------[0b_1111_1111, 0b_1111_1111, 0b_1111_1111, 0b_1111_1100];
//------------      (0)           (1)           (2)           (3)
byte[] demo = [0xFF, 0xFF, 0xFF, 0xFc];
byte[] arrm = [0b_1111_1100, 0b_1111_1111, 0b_1111_1111, 0b_1111_1111];

// 하여, 까꾸로 비트연산하는 장면, 즉, 앞에는 가만 두고 뒤에것을 3번에 맞추어 | 연산 을 시행..
var j = arrm[3] | (arrm[2] << 8) | (arrm[1] << 16) | (arrm[0] << 24);


Console.WriteLine(j); //--> -4

// 위의 Shift 연산이 묘하게 도 --> (-4) 가 나오는 이유
//                                1111_1100  (3) , 가만 둠
//                      1111_1111_0000_0000  (2) , 왼쪽으로 8비트 시프트
//            1111_1111_0000_0000_0000_0000  (1) , 왼쪽으로 16비트 시프트
//  1111_1111_0000_0000_0000_0000_0000_0000  (0) , 왼쪽으로 12비트 시프트
// ----------------------------------------  (or), 비트 연산
//  1111_1111_1111_1111_1111_1111_1111_1100  (결과값)
//  0000_0000_0000_0000_0000_0000_0000_0011  (비트반전, 1의 보수)
//                                       +1  (더하기 + 1, 2의 보수)
//  1111_1111_1111_1111_1111_1111_1111_0100  (4)
//                        마이너스 부호 달아 주기 (-4)

byte[] arr = [0b_0000_0000, 0b_0000_0000, 0b_0000_0001, 0b_0000_0001];
var k = arr[3] | (arr[2] << 8) | (arr[1] << 16) | (arr[0] << 24);
Console.WriteLine(k);


byte[] arrA = [0xFF, 0xFF, 0xFF, 0xFC];

byte[] arrB = [0b_1111_1100, 0b_1111_1111, 0b_1111_1111, 0b_1111_1111];

uint m = 0xFFCCBBAA;
Console.WriteLine(m);

uint md = 42_9160_7466; //== 0xFFCCBBAA

var ms = md.ToString("X");
Console.WriteLine(ms);
int decValue = int.Parse(ms, System.Globalization.NumberStyles.HexNumber);


int min = int.MinValue;
Console.WriteLine(Convert.ToString(min, toBase: 2));

int max = int.MaxValue;
Console.WriteLine(Convert.ToString(max, toBase: 2)); // 7F FF FF FF

sbyte minByte = sbyte.MinValue; // -128, byte Min: 0
// 1111_1111_1000_0000
Console.WriteLine(Convert.ToString(minByte, toBase: 2));

