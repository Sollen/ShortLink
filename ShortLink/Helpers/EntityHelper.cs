using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortLink.Models;

namespace ShortLink.Helpers
{
    public class EntityHelper
    {
        private IRepository repository;

        public EntityHelper(IRepository repository)
        {
            this.repository = repository;
        }

        public User GetUser(string login)
        {
            return repository.GetUser(login);
        }

        public List<Link> GetUserLinks(string login)
        {
            return repository.GetUserLinks(login);
        }
    }
}
