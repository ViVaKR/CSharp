

const ulong ul = 0b_00000000_00000000_00000000_0000000_00000000_00000000_00000000_0000001UL; // 접미사 UL (unsigned long)
Console.WriteLine($"==> UnSigned Long 접미사 붙이면 left shift `1UL << 61` 은 정상작동\n==> {ul << 61}" +
                  $"\n==> 0b_10000000_00000000_00000000_0000000_00000000_00000000_00000000_0000000UL\n\n");

Console.WriteLine($"==> 접미사 없이 left shift << 61 은 int 판정으로 오버플로 부터는, 처음 부터 다시 인덱싱\n");
for (var i = 1; i <=61; i++)
{
    if (i == 31)
    {
        const int temp = 1 << 31;
        // 31번째가 부호 비트이므로 unsigned 는 에러 발생 함으로, signed 로 대체 출력
        Console.WriteLine($"1 << 31\t=>\t{temp} (32비트 부호 비트 부분.)");
        continue;
    }; 
    
    // 접미사 없으면 Int32 로 판정 32 번이 되면 0번째 인덱스로 되돌아감..
    Console.WriteLine($"1 << {i}\t=>\t{1 << i}"); 
}

Console.WriteLine($"==> int (i << 61) 한바퀴 돌아서 아래와 같이 29번째 자리함으로 ==> 536_870_912 가 출력됨\n==> 0b_10000000_00000000_00000000_0000000_00100000_00000000_00000000_0000000UL\n\n");