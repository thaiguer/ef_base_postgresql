using ef_base_sqlite.Model;
using ef_base_sqlite.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ef_base_sqlite.Crud;

internal class DbHandle
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<DbHandle> _logger;

    public DbHandle(AppDbContext dbContext, ILogger<DbHandle> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<bool> CreateBlogAsync(string url)
    {
        try
        {
            _logger.LogInformation("Inserting a new blog");
            await _dbContext.AddAsync(new Blog { Url = url });
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while creating blog");
            return false;
        }

        return true;
    }

    public async Task<bool> ListBlogsAsync()
    {
        try
        {
            var blogs = await _dbContext.Blogs
                .OrderBy(b => b.BlogId)
                .ToListAsync();

            foreach (var blog in blogs)
            {
                Console.WriteLine($"Id:{blog.BlogId} Url:{blog.Url}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while listing blogs");
            return false;
        }

        return true;
    }

    // Implementação futura para Update e Delete
    // public async Task<bool> UpdateBlogAsync(int blogId, string newUrl, string postTitle, string postContent)
    // {
    //     try
    //     {
    //         var blog = await _dbContext.Blogs.FindAsync(blogId);
    //         if (blog == null) return false;

    //         _logger.LogInformation("Updating the blog and adding a post");
    //         blog.Url = newUrl;
    //         blog.Posts.Add(new Post { Title = postTitle, Content = postContent });
    //         await _dbContext.SaveChangesAsync();
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, "Error while updating blog");
    //         return false;
    //     }

    //     return true;
    // }

    // public async Task<bool> DeleteBlogAsync(int blogId)
    // {
    //     try
    //     {
    //         var blog = await _dbContext.Blogs.FindAsync(blogId);
    //         if (blog == null) return false;

    //         _logger.LogInformation("Deleting the blog");
    //         _dbContext.Blogs.Remove(blog);
    //         await _dbContext.SaveChangesAsync();
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, "Error while deleting blog");
    //         return false;
    //     }

    //     return true;
    // }
}
