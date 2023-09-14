using System;

var calc = new Calulate();

// 1번
{
    Console.Write("수를 입력하세요 : ");
    string? input = Console.ReadLine() ?? "1";
    double arg = Convert.ToDouble(input);

    Console.WriteLine($"결과 : {calc.Square(arg)}");
}


// 2번
{
    double mean = 0;
    calc.Mean(1, 2, 3, 4, 5, ref mean);
    Console.WriteLine($"평균 : {mean}");
}

// 3번
{
    int a = 3;
    int b = 4;
    int resultA;
    calc.Plus(a, b, out resultA);
    Console.WriteLine($"{a} + {b} = {resultA}");

    double x = 2.4;
    double y = 3.1;
    double resultB;
    calc.Plus(x, y, out resultB);
    Console.WriteLine($"{x} + {y} = {resultB}");
}


public class Calulate
{
    // 1번 답 
    public double Square(double arg) => arg * arg;
    
    // 2번 답 : out keywork 
    // mean 변수가 이곳에 오기전에 초기화 되었으므로 ref 키워드를 사용했음,  
    // 다만, 3번 문제가 out 키워드를 사용해서
    // 깔 맞춤을 해야 하나 했으나, 원측 대로 ref 를 사용했음...
    // 물론 ref 를 out 키워드로 변경 사용가능함 
    // 또한 out 은 초기화 해도 이전 값은 모두 무시 됨으로 초기화를 하지 않아도 됨
    // (요약) mean = 0 으로 초기화를 했으므로 ref를 권장. 보편적으로 뚝 떨어져 있으면 ref, 로컬 변수일 때 out
    public void Mean(double a, double b, double c, double d, double e, ref double mean)
    => mean = (a + b + c + d + e) / 5;

    public void Plus(int a, int b, out int c) => c = a + b;
    
    // 3번 답 : 파라미터 타입변경 
    public void Plus(double a, double b, out double c) => c = a + b;
}
