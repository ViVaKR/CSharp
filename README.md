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

## Intellisense

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
