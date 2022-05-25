using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Model
{
    [Table("cart")]
    [Index("Id", Name = "cart_id_uindex", IsUnique = true)]
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Carts")]
        public virtual User? User { get; set; }
        [InverseProperty("Cart")]
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
