# Entity Framework

## .net framework `Code First`

- `App.config`

```xml
<connectionStrings>
    <add name="MyConnection" providerName="System.Data.SqlClient" connectionString="Data Source=localhost;Database=MyDb;Integrated Security=True"/>
</connectionStrings>

```

---

- `Auto Migration (Console)`

```bash
    Enable-Migrations –EnableAutomaticMigrations
```

---

```cs

// Context
public YouTubeContext() :base("name=MyConnection") { }

protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, Migrations.Configuration>());

    base.OnModelCreating(modelBuilder);
}

public DbSet<Blog> Blogs { get; set; }

public DbSet<Post> Posts { get; set; }

---

// Configuration()

public Configuration()
{
    AutomaticMigrationsEnabled = true;
    AutomaticMigrationDataLossAllowed = true;
}

// Seed
protected override void Seed(DataAccessLayer.MyContext context)
{
    //var users = new List<Blog>
    //{
    //    new Blog{ BlogId = 1, Name = "장길산" },
    //    new Blog{ BlogId = 2, Name = "임꺽정" },
    //    new Blog{ BlogId = 3, Name = "백두산" },
    //    new Blog{ BlogId = 4, Name = "한라산" }
    //};

    //users.ForEach(x => context.Blogs.AddOrUpdate(i => i.BlogId, x));
    //context.SaveChanges();
}

```

---

```bash

Add-Migration Initiaze
Update-Database

```

## EF Core 아키텍처

- 데이터 베이스
  - `데이터베이스 공급자` : 특정 데이터베이스 엔진용으로 설계한 플러그인 라이브러리, LINQ 쿼리를 데이터베이스 네이티브 SQL 언어로 변환
  - `EF Core 공급자` : 개체 사항을 SQL 로 변환
  - `DbContext` : 데이터베이스와 활성 세션, 엔터티 저장 및 쿼리
    - `DbSet<t>` : 데이터베이스 테이블 형식의 속성

## 데이터베이스 스키마 관리

- EF Core Model 과 데이터베이스 스키마를 동기 상태로 유지
  - 마이크레이션
    - 증분방식으로 업데이트로 동기상태를 유지하면서 기존 데이터 보존 방법을 제공
  - 리버스 엔지니어링
