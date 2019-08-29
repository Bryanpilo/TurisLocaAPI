using System.Threading.Tasks;
using TurisLocAPI.API.Models;
using TurisLocAPI.API.Repository.Interface;

namespace TurisLocAPI.API.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        //  Task<User> Register(User user, string password);
        //  Task<User> Login(string username, string password);
    }
}