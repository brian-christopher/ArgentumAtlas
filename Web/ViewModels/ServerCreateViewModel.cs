using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArgentumAtlas.ViewModels;

public class ServerCreateViewModel
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public string Content { get; set; }
    public string Website { get; set; }
    public string Discord { get; set; }

    [Required]
    public IFormFile FileImage { get; set; }   
    public List<CheckBoxOption> CheckBoxes { get; set; }

    [Required(ErrorMessage = "Selecione al menos un sistema operativo disponible")]
    public List<int> SelectedPlatforms { get; set; }
}
