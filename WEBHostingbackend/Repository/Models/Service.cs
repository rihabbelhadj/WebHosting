using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEBHostingbackend.Repository.Models
{
    [Table("Service")]
    public partial class Service
    {
        [Key]
        [Column("id_service")]
        public int IdService { get; set; }
        [Column("service_Name")]
        [StringLength(50)]
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
        [Column("prix")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Prix { get; set; }
    }
}
