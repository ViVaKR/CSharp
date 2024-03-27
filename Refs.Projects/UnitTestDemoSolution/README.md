# Unit Test

## Create Solution And Projects With UnitTest

```zsh
    // (1) Create Solution (솔루션 생성)
    dotnet new sln -o DemoSolution
    cd DemoSolution

    // (2) Create Libraries (라이브러리 클래스 생성)
    dotnet new classlib -o StringLibrary
    dotnet sln add StringLibLibrary

    // (3) Create console project (메인 콘솔 프로젝트 생성)
    dotnet new console -o ShowCase
    dotnet add ShowCase reference StringLib
    dotnet sln add ShowCase
    
    // run test
    dotnet run --project ShowCase

    // (4) Create Unit Test (단위 테스트 프로젝트 생성)
    dotnet new mstest -o StringLibraryTest
    dotnet add StringLibraryTest StringLibrary
    dotnet sln add StringLibraryTest

    // (final) Run Test : (테스트 실행 :`Solution Root`)
    dotnet test StringLibraryTest
```

<!-- 
    * Assert.AreEqual	두 개의 값이나 개체가 같은지를 확인합니다. 값이나 개체가 같지 않으면 어설션이 실패합니다.

    * Assert.AreSame	두 개의 개체 변수가 같은 개체를 참조하는지를 확인합니다. 변수가 서로 다른 개체를 참조하면 어설션이 실패합니다.

    * Assert.IsFalse	조건이 false인지 확인합니다. 조건이 true이면 어설션이 실패합니다.

    * Assert.IsNotNull	개체가 null이 아닌지를 확인합니다. 개체가 null이면 어설션이 실패합니다.
 -->