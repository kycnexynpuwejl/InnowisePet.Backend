namespace InnowisePet.DTO.DTO;

public class ProductGetDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string CategoryName { get; set; }
}