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
        #endregion

    }
}
