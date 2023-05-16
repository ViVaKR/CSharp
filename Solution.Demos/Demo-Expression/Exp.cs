
using System.Linq.Expressions;

public class Exp
{
    public void Run()
    {
        Expression<Func<int, bool>> test = i => i > 5;
        ParameterExpression exParam = Expression.Parameter(typeof(int), "i"); // Left
        ConstantExpression exConst = Expression.Constant(5, typeof(int)); // Right
        BinaryExpression exBinary = Expression.GreaterThan(exParam, exConst); // Left, Right

        Expression<Func<int, bool>> func =
            Expression.Lambda<Func<int, bool>>(exBinary, exParam); // body, parameters
        
        Func<int, bool> deleA = func.Compile();
        Func<int, bool> deleB = func.Compile();

        Console.WriteLine(deleA.DynamicInvoke(2));
        Console.WriteLine(deleB.DynamicInvoke(6));
    }

    private void Example()
    {
        Expression<Func<int, bool>> exp = i => i > 5;
        BinaryExpression binary = (BinaryExpression)exp.Body;
        Console.WriteLine(binary);
        Console.WriteLine(binary.Left);
        Console.WriteLine(binary.NodeType);
        Console.WriteLine(binary.Right);

        ParameterExpression exp3;
        Expression<Func<int, bool>> expr =
        Expression.Lambda<Func<int, bool>>(
            Expression.GreaterThan(exp3 = Expression.Parameter(typeof(int), "i"),
            Expression.Constant(5, typeof(int))),
            new ParameterExpression[] { exp3 });

        Console.WriteLine(expr.Compile().DynamicInvoke(12));
        Console.WriteLine(expr.Compile().DynamicInvoke(3));
    }
}
