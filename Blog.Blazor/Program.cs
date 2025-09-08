using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Blog.Blazor.Services;
using Blog.Blazor.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// ע�� HttpClient��ָ�� Blog.API
builder.Services.AddScoped<HttpClient>(s =>
{
    return new HttpClient { BaseAddress = new Uri("http://localhost:5261") };
});

// ע�Ჩ�ͷ���
builder.Services.AddScoped<IBlogService, BlogService>();

// �Ƴ�Ĭ�ϵ� WeatherForecastService���������Ҫ��
// builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();