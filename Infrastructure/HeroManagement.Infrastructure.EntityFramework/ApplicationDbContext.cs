using HeroManagement.Domain.Aggregates.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeroManagement.Infrastructure.EntityFramework;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
 public DbSet<Player> Players { get; set; } 
 //public DbSet<Admin> Admins { get; set; }
 public DbSet<Hero> Heroes { get; set; }
 public DbSet<Item> Items { get; set; }
 public DbSet<Ability> Abilities { get; set; }

 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
     optionsBuilder.EnableSensitiveDataLogging();
      // .UseNpgsql(@"host=localhost; port=5433; database=EntityTest; username=postgres; password=13245");
   base.OnConfiguring(optionsBuilder);
 }

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
     modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
 }
}