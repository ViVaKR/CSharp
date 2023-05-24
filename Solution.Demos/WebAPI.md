# Create a web API with ASP.NET Core

## Overview

| API | Description | Request body | Response body |
| - | - | - | - |
| `GET` /api/todoitems | Get all to-do items | None | Array of to-do items |
| `GET` /api/todoitems/{id} | Get an item by ID | None | To-do item |
| `POST` /api/todoitems | Add a new item | To-do item | To-do item |
| `PUT` /api/todoitems/{id} | Update an existing item | To-do item | None |
| `DELETE` /api/todoitems/{id} | Delete an item | None | None |

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

## 3. Browser returns `HTTP 404 Not Found`  -> Append `/swagger`

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
