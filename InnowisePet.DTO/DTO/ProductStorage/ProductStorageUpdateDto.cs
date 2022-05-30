namespace InnowisePet.DTO.DTO;

public class ProductStorageUpdateDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid StorageId { get; set; }
    public int Quantity { get; set; }
}