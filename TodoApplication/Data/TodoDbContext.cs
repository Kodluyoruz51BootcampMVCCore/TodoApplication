using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TodoApplication.Data
{
    public class TodoDbContext : IdentityDbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}