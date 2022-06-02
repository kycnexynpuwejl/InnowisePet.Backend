using System.ComponentModel.DataAnnotations;
using IdentityServer4.Services;

namespace InnowisePet.Identity.Models;

public class LoginViewModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}