namespace InnowisePet.DTO.DTO;

public class ProductCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Guid CategoryId { get; set; }
}