using System.Linq.Expressions;
using System.Reflection;

public class AllExp
{

    public void GetExpressionType(ExpressionType type)
    {
        switch (type)
        {
            case ExpressionType.Add: break;
            case ExpressionType.AddChecked: break;
            case ExpressionType.And: break;
            
            case ExpressionType.AndAlso: break;
            case ExpressionType.ArrayLength: break;
            case ExpressionType.ArrayIndex: break;
            case ExpressionType.Call: break;
            case ExpressionType.Coalesce: break;
            case ExpressionType.Conditional: break;
            case ExpressionType.Constant: break;
            case ExpressionType.Convert:
                {
                    Expression convert = Expression.Convert(Expression.Constant(5.38475), typeof(int));
                    Console.WriteLine(convert);
                    var lambda = Expression.Lambda<Func<int>>(convert);

                    Console.WriteLine(lambda.ToString());
                    Console.WriteLine(lambda.Compile()());
                }
                break;
            case ExpressionType.ConvertChecked:
                break;
            case ExpressionType.Divide:
                break;
            case ExpressionType.Equal:
                break;
            case ExpressionType.ExclusiveOr: // (2진수) 같으면 0, 다르면 1이 아닌 숫자
                {
                    BinaryExpression exorExpr = Expression.ExclusiveOr(Expression.Constant(27), Expression.Constant(30));

                    var lambda = Expression.Lambda<Func<int>>(exorExpr);
                    Console.WriteLine(lambda.Compile()());
                    Console.WriteLine(Convert.ToString(27, 2));
                    Console.WriteLine(Convert.ToString(30, 2));
                    Console.WriteLine(Convert.ToString(lambda.Compile()(), 2).PadLeft(5, '0'));
                }
                break;
            case ExpressionType.GreaterThan:
                break;
            case ExpressionType.GreaterThanOrEqual:
                break;
            case ExpressionType.Invoke:
                break;
            case ExpressionType.Lambda: break;
            case ExpressionType.LeftShift:
                break;
            case ExpressionType.LessThan:
                break;
            case ExpressionType.LessThanOrEqual:
                break;
            case ExpressionType.ListInit:
                break;
            case ExpressionType.MemberAccess:
                break;
            case ExpressionType.MemberInit:
                break;
            case ExpressionType.Modulo:
                break;
            case ExpressionType.Multiply:
                break;
            case ExpressionType.MultiplyChecked:
                break;
            case ExpressionType.Negate:
                break;
            case ExpressionType.UnaryPlus:
                break;
            case ExpressionType.NegateChecked:
                break;
            case ExpressionType.New:
                {
                    //Type t = typeof(Student);
                    //ConstructorInfo constructor = t.GetConstructor(new[] { typeof(string) });
                    //if(constructor == null) return;
                    //var param = Expression.Parameter(typeof(string), "fullName");
                    //var instence = Expression.New(constructor, param);
                    //var lambda = Expression.Lambda<Action<string>>(instence, param);
                    //Console.WriteLine(lambda);
                    //var action = lambda.Compile();
                    //action("Jang");

                    Func<string, Student> create = CreateCreator<string, Student>();
                    var student = create("JangGilSan");

                    Func<Student> create2 = CreateDefaultInstance<Student>();
                    var student2 = create2();


                    // 파라미터 생성자
                    Func<TArg, T> CreateCreator<TArg, T>()
                    {
                        var constructor = typeof(T).GetConstructor(new[] { typeof(TArg) });
                        var parameter = Expression.Parameter(typeof(TArg), "p");
                        if (constructor == null) return null;
                        var lambda = Expression.Lambda<Func<TArg, T>>(Expression.New(constructor, parameter), parameter);
                        return lambda.Compile();
                    }

                    // 기본 생성자
                    Func<T> CreateDefaultInstance<T>()
                    {
                        var constructor = typeof(T).GetConstructor(Type.EmptyTypes);
                        if (constructor == null) return null;
                        var lambda = Expression.Lambda<Func<T>>(Expression.New(constructor));
                        return lambda.Compile();
                    }
                }
                break;
            case ExpressionType.NewArrayInit:
                break;
            case ExpressionType.NewArrayBounds:
                break;
            case ExpressionType.Not:
                break;
            case ExpressionType.NotEqual:
                break;
            case ExpressionType.Or:
                break;
            case ExpressionType.OrElse:
                break;
            case ExpressionType.Parameter:
                {
                    ParameterExpression param = Expression.Parameter(typeof(int));
                    MethodInfo method = typeof(Console).GetMethod("WriteLine", new[] { typeof(int) });
                    if (method == null) return;
                    MethodCallExpression methodCall = Expression.Call(method, param);
                    var lambda = Expression.Lambda<Action<int>>(methodCall, param);
                    var action = lambda.Compile();
                    action(45);
                }
                break;
            case ExpressionType.Power:
                {

                }
                break;
            case ExpressionType.Quote:
                {
                }
                break;
            case ExpressionType.RightShift:
                {
                }
                break;
            case ExpressionType.Subtract:
                break;
            case ExpressionType.SubtractChecked:
                break;
            case ExpressionType.TypeAs:
                break;
            case ExpressionType.TypeIs:
                break;
            case ExpressionType.Assign:
                {
                    ParameterExpression variablExpr = Expression.Variable(typeof(string), "message");
                    BinaryExpression assignExpr = Expression.Assign(variablExpr, Expression.Constant("Hello World"));
                    BlockExpression blockExpr = Expression.Block(new[] { variablExpr }, assignExpr);
                    var lambda = Expression.Lambda<Func<string>>(blockExpr);
                    Console.WriteLine(lambda.Compile()());
                }
                break;
            case ExpressionType.Block:
                {
                    ParameterExpression p = Expression.Variable(typeof(int), "i");
                    ConstantExpression c = Expression.Constant(55, typeof(int));
                    BinaryExpression assign = Expression.Assign(p, c);

                    BinaryExpression add = Expression.Add(p, Expression.Constant(23));
                    BlockExpression block = Expression.Block(new[] { p }, assign, Expression.Add(p, add));
                    Console.WriteLine(block);
                    Expression<Func<int>> lambda = Expression.Lambda<Func<int>>(block);
                    Func<int> func = lambda.Compile();
                    Console.WriteLine(func());
                }
                break;
            case ExpressionType.DebugInfo:
                break;
            case ExpressionType.Decrement:
                break;
            case ExpressionType.Dynamic:
                break;
            case ExpressionType.Default:
                break;
            case ExpressionType.Extension:
                break;
            case ExpressionType.Goto:
                break;
            case ExpressionType.Increment:
                break;
            case ExpressionType.Index:
                break;
            case ExpressionType.Label:
                break;
            case ExpressionType.RuntimeVariables:
                break;
            case ExpressionType.Loop:
                break;
            case ExpressionType.Switch:
                break;
            case ExpressionType.Throw:
                break;
            case ExpressionType.Try:
                break;
            case ExpressionType.Unbox:
                break;
            case ExpressionType.AddAssign:
                break;
            case ExpressionType.AndAssign:
                break;
            case ExpressionType.DivideAssign:
                break;
            case ExpressionType.ExclusiveOrAssign:
                break;
            case ExpressionType.LeftShiftAssign:
                break;
            case ExpressionType.ModuloAssign:
                break;
            case ExpressionType.MultiplyAssign:
                break;
            case ExpressionType.OrAssign:
                break;
            case ExpressionType.PowerAssign:
                break;
            case ExpressionType.RightShiftAssign:
                break;
            case ExpressionType.SubtractAssign:
                break;
            case ExpressionType.AddAssignChecked:
                break;
            case ExpressionType.MultiplyAssignChecked:
                break;
            case ExpressionType.SubtractAssignChecked:
                break;
            case ExpressionType.PreIncrementAssign:
                break;
            case ExpressionType.PreDecrementAssign:
                break;
            case ExpressionType.PostIncrementAssign:
                break;
            case ExpressionType.PostDecrementAssign:
                break;
            case ExpressionType.TypeEqual:
                break;
            case ExpressionType.OnesComplement:
                break;
            case ExpressionType.IsTrue:
                break;
            case ExpressionType.IsFalse:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }

    public Student()
    {
        Console.WriteLine("Hi Everyone");
    }
    public Student(string fullName)
    {
        FullName = fullName;
        Console.WriteLine($"{FullName} Hello World");
    }
    public int AddNumber(int arg1, int arg2)
    {
        return arg1 + arg2;
    }
}
