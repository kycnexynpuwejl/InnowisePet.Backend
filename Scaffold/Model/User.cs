using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Model
{
    [Table("user")]
    [Index("Email", Name = "user_email_uindex", IsUnique = true)]
    [Index("Id", Name = "user_id_uindex", IsUnique = true)]
    [Index("Mobile", Name = "user_mobile_uindex", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("firstname")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Firstname { get; set; }
        [Column("lastname")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Lastname { get; set; }
        [Column("email")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Email { get; set; }
        [Column("password_hash")]
        [StringLength(32)]
        [Unicode(false)]
        public string? PasswordHash { get; set; }
        [Column("mobile")]
        [StringLength(15)]
        [Unicode(false)]
        public string? Mobile { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
