namespace InnowisePet.Models.Entities
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public short Status { get; set; }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid CartId { get; set; }
    }
}
