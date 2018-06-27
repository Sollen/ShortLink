using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortLink.Models;

namespace ShortLink.Helpers
{
    public class UserRepository
    {
        public User GetUser(string login)
        {
            return new User{Login = login};
        }
    }
}
