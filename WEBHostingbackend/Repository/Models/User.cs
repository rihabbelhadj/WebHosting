using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WEBHostingbackend.Repository.Models
{
    public partial class User 
    {
        public User()
        {
            Commandes = new HashSet<Commande>();
            Payements = new HashSet<Payement>();
        }

        [Key]
        [Column("idUser")]
        public int IdUser { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Username { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Nom { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Prenom { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Entreprise { get; set; } = null!;
        public int? Etat { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Email { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Téléphone { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Description { get; set; }
        [Column("type")]
        [StringLength(50)]
        [Unicode(false)]
        public string Type { get; set; } = null!;
        [Column("idRole")]
        public int IdRole { get; set; }
        [Column("password")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Password { get; set; }

        [ForeignKey("IdRole")]
        [InverseProperty("Users")]
        public virtual UserRole IdRoleNavigation { get; set; } = null!;
        [InverseProperty("IdClientNavigation")]
        public virtual ICollection<Commande> Commandes { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Payement> Payements { get; set; }
    }
}
