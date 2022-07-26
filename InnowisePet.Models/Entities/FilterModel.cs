namespace InnowisePet.Models.Entities;

public class FilterModel
{
    public int PageSize { get; set; }

    public int PageNumber { get; set; }

    public string SearchString { get; set; }

    public string CategoryId { get; set; }
}