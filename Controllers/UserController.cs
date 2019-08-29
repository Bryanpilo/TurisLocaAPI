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
        private readonly IUnitOfBL _unitOfBL;
        public UserController(IUnitOfBL unitOfBL)
        {
            _unitOfBL = unitOfBL;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {
            var values = _unitOfBL.userBL.Login(userLoginDTO);

            if(values==null)
                return Unauthorized();

                
            return Ok(values);
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            var user= _unitOfBL.userBL.Register(userRegisterDTO);

            if(!user){
               return StatusCode(409);
            }
            return StatusCode(201);
        }
    }
}