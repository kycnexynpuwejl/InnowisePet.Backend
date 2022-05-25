using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Model
{
    [Table("location")]
    [Index("Id", Name = "location_id_uindex", IsUnique = true)]
    public partial class Location
    {
        public Location()
        {
            Storages = new HashSet<Storage>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("city")]
        [StringLength(50)]
        [Unicode(false)]
        public string City { get; set; } = null!;

        [InverseProperty("Location")]
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
