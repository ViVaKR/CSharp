# Create a web API with ASP.NET Core

## Overview

| API | Description | Request body | Response body |
| - | - | - | - |
| `GET` /api/todoitems | Get all to-do items | None | Array of to-do items |
| `GET` /api/todoitems/{id} | Get an item by ID | None | To-do item |
| `POST` /api/todoitems | Add a new item | To-do item | To-do item |
| `PUT` /api/todoitems/{id} | Update an existing item | To-do item | None |
| `DELETE` /api/todoitems/{id} | Delete an item | None | None |


```dotnet
    dotnet new sln --name Solution.Web --output Solution.Web
```
