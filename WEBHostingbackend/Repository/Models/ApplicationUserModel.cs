using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WEBHostingbackend.Repository.Models
{
    public class ApplicationUserModel
    {  public Guid  Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string fullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string Entreprise { get; set; }
        public string type { get; set; }


       
       // public Guid Id { get; internal set; }
       
    }
}
