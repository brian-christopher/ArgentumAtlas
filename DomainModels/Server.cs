using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels;

public class Server
{
    public int ServerId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    public string Content { get; set; }
    public string Website { get; set; }
    public string Discord { get; set; } 
    public string BannerURL { get; set; }
     
    public virtual ICollection<ServerPlatform> ServerPlatforms { get; set; }
}