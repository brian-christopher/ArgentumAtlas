using System.ComponentModel.DataAnnotations;

namespace DomainModels;

public class ServerInfo
{
    public int ServerInfoId { get; set; }
    
    [Required]
    [StringLength(500)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(3000)]
    public string Content { get; set; }
     
    public string BannerURL { get; set; }
}