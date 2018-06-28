using System;
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
            _repository = repository;
        }

        public User GetUser(string login)
        {
            return _repository.GetUser(login);
        }

        public List<Link> GetUserLinks(string login)
        {
            List<Link> links =  _repository.GetUserLinks(login);
            if (links == null) throw new LinkByUserNotFoundExcception(login);
            return links;
        }

        public Link GetLink(string shortUri)
        {
            Link link = _repository.GetLink(shortUri);
            if (link == null) throw new LinkByShortUriNotFoundExcception(shortUri);
            return link;
        }

        public class LinkByShortUriNotFoundExcception : Exception
        {
            public LinkByShortUriNotFoundExcception(string shortUri):base($"link {shortUri} not found")
            {
            }
        }
        public class LinkByUserNotFoundExcception : Exception
        {
            public LinkByUserNotFoundExcception(string login) : base($"links for User: {login} not found")
            {
            }
        }
    }
}


