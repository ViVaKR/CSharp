namespace Tutor.Abstract;

public class DerivedClass : BaseClass
{
    public override int X
    {
        get => _x + 10;
    }

    public override int Y
    {
        get => _y + 10;
    }

    public override void AbstractMethod()
    {
        _x++;
        _y++;
    }
}
