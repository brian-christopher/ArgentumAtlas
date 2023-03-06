using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.SeedData;

public class SeedPlatform : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> entity)
    {
        entity.HasData(
            new Platform { PlatformId = 1, Name = "Windows", IconURL = "/images/os/windows.png" },
            new Platform { PlatformId = 2, Name = "Linux", IconURL = "/images/os/linux.png" },
            new Platform { PlatformId = 3, Name = "Mac", IconURL = "/images/os/mac.png" },
            new Platform { PlatformId = 4, Name = "Android", IconURL = "/images/os/android.png" }
        );
    }
}