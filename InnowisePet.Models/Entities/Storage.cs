namespace InnowisePet.Models.Entities;

public class Storage
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public string Title { get; set; }
    public string LocationName { get; set; }
}