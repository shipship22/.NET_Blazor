using Blog.Models.Entities;

namespace Blog.Blazor.Services;

public interface IBlogService
{
    Task<List<Post>> GetPostsAsync();
    Task<Post?> GetPostByIdAsync(int id);
    Task<Post?> CreatePostAsync(Post post);
    Task UpdatePostAsync(Post post);
    Task DeletePostAsync(int id);
    Task<List<Category>> GetCategoriesAsync();
    Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
    Task<Comment?> CreateCommentAsync(Comment comment);
}