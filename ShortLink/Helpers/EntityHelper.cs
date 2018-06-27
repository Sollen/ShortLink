using System.Collections.Generic;
using ShortLink.Helpers.Abstract;
using ShortLink.Models;

namespace ShortLink.Helpers
{
    public class EntityHelper
    {
        private IRepository _repository;

        public EntityHelper(IRepository repository)
        {
            this._repository = repository;
        }

        public User GetUser(string login)
        {
            return _repository.GetUser(login);
        }

        public List<Link> GetUserLinks(string login)
        {
            return _repository.GetUserLinks(login);
        }
    }
}
