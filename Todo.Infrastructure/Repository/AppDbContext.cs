using Microsoft.EntityFrameworkCore;
using Todo.Core.Models.TodoItem;
using Todo.Core.Models.Users;

namespace Todo.Infrastructure.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
