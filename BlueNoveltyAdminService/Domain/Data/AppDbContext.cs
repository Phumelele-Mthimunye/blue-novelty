using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Models
        public DbSet<User> User { get; set; }
        public DbSet<Models.Entities.Task> Task { get; set; }
        public DbSet<Service> Service { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(s => s.Skills)
                .WithMany(c => c.Users);
        }
    }
}
