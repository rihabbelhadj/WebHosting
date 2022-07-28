using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEBHostingbackend.Repository.Models
{
    [Table("Commande")]
    public partial class Commande
    {
        [Key]
        [Column("id_commande")]
        public int IdCommande { get; set; }
        [Column("id_domaine")]
        public int IdDomaine { get; set; }
        [Column("id_client")]
        public int IdClient { get; set; }
        [Column("id_payement")]
        public int IdPayement { get; set; }
        [Column("etat")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Etat { get; set; }
        [Column("msg_erreur")]
        [StringLength(50)]
        [Unicode(false)]
        public string? MsgErreur { get; set; }

       
    }
}
