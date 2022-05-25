using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Model
{
    [Table("order")]
    [Index("Id", Name = "order_id_uindex", IsUnique = true)]
    public partial class Order
    {
        public Order()
        {
            CartItems = new HashSet<CartItem>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("firstname")]
        [StringLength(50)]
        [Unicode(false)]
        public string Firstname { get; set; } = null!;
        [Column("lastname")]
        [StringLength(50)]
        [Unicode(false)]
        public string Lastname { get; set; } = null!;
        [Column("line1")]
        [StringLength(50)]
        [Unicode(false)]
        public string Line1 { get; set; } = null!;
        [Column("line2")]
        [StringLength(50)]
        [Unicode(false)]
        public string Line2 { get; set; } = null!;
        [Column("city")]
        [StringLength(50)]
        [Unicode(false)]
        public string City { get; set; } = null!;
        [Column("country")]
        [StringLength(50)]
        [Unicode(false)]
        public string Country { get; set; } = null!;

        [InverseProperty("Order")]
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
