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


    }
}