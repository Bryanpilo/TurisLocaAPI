using System.Threading.Tasks;
using TurisLocAPI.API.Data;
using TurisLocAPI.API.Models;

namespace TurisLocAPI.API.Repository.Implementation
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Register(User user, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}