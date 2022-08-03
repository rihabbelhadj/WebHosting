using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Infrastructure.Repository;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Controllers
{
    [Route("api/[controller]")]

    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class PayementController : Controller
    {
        #region Fields
        private readonly IPayementServices _iPayementService;
        private WebHostingDbContext _context;
        #endregion
        #region Constructors
        public PayementController(
            IPayementServices PayementService, WebHostingDbContext context)
        {
            _iPayementService = PayementService;
            _context = context;
        }
        #endregion
        #region  Actions
        /// <summary>
        /// Get company 
        /// </summary>
        /// <returns>Company</returns>
        [HttpGet("GetPayement")]
        public List<Payement> GetCompanies()
        {
            var result = _iPayementService.GetPayements();
            return result;
        }

        [HttpGet("GetPayement/ById")]
        public Payement GetById(int id)
        {

            var result = _iPayementService.GetById(id);
            return result;
        }

        [HttpGet("GetPayement/ByUserId")]
        public List<Payement> getByUserId(Guid userId)
        {

            var result = _iPayementService.getByUserId(userId);
            return result;
        }

        [HttpPost("create")]
        public void Add(Payement paye)
        {

            _iPayementService.Add(paye);

        }
        
        [HttpPut("update")]
        public Payement Update(Payement pay)
        {
            var result = _iPayementService.Update(pay);
            return result;

        }
        #region  Actions
       
        #endregion


        /*[HttpDelete("Payement/delete")]
        public Payement Delete(Payement pay)
        {
            var result = _iPayementService.Delete(pay);
            return pay;

        }*/

        [HttpDelete("deleteById")]
        public string Delete(int id)
        {
            var compToChange = _context.Payement.Where(d => d.idPayement == id).FirstOrDefault();
            _context.Attach(compToChange);
            _context.Entry(compToChange).State = EntityState.Modified;
            _context.Update(compToChange);
            _context.Payement.Remove(compToChange);
            _context.SaveChangesAsync();

            return "Deleted";
        }

         }

           

        #endregion
    }

