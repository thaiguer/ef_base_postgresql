using ef_base_sqlite.Model;
using ef_base_sqlite.Data;

namespace ef_base_sqlite.Crud;

internal class DbHandle
{
    internal bool CreateBlog(AppDbContext db, string url)
    {
        try
        {
            Console.WriteLine("Inserting a new blog");
            db.Add(new Blog { Url = url });
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    internal bool ListBlogs(AppDbContext db)
    {
        try
        {
            var blogs = db.Blogs
                .OrderBy(b => b.BlogId);

            foreach (var blog in blogs)
            {
                Console.WriteLine($"Id:{blog.BlogId} Url:{blog.Url}");
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }
    

//// Update
//Console.WriteLine("Updating the blog and adding a post");
//blog.Url = "https://devblogs.microsoft.com/dotnet";
//blog.Posts.Add(
//    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
//db.SaveChanges();

//// Delete
//Console.WriteLine("Delete the blog");
//db.Remove(blog);
//db.SaveChanges();
}
