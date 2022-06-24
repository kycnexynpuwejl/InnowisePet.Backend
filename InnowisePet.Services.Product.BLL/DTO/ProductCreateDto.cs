namespace InnowisePet.Services.Product.BLL.DTO;

public class ProductCreateDto
{
    public string Category { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}