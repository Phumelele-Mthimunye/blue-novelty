using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SharedServices.ApiMiddleware.Interfaces;

namespace Domain.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BlueNovelty;Username=postgres;Password=Gem@123!!");

            return new AppDbContext(optionBuilder.Options, null);
        }
    }
    public class AppDbContext : DbContext
    {
        private IRequestContextService<long> _requestContextService;
        public AppDbContext(DbContextOptions options, IRequestContextService<long> requestContextService): base(options)
        {
            _requestContextService = requestContextService;
        }     

        //Models
        public DbSet<HouseholdCleaningPricing>? HouseholdCleaningPricings { get; set; }
        public DbSet<HouseholdDetail>? HouseholdDetails { get; set; }
        public DbSet<CleaningRequest>? CleaningRequests { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<ServiceProvider>? ServiceProviders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
