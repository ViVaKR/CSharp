using EFSqlite.Models;

namespace EFSqlite.Contexts;

public class BlogContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public string DbPath { get; set; }

    public BlogContext ()
    {
        // const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        // var root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        DbPath = Path.Join(AppContext.BaseDirectory, "AppData", "blogging.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
}
