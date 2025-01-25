using Generics;

var calc = new Calculater<int>();

Console.WriteLine(calc.Add(10, 20));
Console.WriteLine(calc.Subtract(10, 20));
Console.WriteLine(calc.Multiply(10, 20));
Console.WriteLine(calc.Divide(10, 20));

