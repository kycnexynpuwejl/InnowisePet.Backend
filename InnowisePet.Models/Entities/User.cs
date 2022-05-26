namespace InnowisePet.Models.Entities
{
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Mobile { get; set; }
        public Guid Id { get; set; }
    }
}
