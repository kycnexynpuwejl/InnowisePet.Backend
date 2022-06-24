namespace InnowisePet.Services.Product.BLL.DTO;

public class ProductGetDto
{
    public string Category { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public byte[] Image { get; set; }
}