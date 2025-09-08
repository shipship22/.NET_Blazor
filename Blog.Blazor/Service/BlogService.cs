using System.Net.Http.Json;
using Blog.Models.Entities;
using Microsoft.AspNetCore.Components;

namespace Blog.Blazor.Services;

public class BlogService : IBlogService
{
    private readonly HttpClient _httpClient;

    public BlogService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Post>>("api/posts") ?? new List<Post>();
        }
        catch
        {
            return new List<Post>();
        }
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Post>($"api/posts/{id}");
    }

    public async Task<Post?> CreatePostAsync(Post post)
    {
        var response = await _httpClient.PostAsJsonAsync("api/posts", post);
        return await response.Content.ReadFromJsonAsync<Post>();
    }

    public async Task UpdatePostAsync(Post post)
    {
        await _httpClient.PutAsJsonAsync($"api/posts/{post.Id}", post);
    }

    public async Task DeletePostAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/posts/{id}");
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Category>>("api/categories") ?? new List<Category>();
    }

    public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        return await _httpClient.GetFromJsonAsync<List<Comment>>($"api/posts/{postId}/comments") ?? new List<Comment>();
    }

    public async Task<Comment?> CreateCommentAsync(Comment comment)
    {
        var response = await _httpClient.PostAsJsonAsync("api/comments", comment);
        return await response.Content.ReadFromJsonAsync<Comment>();
    }
}