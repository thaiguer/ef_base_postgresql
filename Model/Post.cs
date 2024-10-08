﻿namespace ef_base_sqlite.Model;

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public int BlogId { get; set; }
    public Blog Blog { get; set; } = default!;
}