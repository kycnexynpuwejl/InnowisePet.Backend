namespace InnowisePet.Models.DTO.Product;

public class ProductGetDto
{
    public Guid Id { get; set; }

    public Guid CategoryId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}