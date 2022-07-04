namespace InnowisePet.Models.Entities;

public class Storage
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    public IEnumerable<ProductStorage> ProductStorages { get; set; }
}