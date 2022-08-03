using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEBHostingbackend.Repository.Models
{
    [Table("Serveur")]
    public partial class Serveur
    {
        [Key]
        [Column("id_serveur")]
        public int IdServeur { get; set; }
        [Column("plateforme_type")]
        [StringLength(50)]
        [Unicode(false)]
        public string PlateformeType { get; set; } = null!;
        [Column("host_name")]
        [StringLength(50)]
        [Unicode(false)]
        public string HostName { get; set; } = null!;
        [Column("prix")]
        public int Prix { get; set; }
        [Column("nb_autorise")]
        public int NbAutorise { get; set; }
    }
}
