using InstagramApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstagramApi.Context
{
    public class InstagramContext : DbContext
    {
        public InstagramContext(DbContextOptions<InstagramContext> options) : base (options)
        {            
        }

        public DbSet<User> User {get;set;}
    }
}