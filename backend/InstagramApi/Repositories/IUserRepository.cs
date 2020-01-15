using System.Threading.Tasks;
using InstagramApi.Entities;
using InstagramApi.Utils;

namespace InstagramApi.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
         Task<bool> Authenticate(string userName);
    }
}