using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models;

public class UserLoginModel
{
    [Required]
    [MinLength(4)]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
