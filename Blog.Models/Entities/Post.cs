namespace Blog.Models.Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string CoverImage { get; set; } = string.Empty;
    public bool IsPublished { get; set; } = true;
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public DateTime UpdatedTime { get; set; } = DateTime.Now;
    public int ViewCount { get; set; }
    public int LikeCount { get; set; }
}