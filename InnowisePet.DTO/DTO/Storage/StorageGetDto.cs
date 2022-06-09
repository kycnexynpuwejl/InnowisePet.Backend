namespace InnowisePet.DTO.DTO.Storage;

public class StorageGetDto
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public string Title { get; set; }
    public string LocationName { get; set; }
}