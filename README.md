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
### '
# Change `class1` to StringLibrary and namespace common-name like `UtilityLibraries`

dotnet build

## run
dotnet run --project ShowCase/ShowCase.csproj
```

## Redis

- nuget
  - Microsoft.Extensions.Caching.StackExchangeRedis
    - .NET CLI `$ dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis`
