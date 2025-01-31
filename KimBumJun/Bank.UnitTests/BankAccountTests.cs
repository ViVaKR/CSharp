namespace Bank.UnitTests;

[TestClass]
public class BankAccountTests
{

    [TestMethod]
    public void Debit_WithValidAmount_UpdatesBalance()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = 20.0;
        // double debitAmount = -100.00;
        // double expected = 7.44;
        BankAccount account = new("Kim Bum Jun", beginningBalance);


        try
        {
            account.Debit(debitAmount);
        }
        catch (Exception ex)
        {

            // Assert
            StringAssert.Contains(ex.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            return;
        }

        Assert.Fail("The expected exception was not thrown.");

        // Act
        // account.Debit(debitAmount);
        // Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));

        // Assert
        // double actual = account.Balance;

        // Act and assert


        // Assert.AreEqual(expected, actual, 0.001, "\n계좌의 상태가 올바르지 않습니다.");

        //--> dotnet test ./Bank.UnitTests --logger "console;verbosity=detailed"
        //--> dotnet test --results-directory ./TestResults --logger "trx;LogFileName=test_results.xml"
    }

    private const string Expected = "Hello World!";
    [TestMethod]
    public void HelloWorldTest()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);
        HelloWorld.SayHello();
        var result = sw.ToString().Trim();

        Assert.AreEqual(Expected, result);
    }




}

/*

--> Assert.AreEqual: 메서드는 두 값이 같은지 확인하는 단위 테스트의 어서션입니다. 이 메서드는 다음과 같은 매개변수를 받습니다:
1.  expected : 예상되는 값입니다.
2.  actual : 실제 값입니다.
3. `delta`: 허용 오차입니다.
4. `message`: 어서션이 실패할 경우 출력될 메시지입니다.

```csharp
Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
```

여기서 `0.001`은 허용 오차를 의미합니다.
즉, expected 와 actual 값이 0.001 이내의 차이를 가지면 두 값은 같다고 간주됩니다.
이는 부동 소수점 연산의 미세한 오차를 허용하기 위해 사용됩니다.

따라서 이 어서션은 expected 와 actual 값이 0.001 이하의 차이를 가지는 경우 테스트가 성공하도록 합니다.
 */


/*
--> `Microsoft.VisualStudio.TestTools.UnitTesting` 네임스페이스에는 다양한 어서션 메서드가 있습니다. 이 메서드들은 테스트 결과를 검증하는 데 사용됩니다. 주요 어서션 메서드는 다음과 같습니다:

1.  Assert.AreEqual(expected, actual, message) : 두 값이 같은지 확인합니다.
2.  Assert.AreNotEqual(notExpected, actual, message) : 두 값이 같지 않은지 확인합니다.
3.  Assert.IsTrue(condition, message) : 조건이 참인지 확인합니다.
4.  Assert.IsFalse(condition, message) : 조건이 거짓인지 확인합니다.
5.  Assert.IsNull(object, message) : 객체가 null인지 확인합니다.
6.  Assert.IsNotNull(object, message) : 객체가 null이 아닌지 확인합니다.
7.  Assert.AreSame(expected, actual, message) : 두 객체가 동일한 인스턴스인지 확인합니다.
8.  Assert.AreNotSame(notExpected, actual, message) : 두 객체가 동일한 인스턴스가 아닌지 확인합니다.
9.  Assert.Fail(message) : 테스트를 실패로 표시합니다.
10.  Assert.ThrowsException<TException>(action, message) : 지정된 예외가 발생하는지 확인합니다.

예제 코드:
```csharp
[TestMethod]
public void TestAssertions()
{
    // Arrange
    int expected = 5;
    int actual = 5;
    object obj = null;
    object notNullObj = new object();

    // Assert
    Assert.AreEqual(expected, actual, "Values are not equal");
    Assert.AreNotEqual(4, actual, "Values are equal");
    Assert.IsTrue(actual == 5, "Condition is false");
    Assert.IsFalse(actual == 4, "Condition is true");
    Assert.IsNull(obj, "Object is not null");
    Assert.IsNotNull(notNullObj, "Object is null");
    Assert.AreSame(notNullObj, notNullObj, "Objects are not the same");
    Assert.AreNotSame(obj, notNullObj, "Objects are the same");
    Assert.ThrowsException<ArgumentNullException>(() => throw new ArgumentNullException(), "Exception not thrown");
}
```

이 메서드들을 사용하여 다양한 조건을 테스트하고 검증할 수 있습니다.

 */
