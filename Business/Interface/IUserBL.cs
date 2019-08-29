using TurisLocAPI.API.DTO.User;

namespace TurisLocAPI.API.Business.Interface
{
    public interface IUserBL
    {
        bool Register(UserRegisterDTO userRegisterDTO);
        UserDTO Login(UserLoginDTO userLoginDTO);
    }
}