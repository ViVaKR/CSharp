# Create a web API with ASP.NET Core

## Overview

| API                          | Description             | Request body | Response body        |
| ---------------------------- | ----------------------- | ------------ | -------------------- |
| `GET` /api/todoitems         | Get all to-do items     | None         | Array of to-do items |
| `GET` /api/todoitems/{id}    | Get an item by ID       | None         | To-do item           |
| `POST` /api/todoitems        | Add a new item          | To-do item   | To-do item           |
| `PUT` /api/todoitems/{id}    | Update an existing item | To-do item   | None                 |
| `DELETE` /api/todoitems/{id} | Delete an item          | None         | None                 |

## 1. Create Solution and Projects

```bash
    # Create Solution
    $ dotnet new sln --name Solution.Web --output Solution.Web

    # Create Project
    $ dotnet new webapi -o ./TodoApi

    # Solution Add Project
    $ dotnet sln add ./TodoApi

    $ cd TodoApi
    $ dotnet add package Microsoft.EntityFrameworkCore.InMemory
    $ code -r ../TodoApi
    # When a dialog box asks if you want to add required assets to the project
    # Select Yes

    $ dotnet dev-certs https --trust
```

## 2. Run : `Ctrl + F5`

## 3. Browser returns `HTTP 404 Not Found` -> Append `/swagger`

## 4. `https://localhost:7072/swagger` or

## 4-2. `curl https://localhost:7072/swagger/index.html`

## 5. Add model class

> Add a folder named `Models`

```csharp
namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
```

## 6. Add a database context

- Add a TodoContext.cs file to the Medels folder.

```csharp

```

## 7. Scaffold a Controller

```bash
    $ dotnet add package Microsoft.EntityFrameworkCore
    $ dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    $ dotnet add package Microsoft.EntityFrameworkCore.Tools
    $ dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    $ dotnet add package Microsoft.EntityFrameworkCore.Design
    $ dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    $ dotnet tool uninstall -g dotnet-aspnet-codegenerator
    $ dotnet tool install -g dotnet-aspnet-codegenerator
    $ dotnet tool install --global dotnet-ef
    $ dotnet build

    $ dotnet-aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers

    # Test Tool Install
    $ dotnet tool install -g Microsoft.dotnet-httprepl

    # Get List Global dotnet tool
    $ dotnet tool list -g
```

## ETC 

```bash
    $ dotnet ef dbcontext info
    $ dotnet ef dbcontext list
    $ dotnet ef dbcontext scaffold
    $ dotnet ef dbcontext script
    $ dotnet ef migrations bundle
    $ dotnet ef migrations list
    $ dotnet ef migrations remove
    $ dotnet ef migrations script
    $ dotnet ef dbcontext optimize -o Models -n BlogModels -c BlogContext
```

## .NET Core Include folder in publish

```xml
  <ItemGroup>
    <Content Include="AppData/**">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
  </ItemGroup>

  <Target Name="CreateAppDataFolder" AfterTargets="AfterPublish">
    <MakeDir Directories="$(PublishDir)AppData" Condition="!Exists('$(PublishDir)AppData')" />
  </Target>
```
