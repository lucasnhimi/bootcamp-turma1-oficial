using System.Threading.Tasks;
using InstagramApi.Context;
using InstagramApi.Entities;
using InstagramApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace InstagramApi.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(InstagramContext context) : base(context)
        {

        }

        public async Task<bool> Authenticate(string userName)
        {
            return await _context.User.AnyAsync(p => p.UserName.ToLower() == userName.ToLower());
        }
    }
}