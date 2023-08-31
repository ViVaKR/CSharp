namespace EFSqlite.Models;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [MaxLength]
    public string Content { get; set; }

    [Required]
    public int BlogId { get; set; }

    [ForeignKey(nameof(BlogId))]
    public virtual Blog Blog { get; set; }
}
