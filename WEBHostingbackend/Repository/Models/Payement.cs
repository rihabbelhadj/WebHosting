using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SpeakOut.Entities.Models;

namespace WEBHostingbackend.Repository.Models
{
    [Table("Payement")]
    public partial class Payement
    {
        [Key]
        [Column("idPayement")]
        public int idPayement { get; set; }
        [Column("type")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Type { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("idUser")]
        public Guid idUser { get; set; }
        [ForeignKey(nameof(idUser))]
        //[ForeignKey("IdUser")]
        [InverseProperty("Payement")]
        public virtual AspNetUsers User { get; set; }



    }
}
