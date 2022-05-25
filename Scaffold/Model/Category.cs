using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Model
{
    [Table("category")]
    [Index("Id", Name = "category_id_uindex", IsUnique = true)]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        [StringLength(50)]
        [Unicode(false)]
        public string Title { get; set; } = null!;

        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
