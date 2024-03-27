# CSharp (C#)

## Create New Solution & Add New Project, Library

```bash

    # Create new Solution
    dotnet new sln --output Solution.Demos
    
    # Create new Project : 
    # with main -> $ dotnet new console --use-program-main
    dotnet new console --name Demo-Console --output Demo-Console
    
    # Add Project 
    dotnet sln add VivConsole 
    
    # Remove Project
    dotnet sln remove VivConsole
    
    # Get Solution Project list
    dotnet sln list
    
    # Solution build
    dotnet build
    
    # Solution restor
    dotnet restore

    # Add Reference
    dotnet add Demo-JiSikin.csproj reference ../Libs/Libs.csproj

    # Add Package examples 
    dotnet add Solution.Demos/BootCamp/BootCamp.csproj package Microsoft.Extensions.Hosting
    dotnet add Solution.Demos/BootCamp/BootCamp.csproj package Microsoft.Extensions.Configuration.Binder
    dotnet add Solution.Demos/BootCamp/BootCamp.csproj package Microsoft.Extensions.Configuration.Json
    dotnet add Solution.Demos/BootCamp/BootCamp.csproj package Microsoft.Extensions.Configuration.EnvironmentVariables

    dotnet new classlib -o StringLibrary
    dotnet sln add StringLibrary

    # editing StringLibrary class...
    dotnet build

    # create new console app project to the solution
    $ dotnet new console -o ShowCase 
    dotnet add ShowCase reference StringLibrary
```

## Include Resource : `.csproj`

```xml
    <ItemGroup>
        <Content Include="test.txt">
            <CopyToOutputDirectory>Always</CopyToOutputDirectory>
        </Content>
    </ItemGroup>
```

## Access Modifiers (접근 한정자)

* public : 엑세스 제한 없음
* protected : 엑세스가 파생 클래스로 제한됨
* internal : 엑세스가 현재 어셈블리로 제한됨
* protected internal : 엑세스가 현재 어셈블리 또는 포함하는 클래스에서 파생 클래스로 제한됨
* private : 엑세스가 포함하는 형식으로 제한됨
* private protected : 엑세스가 포함하는 클래스 또는 파생 클래스로 제한됨

## Async

* 메서드, 람다, 무명 메서드를 비동기로 지정함
* 메서드 또는 식에 사용하면 비동기 메서드라고 함
