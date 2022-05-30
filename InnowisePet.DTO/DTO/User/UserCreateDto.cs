namespace InnowisePet.DTO.DTO.User;

public class UserCreateDto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string PasswordHash { get; set; }
}