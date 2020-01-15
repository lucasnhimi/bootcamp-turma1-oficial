using System.Threading.Tasks;

namespace InstagramApi.Services
{
    public interface IUserService
    {
         Task<bool> Authenticate(string userName);
         Task<bool> CreateUser(string userName);
    }
}