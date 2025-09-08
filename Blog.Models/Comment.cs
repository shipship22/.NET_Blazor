namespace Blog.Models.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public bool IsApproved { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}