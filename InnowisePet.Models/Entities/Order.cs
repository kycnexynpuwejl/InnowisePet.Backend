namespace InnowisePet.Models.Entities
{
    public class Order
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Guid Id { get; set; }
    }
}
