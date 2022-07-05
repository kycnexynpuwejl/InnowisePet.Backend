namespace InnowisePet.DTO.ProductStorage;

public class ProductStorageCreateDto
{
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public int Quantity { get; set; }
}