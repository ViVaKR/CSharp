# Redis Settings

## (1) Nuget

```bash
    dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis
    
    dotnet add package StackExchange.Redis
```

## (2) Program.cs

```csharp
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = builder.Configuration.GetConnectionString("Redis");
        options.InstanceName = "viv-redis";
    });
```

## (3) appsettings.json

```json
    "ConnectionStrings": {
        "Redis": "localhost:63790"
    }
```

## Ref : [IAmTimCorey(YouTube)](https://youtu.be/UrQWii_kfIE)
