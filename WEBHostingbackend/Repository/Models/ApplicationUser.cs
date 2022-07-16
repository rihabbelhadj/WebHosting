using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace WEBHostingbackend.Repository.Models
{
    public class AspNetUsers : IdentityUser<Guid>
    {
        public AspNetUsers()
        {
            Payement = new HashSet<Payement>();
        }
        [Column(TypeName ="nvarchar(150)")]
        public string fullName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string Entreprise { get; set; }
        public string type { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Payement> Payement { get; set; }
    }
}
