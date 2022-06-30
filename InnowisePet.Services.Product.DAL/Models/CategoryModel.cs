using System.ComponentModel.DataAnnotations;

namespace InnowisePet.Services.Product.DAL.Models;

public class CategoryModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }
}