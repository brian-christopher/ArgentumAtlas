﻿using System.ComponentModel.DataAnnotations;

namespace ArgentumAtlas.ViewModels;

public class LoginViewModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
    public bool RememberMe { get; set; }
}