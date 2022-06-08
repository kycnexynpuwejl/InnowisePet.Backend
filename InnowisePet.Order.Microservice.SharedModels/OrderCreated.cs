namespace InnowisePet.Order.Microservice.SharedModels;

public class OrderCreated
{
    public Guid id { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string country { get; set; }
}