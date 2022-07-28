using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Controllers
{
    [Route("api/[controller]")]

    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class ServiceController : Controller
    {
        #region Fields
        private readonly IServiceServices _iServiceServices;

        #endregion
        #region Constructors

        public ServiceController(IServiceServices serviceServices)
        {
            _iServiceServices = serviceServices;
        }
        #endregion
        #region  Actions
        [HttpGet("GetService")]
        public List<Service> GetServices()
        {
            var result = _iServiceServices.GetService();
            return result;
        }
        [HttpPost("AddService")]
        public void Add(Service serv)
        {
            _iServiceServices.Add(serv);

        }

        [HttpGet("GetService/ById")]
        public Service GetById(int id)
        {

            var result = _iServiceServices.GetById(id);
            return result;
        }

        [HttpPut("update")]
        public Service Update(Service serv)
        {
            var result = _iServiceServices.Update(serv);
            return result;

        }

        [HttpDelete("delete-by{id}")]
        public void Delete(int id)
        {
            _iServiceServices.Delete(id);

        }

        #endregion
    }
}
