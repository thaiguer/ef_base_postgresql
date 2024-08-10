using ef_base_sqlite.Data;
using ef_base_sqlite.Crud;

using var db = new AppDbContext();
var dbHandle = new DbHandle();

Console.WriteLine($"Database path: {db.DbPath}.");

while (true)
{
    Console.WriteLine("Type 'exit', inform a blog url, or empty to just list:");
    var command = Console.ReadLine();
    if (command == "exit" || command == null) break;

    if (command == "") dbHandle.ListBlogs(db);
    else
    {
        dbHandle.CreateBlog(db, command);
        dbHandle.ListBlogs(db);
    }
}