namespace InnowisePet.Models.Entities;

public class ProductStorage
{
    public Guid id { get; set; }
    public Guid product_id { get; set; }
    public Guid storage_id { get; set; }
    public int quantity { get; set; }
    public string ProductName { get; set; }
    public string StorageName { get; set; }
}