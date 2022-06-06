namespace InnowisePet.DTO.DTO.Order;

public class OrderGetDto
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}