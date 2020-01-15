using System;

namespace InstagramApi.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public User(string userName)
        {
            UserName = userName;
        }
    }
}