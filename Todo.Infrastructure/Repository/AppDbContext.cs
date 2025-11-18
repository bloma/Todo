using Microsoft.EntityFrameworkCore;
using Todo.Core.Models.TodoItem;

namespace Todo.Infrastructure.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        DbSet<TodoItem> TodoItems { get; set; }
    }
}
