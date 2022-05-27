namespace InnowisePet.Models.Entities
{
    public class Order
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public Guid id { get; set; }
    }
}
