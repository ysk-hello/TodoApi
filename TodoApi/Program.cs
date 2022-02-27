using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Listen for incoming http connection on port 5000
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});

// Add services to the container.

builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<TodoContext>(opt =>
    //opt.UseInMemoryDatabase("TodoList"));
    opt.UseNpgsql("Host=192.168.11.14;Database=todo;Username=postgres;Password=postgres"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
