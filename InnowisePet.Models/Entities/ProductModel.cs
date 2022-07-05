using System.ComponentModel.DataAnnotations;

namespace InnowisePet.Models.Entities;

public class ProductModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid CategoryId { get; set; }
    
    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public IEnumerable<CategoryModel> Categories { get; set; }
}