using System;
using System.Threading.Tasks;
using InstagramApi.Context;
using InstagramApi.Entities;
using InstagramApi.Repositories;

namespace InstagramApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly InstagramContext _context;

        public UserService(IUserRepository userRepository, InstagramContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
        public async Task<bool> Authenticate(string userName)
        {
            try
            {
                var resposta = await _userRepository.Authenticate(userName);
                return resposta;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }   
        }

        public async Task<bool> CreateUser(string userName)
        {
            var user = new User(userName);

            try
            {
                await _userRepository.AddAsync(user);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }   
        }
    }
}