using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models;

public class UserRegisterModel
{
    [Required]
    [MinLength(4)]
    [EmailAddress]
    public string Email { get; set; }
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
