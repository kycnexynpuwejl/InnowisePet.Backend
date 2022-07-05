using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnowisePet.Models.Entities;

public class ProductStorageModel
{
    [Key]
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    
    [ForeignKey("")]
    public Guid StorageId { get; set; }
    public int Quantity { get; set; }
}