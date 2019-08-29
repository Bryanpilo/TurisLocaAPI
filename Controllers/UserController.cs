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
        private readonly IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {
            var values = _userBL.Login(userLoginDTO);

            if(values==null)
                return Unauthorized();


            return Ok(values);
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            var user= _userBL.Register(userRegisterDTO);

            if(!user){
               return StatusCode(409);
            }
            return StatusCode(201);
        }
    }
}