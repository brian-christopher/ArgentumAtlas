using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ArgentumAtlas.ViewModels;

public class AddServerViewModel
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    public IFormFile FileImage { get; set; }
}