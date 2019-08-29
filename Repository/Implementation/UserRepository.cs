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
        // private readonly DataContext _context;
        // public UserRepository(DataContext context)
        // {
        //     // this.context = context;
        //     _context = context;
        // }

        // public Task<User> Login(string username, string password)
        // {
        //     throw new System.NotImplementedException();
        // }

        // public Task<User> Register(User user, string password)
        // {
        //     throw new System.NotImplementedException();
        // }

        public DataContext DataContext
        {
            get { return DataContext as DataContext; }
        }
    }
}