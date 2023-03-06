using DataLayer.SeedData;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class ApplicationDbContext : DbContext
{
    public DbSet<ServerInfo> ServerInfos { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new SeedPlatform());
    }
}