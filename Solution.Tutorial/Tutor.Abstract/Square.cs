namespace Tutor.Abstract;

public abstract class Shape
{
    public abstract int GetArea();
}

public class Square : Shape
{
    private readonly int _side;

    public Square(int side) => _side = side;

    public override int GetArea()=> _side * _side;
}
