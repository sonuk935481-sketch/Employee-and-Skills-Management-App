
using Employee_and_Skills_Management_App.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_and_Skills_Management_App.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<Skills> Skills => Set<Skills>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Ensure migrations can run when design-time tools create the context.
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Skills>().HasData(

            new Skills { Id = 1, Name = "C#" },

            new Skills { Id = 2, Name = "ASP.NET Core" },

            new Skills { Id = 3, Name = "SQL Server" },

            new Skills { Id = 4, Name = "Java" },

            new Skills { Id = 5, Name = "JavaScript" },

            new Skills { Id = 6, Name = "C++" }

        );
    }
}