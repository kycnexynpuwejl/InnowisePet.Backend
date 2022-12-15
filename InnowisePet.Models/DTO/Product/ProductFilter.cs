namespace InnowisePet.Models.DTO.Product;

public class ProductFilter
{
    public int PageSize { get; set; }

    public int PageNumber { get; set; }

    public string Search { get; set; }
}