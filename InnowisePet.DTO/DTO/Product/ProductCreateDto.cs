namespace InnowisePet.DTO.DTO.Product;

public class ProductCreateDto
{
    public Guid CategoryId { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}