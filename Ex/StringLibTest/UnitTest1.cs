namespace StringLibTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
    }
}

/*
[TestClass] 로 태그가 지정된 테스트 클래스 에서
[TestMethod] 태그로 지정된 테스트 메서드를 만들어서 테스트를 진행할 수 있다.

--> 테스트 메서드는 오류가 발생하거나 모든 테스트가 성공적으로 수행되면 종료됨.
--> 일반적으로 Assert 클래스의 메서드를 사용하여 테스트 결과를 확인함.

[ 주요 메서드 ]
* Assert.AreEqual : 두 값이 같은지 확인, 같으면 성공, 다르면 실패
* Assert.AreNotEqual : 두 값이 다른지 확인, 다르면 성공, 같으면 실패
* Assert.IsTrue : 조건이 참인지 확인, 참이면 성공, 거짓이면 실패
* Assert.IsFalse : 조건이 거짓인지 확인, 거짓이면 성공, 참이면 실패
* Assert.IsNull : 값이 null인지 확인, null이면 성공, null이 아니면 실패

 */
