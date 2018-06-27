using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortLink.Models;

namespace ShortLink.Helpers
{
    public interface IRepository
    {
         User GetUser(string login);
         List<Link> GetUserLinks(string login);

    }
}
