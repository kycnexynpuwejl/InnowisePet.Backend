namespace InnowisePet.DTO.DTO;

public class ProductStorageGetDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public int Quantity { get; set; }
    public string ProductName { get; set; }
    public string StorageName { get; set; }
}