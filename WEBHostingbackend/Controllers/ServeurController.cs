using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Infrastructure.Services;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Controllers
{

    [Route("api/[controller]")]

    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class ServeurController : ControllerBase

    {
        #region Fields
        private readonly IServeurServices _iServeurServices;

        #endregion
        #region Constructors

        public ServeurController(IServeurServices serveurServices)
        {

            _iServeurServices = serveurServices;

        }
        #endregion
        [EnableCors("AllowOrigin")]
        [HttpGet("GetAllServeur")]
        #region  Actions
        public List<Serveur> GetServeurs()
        {
            var result = _iServeurServices.GetServeurs();
            return result;
        }


        [HttpGet("ById")]
        public Serveur GetById(int id)
        {

            var result = _iServeurServices.GetById(id);
            return result;
        }

        

        
        [HttpPost("create")]
        public void Add(Serveur comp)
        {

            _iServeurServices.Add(comp);

        }
       

        [HttpPut("update")]
        public Serveur Update(Serveur comp)
        {
            var result = _iServeurServices.Update(comp);
            return result;

        }





        [HttpDelete("delete-by{id}")]
        public void Delete(int id)
        {
            _iServeurServices.Delete(id);
         
        }
        #endregion
    }
}
