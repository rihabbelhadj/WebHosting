using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Helpers;

namespace WEBHostingbackend.Controllers
{
    [Route("api/")]

    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Fields
        private readonly IUserServices _iUserService;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;
        private WebHostingDbContext _context;

        
        #endregion

        #region Constructors
        public UsersController(IUserServices userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings , WebHostingDbContext context)
        {
            _iUserService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _context = context;
        }
        #endregion
        #region  Actions
        [EnableCors("AllowOrigin")]

        [HttpGet("Users")]
        public List<ApplicationUserModel> GetUsers()
        {
            var result = _iUserService.GetUsers();
            return result;
        }


        #endregion
        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                fullName = model.fullName,
                password=model.Password
            };

            try
            {
                 var result = await _userManager.CreateAsync(applicationUser, model.Password);
               applicationUser. password = EncDscPassword.EncryptPassword(model.Password);
               
                //_context.ApplicationUser.Add(model.Password);
                // _context.SaveChanges();

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        /* public async Task<IActionResult> Login(LoginModel model)
         {
            /* var user = await _userManager.FindByNameAsync(model.UserName);
             if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
             {
                 var tokenDescriptor = new SecurityTokenDescriptor
                 {
                     Subject = new ClaimsIdentity(new Claim[]
                     {
                         new Claim("UserID",user.Id.ToString())
                     }),
                     Expires = DateTime.UtcNow.AddDays(1),
                     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                 };
                 var tokenHandler = new JwtSecurityTokenHandler();
                 var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                 var token = tokenHandler.WriteToken(securityToken);
                 return Ok(new { token });
             }
             else
                 return BadRequest(new { message = "Username or password is incorrect." });

         }*/
        public async Task<IActionResult> Login(LoginModel model)
        {
         if (model == null)
            {
                return BadRequest();

            }
         else
            {
                var user = _context.ApplicationUser.Where(a => a.UserName == model.UserName).FirstOrDefault();
                if (user != null && (user.password)==model.Password)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged In successuflly",
                     
                    }); 
                }
                else
                {
                    return NotFound();
                }
                        }
        }

    }
}
