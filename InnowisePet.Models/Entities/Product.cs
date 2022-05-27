namespace InnowisePet.Models.Entities
{
    public class Product
    {
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public Guid id { get; set; }
        public Guid category_id { get; set; }
    }
}
