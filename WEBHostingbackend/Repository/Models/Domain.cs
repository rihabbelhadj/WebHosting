using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEBHostingbackend.Repository.Models
{
    [Table("Domain")]
    public partial class Domain
    {
        public Domain()
        {
            
        }

        [Key]
        [Column("id_domain")]
        public int IdDomain { get; set; }
        [Column("domainName")]
        [StringLength(50)]
        [Unicode(false)]
        public string DomainName { get; set; } = null!;
        [Column("date_creation", TypeName = "date")]
        public DateTime? DateCreation { get; set; }
        [Column("root")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Root { get; set; }
        [Column("id_de_base")]
        public Guid? IdDeBase { get; set; }
        [Column("hebergement_type")]
        [StringLength(50)]
        [Unicode(false)] 
        public string HebergementType { get; set; } = null!;

        
        [ForeignKey(nameof(IdDeBase))]
        [InverseProperty("Domain")]
        public virtual AspNetUsers User { get; set; }
    }
}
