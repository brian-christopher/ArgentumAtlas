using DataLayer.SeedData;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class ApplicationDbContext : DbContext
{
    public DbSet<Server> ServerInfos { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<ServerPlatform> ServerPlatforms { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new SeedPlatform());

        modelBuilder.Entity<ServerPlatform>().HasKey(sp => new { sp.ServerId, sp.PlatformId });

        modelBuilder.Entity<ServerPlatform>().HasOne(sp => sp.Server)
            .WithMany(s => s.ServerPlatforms)
            .HasForeignKey(sp => sp.ServerId);

        modelBuilder.Entity<ServerPlatform>().HasOne(sp => sp.Platform)
            .WithMany(p => p.ServerPlatforms)
            .HasForeignKey(sp => sp.PlatformId);

    }
}