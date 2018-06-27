using System.Collections.Generic;
using ShortLink.Models;

namespace ShortLink.Helpers.Abstract
{
    public interface IRepository
    {
         User GetUser(string login);
         List<Link> GetUserLinks(string login);

    }
}
