using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.SeedData;

public class SeedPlatform : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> entity)
    {
        entity.HasData(
            new Platform { PlatformId = 1, Name = "Windows" },
            new Platform { PlatformId = 2, Name = "Linux" },
            new Platform { PlatformId = 3, Name = "Mac" },
            new Platform { PlatformId = 4, Name = "Android" }
        );
    }
}