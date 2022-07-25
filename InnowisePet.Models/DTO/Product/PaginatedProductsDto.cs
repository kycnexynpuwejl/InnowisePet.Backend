using InnowisePet.Models.Entities;

namespace InnowisePet.Models.DTO.Product;

public class PaginatedProductsDto
{
    public IEnumerable<ProductModel> PaginatedProducts { get; set; }

    public int ProductCount { get; set; }
}