using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Model
{
    [Table("cart_item")]
    [Index("Id", Name = "cart_item_id_uindex", IsUnique = true)]
    public partial class CartItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("cart_id")]
        public int CartId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("status")]
        public short Status { get; set; }
        [Column("order_id")]
        public int? OrderId { get; set; }

        [ForeignKey("CartId")]
        [InverseProperty("CartItems")]
        public virtual Cart Cart { get; set; } = null!;
        [ForeignKey("OrderId")]
        [InverseProperty("CartItems")]
        public virtual Order? Order { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("CartItems")]
        public virtual Product Product { get; set; } = null!;
    }
}
