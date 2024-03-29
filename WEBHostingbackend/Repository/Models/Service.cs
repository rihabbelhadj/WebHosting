﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEBHostingbackend.Repository.Models
{
    [Table("Service")]
    public partial class Service
    {
        public Service()
        {
            Commandes = new HashSet<Commande>();
        }
        [Key]
        [Column("id_service")]
        public int IdService { get; set; }
        [Column("service_Name")]
        [StringLength(200)]
        [Unicode(false)]
        public string ServiceName { get; set; } = null!;
        [Column("espace_disque")]
        [StringLength(50)]
        [Unicode(false)]
        public string EspaceDisque { get; set; } = null!;
        [Column("trafic_mesuel")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TraficMesuel { get; set; }
        [Column("nb_email")]
        public int? NbEmail { get; set; }
        [Column("type_hebergement")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeHebergement { get; set; }
        [Column("bande_passante")]
        [StringLength(50)]
        [Unicode(false)]
        public string? BandePassante { get; set; }
        [Column("prix")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Prix { get; set; }
        [InverseProperty("Serv")]
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
