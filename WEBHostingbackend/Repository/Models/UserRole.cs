using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEBHostingbackend.Repository.Models
{
    [Table("UserRole")]
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("idRole")]
        public int IdRole { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Role { get; set; } = null!;

        [InverseProperty("IdRoleNavigation")]
        public virtual ICollection<User> Users { get; set; }
    }
}
