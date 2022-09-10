using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Controllers
{
    [Route("api/[controller]")]

    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class CommandeController : Controller
    {
        #region Fields
        private readonly ICommandeServices _iCommandeServices;
        private WebHostingDbContext _context;
        #endregion
        #region Constructors
        public CommandeController(
            ICommandeServices CommandeServices, WebHostingDbContext context)
        {
            _iCommandeServices = CommandeServices;
            _context = context;
        }
        #endregion
        #region Action
        [HttpGet("GetAllCommandes")]
        public List<Commande> GetCompanies()
        {
            var result = _iCommandeServices.GetCommande();
            return result;
        }
        [HttpGet("GetByDomaineId")]
        public List<Commande> GetBydomaineId(int id)
        {
            var result = _iCommandeServices.GetBydomaineId(id);
            return result;
        }
        [HttpGet("GetByServcieId")]
        public List<Commande> GetByServiceId(int id)
        {
            var result = _iCommandeServices.GetByServiceId(id);
            return result;
        }
        [HttpPost("AddCommande")]
        public Commande Add(Commande comm)
        {
           var result= _iCommandeServices.Add(comm);
            return result;

        }
        [HttpDelete("deleteById")]
        public String Delete(int id)
        {
            var result = _iCommandeServices.Delete(id);
            return result;

        }
        [HttpPut("UpdateCommande")]
        public Commande Update(Commande commande)
        {
            var result = _iCommandeServices.Update(commande);
            return result;
        }

        #endregion

    }
}
