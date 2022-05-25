using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Model
{
    [Table("storage")]
    [Index("Id", Name = "storage_id_uindex", IsUnique = true)]
    public partial class Storage
    {
        public Storage()
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
        [Column("location_id")]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        [InverseProperty("Storages")]
        public virtual Location Location { get; set; } = null!;
        [InverseProperty("Storage")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
