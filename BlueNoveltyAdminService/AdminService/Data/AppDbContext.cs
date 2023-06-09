
using AdminService.Models;
using AdminService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Models
        public DbSet<User> User { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Service> Service { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(s => s.Skills)
                .WithMany(c => c.Users);

            modelBuilder.Entity<Skill>()
                .HasMany(s => s.Users)
                .WithMany(c => c.Skills);

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Skills)
                .WithMany(c => c.Services);

            modelBuilder.Entity<Skill>()
                .HasMany(s => s.Services)
                .WithMany(c => c.Skills);

            modelBuilder.Entity<Skill>()
                .HasMany(s => s.User)
                .WithOne(c => c.MainSkill);

        }

    }
}
