using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Linq;

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

    [NotMapped]
    public string Slug
    {
        get
        {
            if (string.IsNullOrEmpty(Name)) return string.Empty;
            return Name.Replace(' ', '-').ToLower();
        }
    }
}