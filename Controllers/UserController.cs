using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TurisLocAPI.API.Business.Interface;
using TurisLocAPI.API.DTO.User;
using TurisLocAPI.API.Repository.Interface;

namespace TurisLocAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IFacade _facade;
        public UserController(IFacade facade)
        {
            _facade = facade;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {
            var values = _facade.userBL.Login(userLoginDTO);

            if(values==null)
                return Unauthorized();


            return Ok(values);
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            var user= _facade.userBL.Register(userRegisterDTO);

            if(!user){
               return StatusCode(409);
            }
            return StatusCode(201);
        }
    }
}