namespace EFSqlite.Models;

public class Blog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BlogId { get; set; }

    [MaxLength]
    public string? Url { get; set; }

    public virtual ICollection<Post> Posts { get; }

    public Blog ()
    {
        Posts = new HashSet<Post>();
    }
}
