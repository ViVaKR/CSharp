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

## connect redis

```bash
    docker exec -it viv-redis redis-cli
```

## $scan 0, $ hgetall `<key>`

```bash
    127.0.0.1:6379> scan 0
    1) "0"
    2) 1) "viv_redis_WeatherForecast_20230409_0634"
    127.0.0.1:6379> scan 0
    1) "0"
    2) 1) "viv_redis_WeatherForecast_20230409_0635"
    2) "viv_redis_WeatherForecast_20230409_0634"
    127.0.0.1:6379> scan 0
    1) "0"
    2) 1) "viv_redis_WeatherForecast_20230409_0635"
    127.0.0.1:6379> hgetall viv_redis_WeatherForecast_20230409_0635
    1) "absexp"
    2) "638166297928792660"
    3) "data"
    4) "[{\"Date\":\"2023-04-10\",\"TemperatureC\":13,\"TemperatureF\":55,\"Summary\":\"Sweltering\"},{\"Date\":\"2023-04-11\",\"TemperatureC\":52,\"TemperatureF\":125,\"Summary\":\"Hot\"},{\"Date\":\"2023-04-12\",\"TemperatureC\":44,\"TemperatureF\":111,\"Summary\":\"Freezing\"},{\"Date\":\"2023-04-13\",\"TemperatureC\":-13,\"TemperatureF\":9,\"Summary\":\"Mild\"},{\"Date\":\"2023-04-14\",\"TemperatureC\":36,\"TemperatureF\":96,\"Summary\":\"Bracing\"}]"
    5) "sldexp"
    6) "-1"
127.0.0.1:6379>
```

## Ref : [IAmTimCorey(YouTube)](https://youtu.be/UrQWii_kfIE)
