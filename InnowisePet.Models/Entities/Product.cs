namespace InnowisePet.Models.Entities
{
    public class Product
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid Id { get; set; }
        public Guid StorageId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
