using UnitOfWork;

using var db = new BloggingContext();


Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Creating a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read available blogs
Console.WriteLine("Querying for existing blogs");
var blog = db.Blogs
    .OrderBy(b => b.BlogId).
    First();

Console.WriteLine(blog);
Console.WriteLine(blog.BlogId);

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello world", Content = "I wrote an app using EF Core" });
db.SaveChanges();

// Read available blogs
Console.WriteLine("Searching for new entry");
var posts = blog.Posts;
Console.WriteLine(posts);

// Delete
// Console.WriteLine("Delete the blog");
// db.Remove(blog);
// db.SaveChanges();