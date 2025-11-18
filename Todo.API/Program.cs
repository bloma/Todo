using Microsoft.EntityFrameworkCore;
using Todo.Application.Services;
using Todo.Application.Services.Interface;
using Todo.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("DefaultConnection");
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
