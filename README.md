# CSharp (C#)

## Create Solution

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
```

## VSCode Intellisense

1. VSCode Editor : `Ctrl + Shift + p`
2. `OmniSharp 프로젝트 선택` 을 선택하고 Enter 키를 누릅니다.
3. 솔루션 작업 영역 항목을 선택합니다.

## Include Resource : `.csproj`

```xml
    <ItemGroup>
        <Content Include="test.txt">
            <CopyToOutputDirectory>Always</CopyToOutputDirectory>
        </Content>
    </ItemGroup>
```

## Create `class library`

```bash
dotnet new sln
dotnet new classlib -o StringLibrary
dotnet sln add StringLibrary

# editing StringLibrary class...
dotnet build

# create new console app project to the solution
# $ dotnet new console -o ShowCase 
dotnet add ShowCase reference StringLibrary

# ShowCase.csproj 
### '
  <ItemGroup>
    <ProjectReference Include="..\StringLib\StringLib.csproj" />
  </ItemGroup>
### `
---

## IEnumerable, ICollection, IList And List

|Interface|Scenario|
|-|-|
|IEnumerable<br/>IEnumerable<T>| The only thing you want is to iterate over the elements in a collection. You only need read-only access to that collection.|
|ICollection, ICollection<T>|You want to modify the collection or you care about its size.|
|IList, IList<T>|You want to modify the collection and you care about the ordering and / or positioning of the elements in the collection.|
| List<br/>List<T> |Since in object oriented design you want to depend on abstractions instead of implementations, you should never have a member of your own implementations with the concrete type List/List.|


(Ref.) [When To Use IEnumerable, ICollection, IList And List](https://www.claudiobernasconi.ch/2013/07/22/when-to-use-ienumerable-icollection-ilist-and-list/)

---

## Redis

- nuget
  - Microsoft.Extensions.Caching.StackExchangeRedis
    - .NET CLI `$ dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis`


---

