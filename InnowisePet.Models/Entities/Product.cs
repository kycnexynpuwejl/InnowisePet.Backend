namespace InnowisePet.Models.Entities
{
    public class Product
    {
        public Guid id { get; set; }
        public Guid category_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string CategoryName { get; set; }

    }
}
