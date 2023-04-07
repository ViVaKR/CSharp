# CSharp (C#)

## Create Solution

```bash
    # Create new Solution
    dotnet new sln --output Solution.Demos
    
    # Create new Project
    dotnet new console --name Demo-Console --output Demo-Console
    
    # Add Project 
    dotnet sln add Projects/VivConsole 
    
    # Remove Project
    dotnet sln VivSolution.sln remove Projects/VivConsole/VivConsole.csproj
    # Get Solution Project list
    dotnet sln list
    
    dotnet build
    
    dotnet restore
```

## Projects Info

1. Demo-Console
2. Demo-WebApi
3. Demo-WebApp
