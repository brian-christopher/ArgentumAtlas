using System.Collections.Generic;

namespace DomainModels;

public class Platform
{
    public int PlatformId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ServerPlatform> ServerPlatforms { get; set; }
} 