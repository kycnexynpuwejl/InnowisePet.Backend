using System.ComponentModel.DataAnnotations;

namespace InnowisePet.Identity.Models.DTO;

public class UserForAuthenticationDto
{
    [Required(ErrorMessage = "UserName - required field")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password - required field")]
    public string Password { get; set; }

}