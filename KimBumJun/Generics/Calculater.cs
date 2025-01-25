using System.Numerics;
namespace Generics;
public class Calculater<T> where T : INumber<T>
{
    public T Add(T a, T b) => a + b;
    public T Subtract(T a, T b) => a - b;
    public T Multiply(T a, T b) => a * b;
    public T Divide(T a, T b) => a / b;
}


public class ComplexNumber
{
    //
}
