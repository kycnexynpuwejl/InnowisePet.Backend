namespace InnowisePet.Identity.Models.DTO;

public class AuthenticatedUserInfo
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public IList<string> UserRoles { get; set; }
}