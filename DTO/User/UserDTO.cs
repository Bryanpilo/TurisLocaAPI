using Microsoft.IdentityModel.Tokens;

namespace TurisLocAPI.API.DTO.User
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}