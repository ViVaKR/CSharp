namespace Demo_TypeConversion;
class Program
{
    static void Main(string[] args)
    {
        // 화씨를 섭씨로...
        double degree = 85.5; // => 29.7 C'
        Fahrenheit f1 = new Fahrenheit(degree);
        Celsius c1 = (Celsius)f1;
        c1.Output(degree, false);

        // 섭씨를 화씨로...
        double celsius = 29.7; // => 85.5 F'
        Celsius c2 = new Celsius(celsius);
        Fahrenheit f2 = (Fahrenheit)c2;
        f2.Output(celsius, true);

        // 암묵적인 형변화
        var d = new Digit(7);
        byte number = d;
        Digit digit = (Digit)number;
        Console.WriteLine(digit);
    }
}
