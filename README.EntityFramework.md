# Entity Framework

## Code First

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
