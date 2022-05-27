namespace InnowisePet.Models.Entities
{
    public class CartItem
    {
        public int quantity { get; set; }
        public short status { get; set; }
        public Guid id { get; set; }
        public Guid product_id { get; set; }
        public Guid? order_id { get; set; }
        public Guid cart_id { get; set; }
    }
}
