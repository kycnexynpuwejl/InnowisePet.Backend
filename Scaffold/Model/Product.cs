using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Model
{
    [Table("product")]
    [Index("Id", Name = "product_id_uindex", IsUnique = true)]
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        [StringLength(50)]
        [Unicode(false)]
        public string Title { get; set; } = null!;
        [Column("description")]
        [StringLength(300)]
        [Unicode(false)]
        public string? Description { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("storage_id")]
        public int StorageId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey("StorageId")]
        [InverseProperty("Products")]
        public virtual Storage Storage { get; set; } = null!;
        [InverseProperty("Product")]
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
