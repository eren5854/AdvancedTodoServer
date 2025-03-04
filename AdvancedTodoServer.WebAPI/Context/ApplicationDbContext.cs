using AdvancedTodoServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedTodoServer.WebAPI.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasOne(x => x.Skill)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
