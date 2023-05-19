using System.Linq.Expressions;

#region Basic

{
    //! BlockExpression : 변수를 정의할 수 있는 식의 시퀀스가 포함된 블록을 표현
    BlockExpression blockExpr = Expression.Block(
        Expression.Call(
            null,
            typeof(Console).GetMethod("Write", new Type[] { typeof(string) }),
            Expression.Constant("Hello")
        )
    );

    var result = Expression.Lambda<Action>(blockExpr).Compile();

    foreach (var expr in blockExpr.Expressions)
        Console.WriteLine(expr.ToString());

    Console.WriteLine();

    //! ContantExpression : 상수값이 있는 식
    Expression constant = Expression.Constant(5.5);
    Console.WriteLine(constant);
    double num = 3.4;
    constant = Expression.Constant(num);
    Console.WriteLine(constant);
    Console.WriteLine();

    //! BinaryExpression : 이항 연산자가 있는 식
    Console.WriteLine("BinaryExpression");
    ExpressionType type = ExpressionType.Subtract;
    ConstantExpression a = Expression.Constant(53);
    ConstantExpression b = Expression.Constant(14);
    BinaryExpression binary = Expression.MakeBinary(type, a, b);
    Console.WriteLine(binary);
    Console.WriteLine();

    //! CatchBlock : try 블록의 catch 문을 나타냄

    //! ConditionalExpression : 조건부 연산자가 있는 식
    num = 100;
    Expression condition = Expression.Condition(
         Expression.Constant(num > 10),
        Expression.Constant("number is greater than 10"),
        Expression.Constant("number is smaller than 10")
    );
    Console.WriteLine(condition);

    var compile = Expression.Lambda<Func<string>>(condition).Compile();
    Console.WriteLine(compile());

    //! LambdaExpression : 람다식, 메서드 본문과 유사한 코드 블록을 캡처함

    //* 파라미터
    ParameterExpression paramA = Expression.Parameter(typeof(int), "a");
    ParameterExpression paramB = Expression.Parameter(typeof(int), "b");
    Expression constantA = Expression.Constant(10);
    Expression constantB = Expression.Constant(50);

    //* one parameter, lambda expression
    Expression add = Expression.Add(paramB, constantB);
    Expression sub = Expression.Subtract(paramA, constantA);
    Expression mul = Expression.Multiply(paramA, constantA);
    Expression div = Expression.Divide(paramA, constantA);

    //* (a, b) =>
    List<ParameterExpression> exprList = new List<ParameterExpression> { paramA, paramB };

    //* (a, b)=> (a + 10)
    LambdaExpression lambda = Expression.Lambda(mul, exprList);
    Console.WriteLine(lambda);  // arg => (arg + 1)

    object obj = lambda.Compile().DynamicInvoke(3, 2);
    Console.WriteLine(obj);

    //! Default Expression : 형식 또는 빈 식의 기본값을 나타냄, default
    Expression defaultA = Expression.Default(typeof(bool));
    Console.WriteLine(defaultA);
    Console.WriteLine(Expression.Lambda<Func<bool>>(defaultA).Compile()());

    //! ParameterExpression : 명명된 매개 변수 식을 나타냄

    ParameterExpression paramC = Expression.Parameter(typeof(int), "k");
    Console.WriteLine(paramC);
    Expression method = Expression.Call(
        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }),
        paramC);
    Console.WriteLine(method);
    Expression.Lambda<Action<int>>(method, new ParameterExpression[] { paramC }).Compile()(45);
}

#endregion

var exp = new Exp();
exp.Run();

#region 사칙연산 ( Add, Substract, Multiply, Divide )
{
    ParameterExpression paramA = Expression.Parameter(typeof(double), "i");
    ParameterExpression paramB = Expression.Parameter(typeof(double), "j");
    ParameterExpression[] parameters = new ParameterExpression[] { paramA, paramB };
    Expression[] bodies = new[] {
        exp.AddEx(paramA, paramB),
        exp.SubEx(paramA, paramB),
        exp.MulEx(paramA, paramB),
        exp.DivEx(paramA,paramB)
    };
    exp.PrintEx(badies: bodies, parameters: parameters, a: 3.14, b: 5.34);
}
#endregion


#region AddChecked, ConvertChecked
{
    short left = short.MaxValue;
    short right = 1;

    var a = Expression.Constant(left);
    var b = Expression.Constant(right);

    var sum = Expression.Add(a, b);
    var convert = Expression.ConvertChecked(sum, typeof(short));
    var convertLambda = Expression.Lambda<Func<short>>(convert);
    var convertFunc = convertLambda.Compile();
    Console.WriteLine($"{convert} Convertion : {convertFunc()}");

    var sumLambda = Expression.Lambda<Func<short>>(sum);
    var sumFunc = sumLambda.Compile();
    Console.WriteLine($"Sum : {sumFunc()}");

}
#endregion

{
    Expression<Func<int, int, bool>> expr1 = (a, b) => a > b;
    
}
