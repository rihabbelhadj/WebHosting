using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Controllers
{
    [Route("api/")]

    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Fields
        private readonly IUserServices _iUserService;
        #endregion

        #region Constructors
        public UsersController(IUserServices userService)
        {
            _iUserService = userService;
        }
        #endregion
        #region  Actions
        [EnableCors("AllowOrigin")]
       
        [HttpGet("Users")]
        public List<User> GetUsers()
        {
            var result = _iUserService.GetUsers();
            return result;
        }


        #endregion
    }
}
