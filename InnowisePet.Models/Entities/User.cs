namespace InnowisePet.Models.Entities
{
    public class User
    {
        public Guid id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string mobile { get; set; }
    }
}
