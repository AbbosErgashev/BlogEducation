using BlogEducation.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogEducation.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
    { } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Blog> Blogs { get; set; }
}