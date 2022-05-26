namespace InnowisePet.DTO.Dtos;

public class ProductDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public Guid Id { get; set; }
}