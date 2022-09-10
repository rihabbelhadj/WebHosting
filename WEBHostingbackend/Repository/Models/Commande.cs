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
        public Commande()
        {
           

        }
        [Key]
        [Column("id_commande")]
        public int IdCommande { get; set; }
        [Column("id_domaine")]
        public int IdDomaine { get; set; }
        [Column("id_service")]
        public int IdService { get; set; }
       
        [Column("prix")]
        public float Prix { get; set; }
        [Column("nb_annee")]
        public int NbAnnee { get; set; }
        [Column("tva")]
        public float TVA { get; set; }
        [Column("isValid")]
        public bool IsValid { get; set; }



        [ForeignKey(nameof(IdDomaine))]
      
       [InverseProperty(nameof(Domain.Commandes))]
        public virtual Domain Dom { get; set; }
        [ForeignKey(nameof(IdService))]
        [InverseProperty(nameof(Service.Commandes))]
        public virtual Service Serv { get; set; }

      

        /*[InverseProperty("commande")]
                public virtual ICollection<Domain> Domain { get; set; }*/

        /*[InverseProperty("commande")]
        public virtual AspNetUsers User { get; set;}*/


    } 
}
