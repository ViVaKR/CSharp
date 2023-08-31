using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;
public class TodoContext : DbContext
{
    public string DbPath { get; }

    public TodoContext(DbContextOptions<TodoContext> options)
    : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }


}
