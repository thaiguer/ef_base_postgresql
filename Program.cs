using ef_base_sqlite.Data;
using ef_base_sqlite.Crud;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Configurar injeção de dependência
var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>()
    .AddLogging(static configure => configure.AddConsole())
    .AddTransient<DbHandle>()
    .BuildServiceProvider();

var db = serviceProvider.GetService<AppDbContext>();
var dbHandle = serviceProvider.GetService<DbHandle>();

Console.WriteLine($"Database path: {db.DbPath}.");

while (true)
{
    Console.WriteLine("Type 'exit', inform a blog url, or empty to just list:");
    var command = Console.ReadLine();
    if (command == "exit" || command == null) break;

    if (command == "")
    {
        await dbHandle.ListBlogsAsync();
    }
    else
    {
        await dbHandle.CreateBlogAsync(command);
        await dbHandle.ListBlogsAsync();
    }
}