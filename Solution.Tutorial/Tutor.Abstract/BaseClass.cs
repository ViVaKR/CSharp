namespace Tutor.Abstract;

public abstract class BaseClass
{
    protected int _x = 100;
    protected int _y = 150;

    // Abstract method
    public abstract void AbstractMethod();

    // Abstract Properties
    public abstract int X { get; }
    public abstract int Y { get; }
}
