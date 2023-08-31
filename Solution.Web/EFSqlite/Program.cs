using var db = new BlogContext();

Console.WriteLine("데이터목록");
Console.WriteLine();

GetBlogList();
Console.WriteLine();
GetPostList();
Console.WriteLine();

ConsoleKeyInfo cki = default;
Console.Write("\nCreate(C)\nUpdate(U)\nDelete(D)\nQuit(Q)\n작업선택 >> ");
cki = Console.ReadKey();
Console.WriteLine("작업진행");
if (cki.Key == ConsoleKey.Q) return;

int result = default;
switch (cki.Key)
{
    case ConsoleKey.C: // Create
        {
            Console.Write("Input New Blog URL >> ");
            string? url = Console.ReadLine();
            var blog = new Blog
            {
                Url = url
            };
            db.Add(blog);
            result = await db.SaveChangesAsync(); // .SaveChanges();
            Console.Clear();
            Console.WriteLine("Created Completed...");
            GetBlogList();
        }
        break;

    case ConsoleKey.U: // Update
        {
            Console.Write("Select the `Blog ID` to Update >> ");
            int blogId = Convert.ToInt32(Console.ReadLine());
            if (db.Blogs.Any(x => x.BlogId == blogId))
            {
                var blog = db.Blogs.Single(x => x.BlogId == blogId);
                Console.Write("Input Blog Update URL >> ");
                blog.Url = Console.ReadLine();

                var post = new Post
                {
                    Title = "Hi Everyone",
                    Content = "Fine Thanks And You",
                    BlogId = 3
                };
                blog.Posts.Add(post);
                await db.SaveChangesAsync();

                Console.Clear();
                Console.WriteLine($"Update Completed...");
                GetBlogList();
                return;
            }
            Console.WriteLine("잘못된 선택입니다.");
        }
        break;

    case ConsoleKey.D:
        {
            if (db.Blogs.Any(x => x.BlogId == 2))
            {
                var data = db.Blogs.Single(x => x.BlogId == 2);
                db.Remove(data);
                result = db.SaveChanges();
                if (result > 0) Console.WriteLine("Deleted");
            }
            Console.Clear();
            GetBlogList();
        }
        break;
}

/// <summary>
/// Get Blog All List
/// </summary>
static void GetBlogList()
{
    using var db = new BlogContext();
    Console.WriteLine($"ID\tURL");
    foreach (var item in db.Blogs)
    {

        Console.WriteLine($"{item.BlogId}\t{item.Url}");
    }
}

static void GetPostList()
{
    using var db = new BlogContext();
    foreach (var item in db.Posts)
    {
        Console.WriteLine($"{item.PostId}\t{item.Title}\t{item.Content}\t{item.BlogId}");
    }
}
