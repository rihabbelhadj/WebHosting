using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Controllers
{
    [Route("api/[controller]")]

    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class DomainController : Controller
    {
        #region Fields
        private readonly IDomainServices _iDomainServices;
        private WebHostingDbContext _context;
        #endregion
        #region Constructors
        public DomainController(
            IDomainServices DomainServices, WebHostingDbContext context)
        {
            _iDomainServices = DomainServices;
            _context = context;
        }
        #endregion
        #region  Actions
      
        [HttpGet("GetAllDomaines")]
        public List<Domain> GetCompanies()
        {
            var result = _iDomainServices.GetDomains();
            return result;
        }

        [HttpGet("GetDomain/ById")]
        public Domain GetById(int id)
        {

            var result = _iDomainServices.GetById(id);
            return result;
        }
        [HttpGet("GetDomain/ByUserId")]
        public List<Domain> GetDomainsbyUserId(Guid id)
        {

            var result = _iDomainServices.GetDomainsbyUserId(id);
            return result;
        }
        [HttpDelete("deleteById")]
        public String Delete(int id)
        {
            var result = _iDomainServices.Delete(id);
            return result;

        }
        [HttpPost("AddDomain")]
        public void Add(Domain domain)
        {
             _iDomainServices.Add(domain);
            
        }
        [HttpPut("UpdateDomain")]
        public Domain Update(Domain domain)
        {
            var result= _iDomainServices.Update(domain);
            return result;
        }
        #endregion
    }
}
