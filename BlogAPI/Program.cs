using BlogAPI.Data;
using BlogAPI.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Get all blogs
app.MapGet("api/blog", () => Results.Ok(DataStore.listOfBlogs));
//Get Blog ByID
app.MapGet("api/blog/{id}", (int id) =>
{
    var blogPost = DataStore.listOfBlogs.FirstOrDefault(b => b.Id == id);

    if (blogPost == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(blogPost);

});

//Create a blog

app.MapPost("api/blog", (Blog blog) =>
{
    DataStore.listOfBlogs.Add(blog);

    return Results.Ok(blog);
});
//update a blog

app.MapPut("api/blog", (Blog blog) =>

{
    var existingBlogPost = DataStore.listOfBlogs.FirstOrDefault(b => b.Id == blog.Id);

    if(existingBlogPost == null)
    {
        return Results.NotFound();

    }

    existingBlogPost.Title=blog.Title;

    existingBlogPost.Description=blog.Description;

    return Results.Ok();
});
//delete a blog
app.MapDelete("api/blog", (int id) =>
{
    var blogPost=DataStore.listOfBlogs.FirstOrDefault(p=> p.Id == id);  
    if(blogPost == null)
    {
        return Results.NotFound();

    }
    DataStore.listOfBlogs.Remove(blogPost);

    return Results.Ok();
});
app.Run();




